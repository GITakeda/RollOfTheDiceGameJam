using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeIndicator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Player player;

    private void FixedUpdate()
    {
        text.text = player.lifePoints.ToString();
    }
}
