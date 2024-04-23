using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;  // 標準のUI Text用

public class DeviceDisplay : MonoBehaviour
{
    public static DeviceDisplay Instance { get; private set; }
    public GameObject deviceTextPrefab;  // テキストプレハブへの参照
    public Transform contentPanel;  // ScrollViewのContentパネルへの参照

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateDeviceListUI(List<InputDevice> devices)
    {
        // 既存のテキストオブジェクトをクリア
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        // 各デバイスに対して新しいテキストオブジェクトを生成
        foreach (var device in devices)
        {
            var newText = Instantiate(deviceTextPrefab, contentPanel);
            newText.GetComponent<Text>().text = $"{device.displayName} (ID: {device.deviceId}, {device.description.product})";
        }
    }
}
