using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public int selectedDeviceIndex = 0; // 選択されたデバイスのインデックス
    [HideInInspector] public InputDevice[] devices;       // 利用可能なデバイスのリスト
    public float speed = 5.0f;                            // プレイヤーの移動速度

    private Vector2 moveInput;

    void Start()
    {
        devices = InputSystem.devices
            .Where(device => device is Keyboard || device is Gamepad)
            .ToArray();
    }

    void Update()
    {
        if (devices.Length > selectedDeviceIndex)
        {
            var device = devices[selectedDeviceIndex];

            // キーボードの入力を処理
            if (device is Keyboard keyboard)
            {
                moveInput = new Vector2(
                    keyboard.dKey.isPressed ? 1 : keyboard.aKey.isPressed ? -1 : 0,
                    keyboard.wKey.isPressed ? 1 : keyboard.sKey.isPressed ? -1 : 0);
            }

            // ゲームパッドの入力を処理
            else if (device is Gamepad gamepad)
            {
                moveInput = gamepad.leftStick.ReadValue();
            }
        }

        MovePlayer(moveInput);
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 move = new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
