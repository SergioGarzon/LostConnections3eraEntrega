using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    public static void SavePlayer(References references)
    {
        references= new References();
        BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.persistentDataPath + "/scoreData.dot";
        FileStream stream = new FileStream(path,FileMode.Create);
        
        SaveDataPlayer data = new SaveDataPlayer(references);

        formatter.Serialize(stream,data);
        stream.Close(); 
        

    }

    public static SaveDataPlayer LoadPlayer()
    {
        string path = Application.persistentDataPath + "/scoreData.dot";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            if (stream.Length==0)
            {
                return null;
            }

            SaveDataPlayer data = formatter.Deserialize(stream) as SaveDataPlayer;
            
            stream.Close(); 
            
            
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in"+path);
            return null;
        }
    }
}
