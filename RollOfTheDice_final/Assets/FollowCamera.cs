using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float speed;

    private void FixedUpdate()
    {
        this.transform.position = player.transform.position * speed;
    }
}
