using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Player player;

    private static GameController cur;

    public int lastPoints = 0;

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
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void End(int points)
    {
        if(points > lastPoints)
        {
            cur.lastPoints = points;
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
