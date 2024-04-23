using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

[CustomEditor(typeof(PlayerInputManager))]
public class PlayerInputManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();  // デフォルトのインスペクターUIを描画

        PlayerInputManager manager = (PlayerInputManager)target;

        if (manager.devices == null || manager.devices.Length == 0)
        {
            EditorGUILayout.HelpBox("No suitable devices found.", MessageType.Info);
            return;
        }

        // デバイス選択のドロップダウンリストを作成
        string[] deviceNames = System.Array.ConvertAll(manager.devices, device => device.name);
        int newIndex = EditorGUILayout.Popup("Select Device", manager.SelectedDeviceIndex, deviceNames);

        // 選択が変更された場合は、新しいデバイスを選択
        if (newIndex != manager.SelectedDeviceIndex)
        {
            manager.SelectDevice(newIndex);
            EditorUtility.SetDirty(manager); // Mark the manager as dirty to ensure changes are saved
        }
    }
}
