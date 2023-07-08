using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject featherBullet;
    [SerializeField] GameObject eggMissile;

    [SerializeField] float bulletSpeed;
    [SerializeField] float missileSpeed;

    [SerializeField] Vector2 mousePos;
    Camera cam;
    ObjectPool<Projectile> featherBulletPool;

    bool isMissile;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        //featherBulletPool = new ObjectPool<Projectile>(
        //() =>
        //{
        //    //return Instantiate(feather)    
        //},
        //)
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetButtonDown("Fire1"))
        {
            // shoot a bullet
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            // shoot a bomb missile thing which then lands on mouseClick position
        }
    }

    void SpawnFeatherBullet()
    {
        GameObject feather = Instantiate(featherBullet) as GameObject;
        feather.GetComponent<Projectile>().InitProjectile(firePoint.transform.position, mousePos, firePoint.up, bulletSpeed);
    }
}
