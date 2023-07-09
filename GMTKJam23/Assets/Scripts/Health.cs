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

    [SerializeField] HealthBarUI healthBarUI;

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
            healthBarUI.SetHealth(currentHealth, maxHealth);

            if (isPlayer) { this.GetComponent<PlayerMovement>().GetHit(); }
            else{this.GetComponent<Enemy>().GetHit();}


        }
    }

    void Die()
    {
        // Death particle Effect

        if (!isPlayer)
        {
            gameObject.SetActive(false);
            var dethFX = Instantiate(deathFX, transform.position, Quaternion.identity) as GameObject;
            Destroy(dethFX, deathFXDestroyDelay);
            GameManager.Instance.AddScore(3);
            Destroy(gameObject,3f);

        }
        else
        {
            GameManager.Instance.EnableDeathUI();
            this.GetComponent<PlayerMovement>().Die();
        }

    }


}
