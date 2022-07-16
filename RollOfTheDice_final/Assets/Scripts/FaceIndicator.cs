using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FaceIndicator : MonoBehaviour
{
    [SerializeField]
    private Movement movement;

    [SerializeField] Image indicatorUp;
    [SerializeField] Image indicatorRight;
    [SerializeField] Image indicatorDown;
    [SerializeField] Image indicatorLeft;
    [SerializeField] Image indicatorCur;

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
        indicatorUp.sprite = movement.faceUp.weaponProperties.faceIndicatorUI;
        indicatorRight.sprite = movement.faceRight.weaponProperties.faceIndicatorUI;
        indicatorDown.sprite = movement.faceDown.weaponProperties.faceIndicatorUI;
        indicatorLeft.sprite = movement.faceLeft.weaponProperties.faceIndicatorUI;
        indicatorCur.sprite = movement.faceCur.weaponProperties.faceIndicatorUI;
    }
}
