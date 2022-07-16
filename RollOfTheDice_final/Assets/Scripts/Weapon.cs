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

    [SerializeField] private GameObject lookTest;

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

            var lastPos = lookTest.transform.position;
            var lastRotation = lookTest.transform.rotation;

            lookTest.transform.LookAt(hitInfo.point - new Vector3(transform.position.x, hitInfo.point.y, transform.position.z));

            var mousePos = Input.mousePosition;

            var startPos = new Vector3(0, 1, 0);

            Debug.Log(new Vector3(Screen.width / 2  - mousePos.x, Screen.height / 2 - mousePos.y));


            var position = new Vector3(transform.position.x, 0, transform.position.z);

            projectile.StartProjectile(new Vector2(direction.x, direction.z), position, _weaponProperties.projectileSprite, _weaponProperties.damageType, _weaponProperties.projectileVelocity);
        }
    }

    public void SetWeaponProperties(WeaponProperties wp)
    {
        _weaponProperties = wp;
        _sprite.sprite = _weaponProperties.weaponSprite;
    }
}