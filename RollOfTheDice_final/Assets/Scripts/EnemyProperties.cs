using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyProperties : ScriptableObject
{
    public Sprite enemySprite;

    public float speed;

    public int lifePoints;

    public DamageType damageType;

    public DamageType weakDamageType;
}

