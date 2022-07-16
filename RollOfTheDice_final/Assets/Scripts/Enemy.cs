using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float velocity = 1;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private int lifePoints = 3;
    [SerializeField] private string projectileTag;
    [SerializeField] private DamageType damageType;
    private Vector3 direction = new Vector3(0, 0, 0);
    private Movement player;

    void Awake()
    {
        player = FindObjectOfType<Movement>();   
    }

    
    void FixedUpdate()
    {
        var newDirection = player.transform.position - transform.position;
        newDirection = newDirection.normalized;
        direction = new Vector3(newDirection.x, 0, newDirection.z);
        rigidbody.velocity = velocity * direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == projectileTag)
        {
            //TODO Implementar tomar dano
        }
    }
}
