using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] bool isMissile;

    Vector2 moveDirection;
    Vector2 missileLandPosition;
    Vector2 mousePos;

    Rigidbody2D rb;

    float moveSpeed = 5f;

    

    public void InitProjectile(Vector3 startPosition,Vector2 mousePosition, Vector2 direction, float speed,bool isEgg = false)
    {
        transform.position = startPosition;
        missileLandPosition = mousePosition;
        moveDirection = direction;  
        moveSpeed = speed;
        isMissile = isEgg;
    }

    

    void FixedUpdate()
    {
        if (isMissile)
        {
            Vector2 desiredPosition = Vector2.MoveTowards(transform.position, missileLandPosition, Time.deltaTime * moveSpeed);
            rb.MovePosition(desiredPosition);
        }
        else
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void DestroyBullet(float delay = 0)
    {
        Destroy(gameObject,delay);
    }

}
