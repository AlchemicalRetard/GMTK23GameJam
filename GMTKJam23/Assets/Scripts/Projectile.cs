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
    [SerializeField] float projectileLifetime= 5f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int damage = 10;
    [SerializeField] GameObject areaOfEffectExplosion;

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

        rb.velocity = moveDirection.normalized * moveSpeed;

        // Old Bullet Movement
        //if(!isMissile)
        //{
        //    rb.velocity = moveDirection.normalized * moveSpeed;
        //}
    }

    #region old Stuff
    //private void Update()
    //{
    //    // Old Missile Movement
    //    if (isMissile)
    //    {
    //        float distance = Vector2.Distance(transform.position, missileLandPosition);
    //        Debug.Log("is Egg at da position?? hmm??"+Equals(transform.position, missileLandPosition));

    //        if (!Equals(transform.position,missileLandPosition))
    //        {
    //            transform.position = Vector2.MoveTowards(transform.position, missileLandPosition, moveSpeed * Time.deltaTime +Time.deltaTime);
    //        }
    //        else
    //        {
    //            Instantiate(areaOfEffectExplosion, transform.position, Quaternion.identity);
    //            DestroyProjectile();
    //        }

    //    }
    //}
    #endregion


    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Enemy"))
       {
            other.TryGetComponent(out Health enemyHealth);

            if (isMissile)
            {
                var areaOfEffectFX = Instantiate(areaOfEffectExplosion, transform.position, Quaternion.identity).GetComponent<AreaOfEffect>();

                Destroy(areaOfEffectFX, 0.5f);
            }
            else
            {
                enemyHealth.TakeDamage(damage);
            }

            DestroyProjectile();
       }
       
    }

    void DestroyProjectile()
    {
        gameObject.SetActive(false);
        
        if (isMissile)
        {
            var areaOfEffectFX = Instantiate(areaOfEffectExplosion, transform.position, Quaternion.identity).GetComponent<AreaOfEffect>();

            Destroy(areaOfEffectFX, 0.5f);
        }

        Destroy(this.gameObject,3f);
    }

}
