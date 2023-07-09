using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField] int damage = 200;
    [SerializeField] float lifeTime = 0.5f;
    
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with " + other.gameObject.name);
        if (other.CompareTag("Enemy"))
        {
            //Health enemyHealth;
            if (other.TryGetComponent(out Health enemyHealth))
            {
                enemyHealth.TakeDamage(damage);
                GameManager.Instance.AddRage(RageType.Explosion);
                Debug.Log("Damage dealt to " + other.gameObject.name);
            }
            else
            {
                Debug.Log("No Health component found on " + other.gameObject.name);
            }
        }
        else
        {
            Debug.Log(other.gameObject.name + " is not tagged as Enemy");
        }
    }
}
