using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Vector2 _direction;
    [SerializeField]
    private float _velocity = 6;
    [SerializeField] 
    private float _yOffset;
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private DamageType _damageType;

    private ProjectileObjectPool projectilePool;

    private void Awake()
    {
        projectilePool = FindObjectOfType<ProjectileObjectPool>();
    }
    
    void FixedUpdate()
    {
        transform.Translate(new Vector3(_direction.x, 0, _direction.y) * Time.deltaTime * _velocity);
    }

    public void StartProjectile(Vector2 newDirection, Vector3 newPosition, Sprite sprite, DamageType damageType, float velocity)
    {
        SetPosition(newPosition);
        SetDirection(newDirection);
        SetSprite(sprite);
        SetDamangeType(damageType);
        _velocity = velocity;
    }

    private void SetDirection(Vector2 newDirection)
    {
        _direction = newDirection;
    }

    private void SetDamangeType(DamageType damageType)
    {
        _damageType = damageType;
    }

    private void SetPosition(Vector3 newPosition)
    {
        this.transform.Translate(newPosition);
        this.transform.rotation = Quaternion.identity;
    }

    public void ResetPosition()
    {
        this.transform.position = new Vector3(0, _yOffset, 0);
    }

    private void SetSprite(Sprite sprite)
    {
        _sprite.sprite = sprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        projectilePool.PutProjectile(gameObject);
    }
}
