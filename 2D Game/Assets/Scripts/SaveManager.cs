using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";
    public static bool NeedLoad = false;

    public static void Save(PlayerData so)
    {
        string dir = Application.persistentDataPath + directory;

        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }

    public static PlayerData Load()
    {
        
        string fullPath = Application.persistentDataPath + directory + fileName;
        PlayerData so = new PlayerData();
        if(File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }
        return so;
    }

    public static PlayerData MenuLoad()
    {
        
        string fullPath = fileName;
        PlayerData so = new PlayerData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }
        return so;
    }

}
