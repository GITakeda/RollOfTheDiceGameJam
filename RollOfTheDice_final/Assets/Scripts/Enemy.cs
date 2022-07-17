using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRigidbody;
    [SerializeField] private float velocity = 1;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private int startingLifePoints = 3;
    [SerializeField] private string projectileTag;
    [SerializeField] private string playerTag;
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
        enemyRigidbody.velocity = velocity * direction;
    }

    public void StartEnemy(DamageType damageType, DamageType weakDamageType, int lifePoints, float speed, Sprite sprite)
    {
        this.sprite.sprite = sprite;
        this.damageType = damageType;
        this.weakDamageType = weakDamageType;
        this.startingLifePoints = lifePoints;
        this.velocity = speed;
        this.lifePoints = lifePoints;
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

    private void DoDamage()
    {
        TakeDamage(lifePoints);
    }

    private void Die()
    {
        lifePoints = startingLifePoints;
        enemyObjectPool.PutEnemy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == projectileTag)
        {
            var projectile = other.GetComponent<Projectile>();

            if (projectile.GetDamageType() == damageType)
            {
                TakeDamage(0);
            }
            else if (projectile.GetDamageType() == weakDamageType)
            {
                TakeDamage(lifePoints);
            }
            //else
            //{
            //    TakeDamage(1);
            //}
        }
        else if (other.tag == playerTag) 
        {
            DoDamage();
            var playerHit = other.GetComponent<Player>();
            playerHit.TakeDamage(1);
        }
    }
}
