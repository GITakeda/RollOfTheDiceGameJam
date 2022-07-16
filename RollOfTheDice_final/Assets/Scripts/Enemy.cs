using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float velocity = 1;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private int startingLifePoints = 3;
    [SerializeField] private string projectileTag;
    [SerializeField] private DamageType damageType;
    [SerializeField] private DamageType weakDamageType;
    private EnemyObjectPool enemyObjectPool;
    private Vector3 direction = new Vector3(0, 0, 0);
    private Movement player;

    private int lifePoints = 3;

    void Awake()
    {
        player = FindObjectOfType<Movement>();
        enemyObjectPool = FindObjectOfType<EnemyObjectPool>();
        lifePoints = startingLifePoints;
    }

    
    void FixedUpdate()
    {
        var newDirection = player.transform.position - transform.position;
        newDirection = newDirection.normalized;
        direction = new Vector3(newDirection.x, 0, newDirection.z);
        rigidbody.velocity = velocity * direction;
    }

    public void ResetPosition()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }

    public void SetPosition(Vector3 newPosition)
    {
        this.transform.Translate(newPosition);
        this.transform.rotation = Quaternion.identity;
    }

    private void TakeDamage(int damagePoints)
    {
        lifePoints -= damagePoints;

        if(lifePoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        lifePoints = 3;
        enemyObjectPool.PutEnemy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == projectileTag)
        {
            var projectile = other.GetComponent<Projectile>();

            if(projectile.GetDamageType() == damageType)
            {
                TakeDamage(0);
            } else if(projectile.GetDamageType() == weakDamageType)
            {
                TakeDamage(2);
            }
            else
            {
                TakeDamage(1);
            }
        }
    }
}
