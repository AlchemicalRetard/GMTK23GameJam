using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 1000;
    [SerializeField] int currentHealth;
    [SerializeField] GameObject deathFX;
    [SerializeField] float deathFXDestroyDelay = 2f;
    [SerializeField] bool isPlayer;

    bool isInvincible;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        if (currentHealth <= 0)
        {
            Die();
        }
        else { 

            currentHealth -= damage;

            if (isPlayer) { this.GetComponent<PlayerMovement>().GetHit(); }
            else{ this.GetComponent<Enemy>().GetHit(); }
        }
    }

    void Die()
    {
        gameObject.SetActive(false);

        // Death particle Effect

        //var dethFX = Instantiate(deathFX, transform.position, Quaternion.identity) as GameObject;
        //Destroy(dethFX, deathFXDestroyDelay);

        Destroy(gameObject,3f);
    }


}
