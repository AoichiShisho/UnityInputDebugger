using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();  // デフォルトのインスペクターUIを描画

        PlayerController controller = (PlayerController)target;
        if (controller.devices == null || controller.devices.Length == 0)
        {
            EditorGUILayout.HelpBox("No devices found.", MessageType.Info);
            return;
        }

        // デバイスのドロップダウンリストを作成
        string[] deviceNames = System.Array.ConvertAll(controller.devices, device => device.name);
        controller.selectedDeviceIndex = EditorGUILayout.Popup("Select Device", controller.selectedDeviceIndex, deviceNames);
    }
}
