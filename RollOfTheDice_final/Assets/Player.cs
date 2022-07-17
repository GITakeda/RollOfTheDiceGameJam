using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int startingLifePoints = 3;

    public int lifePoints;

    public int points;

    public bool isDead = false;

    private float startTime;

    void Awake()
    {
        lifePoints = startingLifePoints;
        startTime = Time.time;
        points = 0;
    }

    private void Update()
    {
        if (!isDead)
        {
            CountPoints();
        }
    }

    public void CountPoints()
    {
        points = Mathf.RoundToInt((Time.time - startTime) * 10);
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
        GameController.GetGameController().End(points);
    }
}