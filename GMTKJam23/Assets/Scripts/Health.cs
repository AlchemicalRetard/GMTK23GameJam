using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 1000;
    [SerializeField] int currentHealth;
    [SerializeField] GameObject deathFX;
    [SerializeField] float deathFXDestroyDelay = 2f;
    [SerializeField] bool isPlayer;

    HealthBarUI healthBarUI;

    bool isInvincible;

    private void Start()
    {
        currentHealth = maxHealth;

        if (!isPlayer)
        {
            healthBarUI = GetComponentInChildren<HealthBarUI>();
        
            // Set initial health in the health bar at start
            healthBarUI.SetHealth(currentHealth, maxHealth);
        }


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
            else{ 
                //if(currentHealth == (maxHealth - damage))
                //{
                //    this.GetComponentInChildren<HealthBarBehaviour>().gameObject.SetActive(true);
                //}
                this.GetComponent<Enemy>().GetHit();
                healthBarUI.SetHealth(currentHealth,maxHealth);
            }

        }
    }

    void Die()
    {
        gameObject.SetActive(false);

        // Death particle Effect

        var dethFX = Instantiate(deathFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(dethFX, deathFXDestroyDelay);
        if (!isPlayer)
        {
            Destroy(gameObject,3f);
        }
        else
        {
            this.GetComponent<PlayerMovement>().Die();
        }

    }


}
