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


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent<Health>(out Health playerHealth))
        {
            // anim.Play("AttackAnim");
            playerHealth.TakeDamage(damage);
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

    IEnumerator SetColorNormalAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.color = Color.white;
    }
}
