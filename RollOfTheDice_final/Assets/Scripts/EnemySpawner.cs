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
    private float spawnDelayMin;

    [SerializeField]
    private float spawnDelayMax;

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

        enemy.SetPosition(this.transform.position);
       
        Invoke("SpawnEnemy", UnityEngine.Random.Range(spawnDelayMin, spawnDelayMax));
    }
}
