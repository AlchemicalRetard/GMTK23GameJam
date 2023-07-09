using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] int damage;
    [SerializeField] int getHitFlashFrequency;
    [SerializeField] Color getHitColor;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float attackDelay = 1f;

    Coroutine attackCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<Health>(out Health playerHealth))
        {
            Debug.Log("Starting Coroutine");
            attackCoroutine = StartCoroutine(WaitAndAttack(attackDelay, playerHealth));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (attackCoroutine != null)
            {
                Debug.Log("Stopping Coroutine");
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }

    public void GetHit()
    {
        for (int i = 0; i < getHitFlashFrequency; i++)
        {
            spriteRenderer.color = getHitColor;
            StartCoroutine(SetColorNormalAfterTime(0.2f));
        }
    }

    IEnumerator WaitAndAttack(float delay, Health playerHealth)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            playerHealth.TakeDamage(damage);
        }
    }

    IEnumerator SetColorNormalAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.color = Color.white;
    }
}
