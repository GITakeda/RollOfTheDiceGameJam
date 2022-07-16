using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    [SerializeField]
    private Transform container;

    private Stack<GameObject> projectiles;

    private void Awake()
    {
        projectiles = new Stack<GameObject>();
    }

    public GameObject GetProjectile(GameObject prefab)
    {
        GameObject newProjectile;

        if(projectiles.Count == 0)
        {
            newProjectile = Instantiate(prefab, container);
            PutProjectile(newProjectile);
        }
        var projectile = projectiles.Pop();
        projectile.SetActive(true);
        return projectile;
    }

    public void PutProjectile(GameObject gameObject)
    {
        var projectile = gameObject.GetComponent<Projectile>();

        gameObject.SetActive(false);
        projectile.ResetPosition();
        projectiles.Push(gameObject);
    }
}
