using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private string currentPlayerName;

    private string playerName;
    private int highScore;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
        LoadData();
    }

    public string getCurrentPlayerName()
    {
        return instance.currentPlayerName;
    }

    public string getPlayerName()
    {
        return instance.playerName;
    }

    public int getHighScore()
    {
        return instance.highScore;
    }

    public void setCurrentPlayerName(string playerName)
    {
        instance.currentPlayerName = playerName;
    }

    public void setPlayerName(string name)
    {
        instance.playerName = name;
    }

    public void setPlayerName()
    {
        instance.playerName = instance.currentPlayerName;
    }

    public void setHighScore(int score)
    {
        if (instance.highScore > score) { return; }

        instance.highScore = score;
    }

    [System.Serializable]
    class Data
    {
        public string playerName;
        public int highScore;
    }

    public void SaveData()
    {
        Data saveData = new Data();

        saveData.playerName = getPlayerName();
        saveData.highScore = getHighScore();

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    private void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data loadData = JsonUtility.FromJson<Data>(json);

            setPlayerName(loadData.playerName);
            setHighScore(loadData.highScore);
        }
        else
        {
            setCurrentPlayerName("Name");
            setPlayerName("Name");
            setHighScore(0);
        }
    }
}
