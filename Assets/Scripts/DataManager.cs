using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

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
        instance.playerName = "Name";
        instance.highScore = 0;
        DontDestroyOnLoad(instance);
    }

    public string getPlayerName()
    {
        return instance.playerName;
    }

    public int getHighScore()
    {
        return instance.highScore;
    }

    public void setPlayerName(string playerName)
    {
        instance.playerName = playerName;
    }

    public void setHighScore(int score)
    {
        if (instance.highScore > score) { return; }

        instance.highScore = score;
    }
}
