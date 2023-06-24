using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        SetHighScoreText();

        playButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void SetHighScoreText()
    {
        string playerName = DataManager.instance.getPlayerName();
        int highScore = DataManager.instance.getHighScore();

        highScoreText.text = $"High Score : {playerName} : {highScore}";
    }

    private void StartGame()
    {
        DataManager.instance.setCurrentPlayerName(playerNameText.text);
        SceneManager.LoadScene(1);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
