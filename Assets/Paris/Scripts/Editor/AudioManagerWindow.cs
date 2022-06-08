using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class AudioManagerWindow : EditorWindow
{
    private string _path = "Assets/Paris/Scenes/Managers.unity";

    Editor embeddedInspector;
    Scene ManagerScene;

    [MenuItem("Window/Managers")]

    static void Init()
    {
        // Get existing open window or if none, make a new one:
        AudioManagerWindow window = (AudioManagerWindow)EditorWindow.GetWindow(typeof(AudioManagerWindow));
    }

    public static void OpenCustomWindow()
    {
        var window = EditorWindow.GetWindow(typeof(AudioManagerWindow));
        var title = new GUIContent();
        title.text = "Managers";
        window.titleContent = title;
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Load Managers"))
        {

            ManagerScene = EditorSceneManager.GetSceneByPath(_path);

            if (!ManagerScene.isLoaded)
            {
                EditorSceneManager.OpenScene(_path, OpenSceneMode.Additive);
            }

            Selection.objects = new Object[] { FindObjectOfType<AudioManager>() };
        }

        if (GUILayout.Button("Unload Managers"))
        {

            ManagerScene = EditorSceneManager.GetSceneByName("Managers");

            if (ManagerScene.isLoaded)
            {

                if (EditorSceneManager.GetActiveScene() != ManagerScene)
                {
                    EditorSceneManager.CloseScene(ManagerScene, true);
                    Debug.Log("Unloading Managers Scene.");
                }
                
            }
            else
            {
                Debug.Log("Cant Find Managers Scene, Try \"Load  Managers\" ");
            }

        }



        if (Selection.activeGameObject != null)
        {
            GameObject sel = Selection.activeGameObject;
            AudioManager targetComp = sel.GetComponent<AudioManager>();

            if (targetComp != null)
            {
                //var editor = Editor.CreateEditor(targetComp);
                RecycleInspector(targetComp);
                embeddedInspector.OnInspectorGUI();
            }
        }      

    }

    // a helper method that destroys the current inspector instance before creating a new one
    // use this in place of "Editor.CreateEditor"
    void RecycleInspector(Object target)
    {
        if (embeddedInspector != null) DestroyImmediate(embeddedInspector);
        embeddedInspector = Editor.CreateEditor(target);
    }


    // clean up the inspector instance when the EditorWindow itself is destroyed
    void OnDisable()
    {
        if (embeddedInspector != null) DestroyImmediate(embeddedInspector);
    }

}
