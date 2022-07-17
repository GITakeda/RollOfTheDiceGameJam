using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPoints : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private void FixedUpdate()
    {
        if (GameController.GetGameController() != null)
        {
            text.text = GameController.GetGameController().lastPoints.ToString();
        }
    }
}
