using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaceIndicator : MonoBehaviour
{
    [SerializeField]
    private Movement movement;

    [SerializeField] TextMeshProUGUI indicatorUp;
    [SerializeField] TextMeshProUGUI indicatorRight;
    [SerializeField] TextMeshProUGUI indicatorDown;
    [SerializeField] TextMeshProUGUI indicatorLeft;
    [SerializeField] TextMeshProUGUI indicatorCur;

    private void Awake()
    {
        //indicatorUp.text = movement.faceUp.weaponProperties.damageType.ToString();
        //indicatorRight.text = movement.faceRight.weaponProperties.damageType.ToString();
        //indicatorDown.text = movement.faceDown.weaponProperties.damageType.ToString();
        //indicatorLeft.text = movement.faceLeft.weaponProperties.damageType.ToString();
        //indicatorCur.text = movement.faceCur.weaponProperties.damageType.ToString();
    }

    public void UpdateDirections()
    {
        indicatorUp.text = movement.faceUp.weaponProperties.damageType.ToString();
        indicatorRight.text = movement.faceRight.weaponProperties.damageType.ToString();
        indicatorDown.text = movement.faceDown.weaponProperties.damageType.ToString();
        indicatorLeft.text = movement.faceLeft.weaponProperties.damageType.ToString();
        indicatorCur.text = movement.faceCur.weaponProperties.damageType.ToString();
    }
}
