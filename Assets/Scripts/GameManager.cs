using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseUI;
    public int points = 0;
    public int highscore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI recordText;
    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void ShowLoseUI()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }

        highscore = PlayerPrefs.GetInt("highscore");

        if(points > highscore)
        {
            highscore = points;
            PlayerPrefs.SetInt("highscore", highscore);
        }

        loseUI.SetActive(true);
        recordText.text = "Best Score: " + highscore.ToString();
    }

    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void OnGameOver()
    {
        ShowLoseUI();
        Time.timeScale = 0;
    }

    public void LoadMenuScene()
    {
        Time.timeScale = 1;
        GameMusic.Instance.EndMusic();
        SceneManager.LoadScene("Menu");
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = "Points: "+points.ToString();
    }
}
