using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxEhealth = 1000;
    public int currentEhealth;
    public int attackPower = 150;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }
    void takeDamage(int damage)
    {
        currentEhealth = MaxEhealth - damage;
        if (currentEhealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        animator.SetTrigger("Die");
        this.enabled = false;
        StartCoroutine(DestroyAfterDelay(3f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the enemy
        Destroy(gameObject);
    }

}
