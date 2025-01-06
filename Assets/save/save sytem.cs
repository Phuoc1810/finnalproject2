
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class savesytem 
{
   public static void Saveplayer(playersat player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        sat data = new sat(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static sat loadplayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            sat data = formatter.Deserialize(stream) as sat;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;

        }
    }
}
