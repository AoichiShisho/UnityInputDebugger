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
        UpdateDeviceList();
        if (devices.Length > 0)
            SelectDevice(SelectedDeviceIndex);  // 初期デバイスを選択

        // デバイスの変更を監視
        InputSystem.onDeviceChange += OnDeviceChanged;
    }

    void OnDestroy()
    {
        // イベントリスナーをクリーンアップ
        InputSystem.onDeviceChange -= OnDeviceChanged;
    }

    private void UpdateDeviceList()
    {
        devices = InputSystem.devices
            .Where(device => device is Keyboard || device is Gamepad)
            .ToArray();
    }

    private void OnDeviceChanged(InputDevice device, InputDeviceChange change)
    {
        switch(change)
        {
            case InputDeviceChange.Added:
                UpdateDeviceList();
                break;

            case InputDeviceChange.Removed:
                if (device == CurrentDevice)
                {
                    CurrentDevice = null;
                    SelectedDeviceIndex = -1;
                }
                UpdateDeviceList();
                break;
        }
    }

    public void SelectDevice(int index)
    {
        if (index >= 0 && index < devices.Length)
        {
            CurrentDevice = devices[index];
            SelectedDeviceIndex = index;
        }
        else
        {
            CurrentDevice = null;
            SelectedDeviceIndex = -1;
        }
    }
}
