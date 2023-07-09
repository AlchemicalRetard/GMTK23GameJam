using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Speeds")]
    
    [SerializeField] float normalMoveSpeed = 5f;
    [SerializeField] float rageMoveSpeed = 10f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color getHitColor;
    [SerializeField] float getHitFlashDelay;
    [SerializeField] int getHitFlashFrequency = 1;

    Animator anim;


    float currentMoveSpeed;
    Vector2 moveDirection;
    Vector2 mousePos;

    [Header("Components and Stuff")]
    [SerializeField] Rigidbody2D rb;

    void Awake()
    {
        currentMoveSpeed = normalMoveSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.x = Input.GetAxisRaw("Horizontal");

        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }

    }

    public void GetHit()
    {
        for (int i = 0; i < getHitFlashFrequency; i++)
        {

            spriteRenderer.color = getHitColor;
            anim.SetTrigger("Hurt");
            GameManager.Instance.AddRage(RageType.GetHit);
            StartCoroutine(SetColorNormalAfterTime(0.2f));
        }
    }

    IEnumerator SetColorNormalAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.color = Color.white;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * currentMoveSpeed * Time.fixedDeltaTime);        
    }

    public void StartRage()
    {
        currentMoveSpeed = rageMoveSpeed;
    }

    public void EndRage()
    {
        currentMoveSpeed = normalMoveSpeed;
    }

    public void Die()
    {
        // make the chicken a tandoori
    }

}
