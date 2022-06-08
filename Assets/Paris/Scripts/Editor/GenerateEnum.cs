#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using System;

public class GenerateEnum
{
    public static string[] SoundNames;

    //[MenuItem("Tools/GenerateEnum")]
    public static void Go()
    {
        int _soundSize = 0;
        int _soundSlot = 0;

        AudioManager _audio = AudioManager.Instance;

        foreach (Sound s in AudioManager.Instance.sounds)
        {
            _soundSize++;
        }

        foreach (Sound s in AudioManager.Instance.sounds)
        {
            Array.Resize<string>(ref SoundNames, _soundSize);
            SoundNames[_soundSlot] = s.name;
            _soundSlot++;
        }

        string enumName = "Audio";

        string[] enumEntries = SoundNames;

        string filePathAndName = "Assets/Paris/Scripts/Enums/" + enumName + ".cs"; //The folder Scripts/Enums/ is expected to exist

        using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
        {
            streamWriter.WriteLine("public enum " + enumName);
            streamWriter.WriteLine("{");
            for (int i = 0; i < enumEntries.Length; i++)
            {
                streamWriter.WriteLine("\t" + enumEntries[i] + ",");
            }
            streamWriter.WriteLine("}");
        }
        AssetDatabase.Refresh();
    }

}
#endif