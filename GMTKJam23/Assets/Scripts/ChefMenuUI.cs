using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefMenuUI : MonoBehaviour
{
    public float speed = 0.3f;

    private float turnTimer;
    public float timeTrigger;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        turnTimer = 0;
        timeTrigger = 3f;
    }

    private void Update()
    {
        rb.velocity = new Vector3(rb.transform.localScale.x * speed, rb.velocity.y, 0f);

        turnTimer += Time.deltaTime;
        if(turnTimer >= timeTrigger)
        {
            turnAround();
            turnTimer = 0;
        }
    }

    private void turnAround()
    {
        if(transform.localScale.x == 1)
        {
            transform.localScale = new Vector3(-1, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
