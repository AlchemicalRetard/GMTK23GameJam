using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject featherBullet;
    [SerializeField] GameObject eggMissile;

    [Header("Speeds")]
    [SerializeField] float bulletSpeed;
    [SerializeField] float missileSpeed;

    [Header("For Debug Purposes Dont change lmao")]
    [SerializeField] Vector3 mousePos;
    [SerializeField] Vector3 shootDirection;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            // shoot a bullet
            shootDirection = (mousePos - transform.position).normalized;
            SpawnFeatherBullet();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            // shoot a bomb missile thing which then lands on mouseClick position
            shootDirection = (mousePos - transform.position).normalized;
            SpawnEggMissile();
        }
    }

    void SpawnFeatherBullet()
    {
        var bullet = Instantiate(featherBullet,transform.position,transform.rotation).GetComponent<Projectile>();
        bullet.InitProjectile(mousePos, shootDirection, bulletSpeed);
    }

    private void SpawnEggMissile()
    {
        var missile = Instantiate(eggMissile, transform.position, transform.rotation).GetComponent<Projectile>();
        missile.InitProjectile(mousePos, shootDirection, missileSpeed,true);    
    }
}
