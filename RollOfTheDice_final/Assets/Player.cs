using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int startingLifePoints = 3;

    public int lifePoints;

    public bool isDead = false;

    void Awake()
    {
        lifePoints = startingLifePoints;
    }


    public void TakeDamage(int damagePoints)
    {
        lifePoints -= damagePoints;

        if (lifePoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
    }
}
