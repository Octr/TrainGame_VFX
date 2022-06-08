using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        CreateObject<MenuManager>();
        Debug.Log("<b> Manager's have been loaded </b>");
    }

    private static void CreateObject<T>() where T : MonoBehaviour
    {
        if (Object.FindObjectOfType<T>() != null) return;

        var obj = new GameObject(typeof(T).Name);
        obj.AddComponent<T>();
    }
        
}
