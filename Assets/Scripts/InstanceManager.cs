using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InstanceManager instance;

    public string playerName;

    public int highScore;
    public string highScorePlayerName;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore();
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData
        {
            highScorePlayerName = highScorePlayerName,
            highScore = highScore
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScore = data.highScore;
        }
    }

}
