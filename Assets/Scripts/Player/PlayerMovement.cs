using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputManager inputManager;
    public float speed = 5.0f;

    void Update()
    {
        if (inputManager.CurrentDevice == null)
            return;

        Vector2 moveInput = Vector2.zero;

        // キーボードの入力を処理
        if (inputManager.CurrentDevice is Keyboard keyboard)
        {
            moveInput = new Vector2(
                keyboard.dKey.isPressed ? 1 : keyboard.aKey.isPressed ? -1 : 0,
                keyboard.wKey.isPressed ? 1 : keyboard.sKey.isPressed ? -1 : 0);
        }

        // ゲームパッドの入力を処理
        else if (inputManager.CurrentDevice is Gamepad gamepad)
        {
            moveInput = gamepad.leftStick.ReadValue();
        }

        MovePlayer(moveInput);
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 move = new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }
}
