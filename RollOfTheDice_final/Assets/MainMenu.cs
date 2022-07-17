using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameController.GetGameController().StartGame();
    }

    public void Exit()
    {
        GameController.GetGameController().Exit();
    }
}
