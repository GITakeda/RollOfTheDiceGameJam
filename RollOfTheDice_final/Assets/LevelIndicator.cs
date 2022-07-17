using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelIndicator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private EnemySpawner enemySpawner;

    private void FixedUpdate()
    {
        text.text = enemySpawner.fase.ToString();
    }
}
