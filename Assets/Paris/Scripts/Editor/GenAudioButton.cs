using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioManager), true)]
public class GenAudioButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //EditorGUILayout.LabelField("Generate");
        AudioManager gen = (AudioManager)target;
        var prefabObject = GameObject.FindObjectOfType<AudioManager>().gameObject;

        if (GUILayout.Button("Update Prefab"))
        {
            GenerateEnum.Go();
            PrefabUtility.RecordPrefabInstancePropertyModifications(target);
            PrefabUtility.ApplyPrefabInstance(prefabObject, InteractionMode.UserAction);
        }

    }
}