using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField, HideInInspector]
    public int SelectedDeviceIndex { get; private set; } = 0; // 選択されたデバイスのインデックス

    [HideInInspector] public InputDevice[] devices;       // 利用可能なデバイスのリスト

    public InputDevice CurrentDevice { get; private set; }

    void Start()
    {
        devices = InputSystem.devices
            .Where(device => device is Keyboard || device is Gamepad)
            .ToArray();
        if (devices.Length > 0)
            SelectDevice(SelectedDeviceIndex);  // 初期デバイスを選択
    }

    public void SelectDevice(int index)
    {
        if (index >= 0 && index < devices.Length)
        {
            CurrentDevice = devices[index];
            SelectedDeviceIndex = index;
        }
    }
}
