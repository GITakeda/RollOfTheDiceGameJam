using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void FixedUpdate()
    {
        if (player.isDead)
        {
            PlayerDied();
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Game ended");
    }
}
