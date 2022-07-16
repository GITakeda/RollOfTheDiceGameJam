using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private ProjectileObjectPool _projectilePool;
    [SerializeField] private float _coolDownTime;
    [SerializeField] private WeaponProperties _weaponProperties;
    [SerializeField] private SpriteRenderer _sprite;

    [SerializeField] private GameObject center;

    private bool canFire = true;
    
    void Awake()
    {
        _projectilePool = FindObjectOfType<ProjectileObjectPool>();
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            Fire();
            canFire = false;
            Invoke("CanFireAgain", _weaponProperties.coolDown);
        }
    }

    private void CanFireAgain()
    {
        canFire = true;
    }

    private void Fire()
    {
        var gameObject = _projectilePool.GetProjectile(_projectilePrefab);

        var projectile = gameObject.GetComponent<Projectile>();

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        Vector3 direction;

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            direction = (hitInfo.point - new Vector3(transform.position.x, hitInfo.point.y, transform.position.z)).normalized;

            var mousePos = Input.mousePosition;

            var playerPosition = Camera.main.WorldToScreenPoint(center.transform.position);

            var lookDirectionPlayer = new Vector3(mousePos.x - playerPosition.x, mousePos.y - playerPosition.y);

            var position = new Vector3(transform.position.x, 0, transform.position.z);

            projectile.StartProjectile(new Vector2(direction.x, direction.z), 
                position, 
                _weaponProperties.projectileSprite, 
                _weaponProperties.damageType, 
                _weaponProperties.projectileVelocity,
                lookDirectionPlayer);
        }
    }

    public void SetWeaponProperties(WeaponProperties wp)
    {
        _weaponProperties = wp;
        _sprite.sprite = _weaponProperties.weaponSprite;
    }
}