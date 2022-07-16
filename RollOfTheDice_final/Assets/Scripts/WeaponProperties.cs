using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponProperties : ScriptableObject
{
    public Sprite weaponSprite;

    public Sprite projectileSprite;

    public Sprite faceSprite;

    public Sprite faceIndicatorUI;

    public float coolDown;

    public float projectileVelocity;

    public DamageType damageType;

    
}

public enum DamageType
{
    Fire,
    Water,
    Grass,
    Lightning,
    Poison,
    Rock
}