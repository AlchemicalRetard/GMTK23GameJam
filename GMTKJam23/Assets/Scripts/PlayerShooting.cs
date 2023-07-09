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
    [SerializeField] float currentBulletSpeed;
    Animator anim;
    [SerializeField] float normalBulletSpeed;
    [SerializeField] float rageBulletSpeed;
    [SerializeField] float missileSpeed;

    [Header("For Debug Purposes Dont change lmao")]
    [SerializeField] Vector3 mousePos;
    [SerializeField] Vector3 shootDirection;

    public AbilityCooldown cooldownTime;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = GetComponent<AbilityCooldown>();
        cam = Camera.main;
        currentBulletSpeed = normalBulletSpeed;
        anim = GetComponent<Animator>();

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
            if(!GameManager.Instance.isInRage && !cooldownTime.isEggCooldown || GameManager.Instance.isInRage)
            {
                anim.SetTrigger("Attack");

                // shoot a bomb missile thing which then lands on mouseClick position
                shootDirection = (mousePos - transform.position).normalized;
                SpawnEggMissile();
            }

        }
    }

    void SpawnFeatherBullet()
    {
        var bullet = Instantiate(featherBullet, transform.position, transform.rotation).GetComponent<Projectile>();
        bullet.InitProjectile(mousePos, shootDirection, currentBulletSpeed);
        AudioManager.Instance.PlayFeatherShootSound();
    }

    private void SpawnEggMissile()
    {
        var missile = Instantiate(eggMissile, transform.position, transform.rotation).GetComponent<Projectile>();
        missile.InitProjectile(mousePos, shootDirection, missileSpeed, true);
        AudioManager.Instance.PlayEggShootSound();
    }

    public void StartRage()
    {
        currentBulletSpeed = rageBulletSpeed;  
    }

    public void EndRage()
    {
        currentBulletSpeed= normalBulletSpeed;
    }
}

