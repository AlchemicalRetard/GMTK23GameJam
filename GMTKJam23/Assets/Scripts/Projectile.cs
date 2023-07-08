using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool isMissile;
    [SerializeField]float projectileLifetime= 5f;
    [SerializeField]float moveSpeed = 5f;

    Vector2 moveDirection;
    Vector2 missileLandPosition;
    Vector2 mousePos;

    Action<Projectile> destroyAction;



    private void Start()
    {

        rb.velocity = moveDirection.normalized * moveSpeed;

        Invoke(nameof(DestroyProjectile), projectileLifetime);
    }


    public void InitProjectile(Vector2 mousePosition, Vector2 direction, float speed,bool isEgg = false)
    {
        
        missileLandPosition = mousePosition;
        moveDirection = direction;  
        moveSpeed = speed;
        isMissile = isEgg;
    }

    

    void FixedUpdate()
    {
        if(!isMissile)
        {
            rb.velocity = moveDirection.normalized * moveSpeed;
        }
    }

    private void Update()
    {
        if (isMissile)
        {
            float distance = Vector2.Distance(transform.position, missileLandPosition);
            Debug.Log(distance);

            if (distance > 0.1f)
            {
                Vector2 newPosition = Vector2.Lerp(transform.position, missileLandPosition, moveSpeed * Time.deltaTime);
                transform.position = newPosition;
            }
            else
            {
                DestroyProjectile();
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }
    }


    void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

}
