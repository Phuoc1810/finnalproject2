
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public static class savesytem
{
    public static void Saveplayer(playersat player)
    {
        PlayerData data = new PlayerData(player);
        string path = Application.persistentDataPath + "/player.json";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogWarning("Save file is not found " + path + ". Creating default data");
            return CreateDefaultData();
        }
    }
    private static PlayerData CreateDefaultData()
    {
        PlayerData defaultData = new PlayerData
        {
            point = 0,
            maxHp = 100,
            maxMp = 100,
            currenthp = 100,
            currentmp = 100,
            defent = 5,
            attack = 2,
            skill = 2
        };
        playersat templePlayer = new playersat(defaultData);
        Saveplayer(templePlayer);
        return defaultData;
    }
}
[System.Serializable]
public class PlayerData
{
    public float point;
    public float maxHp;
    public float maxMp;
    public float currenthp;
    public float currentmp;
    public float defent;
    public float attack;
    public float skill;

    public PlayerData() { }
    public PlayerData(playersat player)
    {
        point = player.point;
        maxHp = player.maxhp;
        maxMp = player.maxmp;
        currenthp = player.currenthp;
        currentmp = player.currentmp;
        defent = player.defent;
        attack = player.attack;
        skill = player.skill;
    }
}
