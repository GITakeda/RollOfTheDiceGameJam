using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    [SerializeField]
    private Transform container;

    [SerializeField]
    private int maxEnemyCount;

    private Stack<GameObject> enemies;

    private int activeEnemies = 0;

    private void Awake()
    {
        enemies = new Stack<GameObject>();
    }

    public GameObject GetEnemy(GameObject prefab)
    {
        GameObject newProjectile;

        if(activeEnemies == maxEnemyCount)
        {
            throw new Exception();
        }

        if (enemies.Count == 0)
        {
            newProjectile = Instantiate(prefab, container);
            PutEnemy(newProjectile);
            activeEnemies++;
        }

        var projectile = enemies.Pop();
        projectile.SetActive(true);
        activeEnemies++;
        return projectile;
    }

    public void PutEnemy(GameObject gameObject)
    {
        var enemy = gameObject.GetComponent<Enemy>();

        gameObject.SetActive(false);
        activeEnemies--;
        enemy.ResetPosition();
        enemies.Push(gameObject);
    }

    public int AtiveEnemies()
    {
        return activeEnemies;
    }
}
