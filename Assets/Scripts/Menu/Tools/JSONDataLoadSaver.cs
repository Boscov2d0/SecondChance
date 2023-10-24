using System.IO;
using UnityEngine;

namespace SecondChanse.Menu.Tools
{
    public class JSONDataLoadSaver<T>
    {
        public static T Load(string path)
        {
            string fullPath = Application.streamingAssetsPath + path;

            T result;

            if (!File.Exists(fullPath))
            {
                Debug.Log("File not found");
                string FileJSON = JsonUtility.ToJson("");
                File.WriteAllText(fullPath, FileJSON);
            }

            string tempJSON = File.ReadAllText(fullPath);
            result = JsonUtility.FromJson<T>(tempJSON);

            return result;
        }
        public static void SaveData(T data, string path)
        {
            string fullPath = Application.streamingAssetsPath + path;
            string FileJSON = JsonUtility.ToJson(data);
            File.WriteAllText(fullPath, FileJSON);
        }
    }
}