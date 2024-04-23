using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceManager : MonoBehaviour
{
    public static DeviceManager Instance { get; private set; }

    public List<InputDevice> devices = new List<InputDevice>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        InputSystem.onDeviceChange += HandleDeviceChange;
        UpdateDeviceList();
    }

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= HandleDeviceChange;
    }

    private void HandleDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added || change == InputDeviceChange.Removed)
        {
            UpdateDeviceList();
        }
    }

    private void UpdateDeviceList()
    {
        devices.Clear();
        foreach (var device in InputSystem.devices)
        {
            if (device is Keyboard || device is Gamepad)
            {
                devices.Add(device);
            }
        }

        // Notify UI to update
        DeviceDisplay.Instance?.UpdateDeviceListUI(devices);
    }
}
