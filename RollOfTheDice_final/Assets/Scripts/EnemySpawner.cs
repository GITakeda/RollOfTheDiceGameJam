using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private EnemyObjectPool enemyObjectPool;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private EnemyProperties[] properties;

    [SerializeField]
    private float spawnDelayMin;

    [SerializeField]
    private float spawnDelayMax;

    [SerializeField]
    private Transform[] spawnPoints;

    public void Awake()
    {
        Invoke("SpawnEnemy", spawnDelayMin);
    }

    public void SpawnEnemy()
    {
        GameObject gameObject = null;
        try
        {
            gameObject = enemyObjectPool.GetEnemy(enemyPrefab);
        } catch(Exception e)
        {
            Invoke("SpawnEnemy", UnityEngine.Random.Range(spawnDelayMin, spawnDelayMax));
            return;
        }

        var enemy = gameObject.GetComponent<Enemy>();

        var enemyProperties = properties[UnityEngine.Random.Range(0, properties.Length)];

        enemy.StartEnemy(enemyProperties.damageType, enemyProperties.weakDamageType, enemyProperties.lifePoints, enemyProperties.speed, enemyProperties.enemySprite);

        enemy.SetPosition(spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position);
       
        Invoke("SpawnEnemy", UnityEngine.Random.Range(spawnDelayMin, spawnDelayMax));
    }
}
