using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameController.GetGameController().StartGame();
    }

    public void StartButton()
    {
        GameController.GetGameController().StartButton();
    }

    public void Exit()
    {
        GameController.GetGameController().Exit();
    }

    public void LoadTutorial1()
    {
        GameController.GetGameController().ToTutorial1();
    }

    public void LoadTutorial2()
    {
        GameController.GetGameController().ToTutorial2();
    }

    public void StartMenu()
    {
        GameController.GetGameController().End(0);
    }
}
