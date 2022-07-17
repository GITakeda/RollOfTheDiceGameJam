using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Player player;

    private static GameController cur;

    public int lastPoints = 0;
    public bool showTutorial = true;

    private string highScoreMap = "HightScore";

    private string hasSeenTheTutorialMap = "HasSeenTheTutorial";

    public static GameController GetGameController()
    {
        return cur;
    }

    private void Awake()
    {
        if (cur != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            cur = this;
            DontDestroyOnLoad(cur);
        }

        showTutorial = PlayerPrefs.GetInt(hasSeenTheTutorialMap) == 0;
        lastPoints = PlayerPrefs.GetInt(highScoreMap);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        showTutorial = false;
        PlayerPrefs.SetInt(hasSeenTheTutorialMap, 1);
    }

    public void StartButton()
    {
        if (showTutorial)
        {
            ToTutorial1();
        }
        else
        {
            StartGame();
        }
    }

    public void End(int points)
    {
        if(points > lastPoints)
        {
            cur.lastPoints = points;
            PlayerPrefs.SetInt(highScoreMap, cur.lastPoints);
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToTutorial1()
    {
        SceneManager.LoadScene("Tutorial_1");
    }

    public void ToTutorial2()
    {
        SceneManager.LoadScene("Tutorial_2");
    }
}
