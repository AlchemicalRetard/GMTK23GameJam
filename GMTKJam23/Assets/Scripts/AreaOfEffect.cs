using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField] int damage = 200;
    [SerializeField] float lifeTime = 0.5f;
    [SerializeField] float radius = 5f;

    public int GetDamage()
    {
        return damage;
    }

    private void Start()
    {
        Destroy(gameObject,lifeTime);

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("Enemy HIT !!");
            if (hitCollider.gameObject.CompareTag("Enemy") && TryGetComponent(out Health enemyHealth))
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }




}
