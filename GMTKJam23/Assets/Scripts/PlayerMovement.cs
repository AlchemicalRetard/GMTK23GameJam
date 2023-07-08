using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Speeds")]
    
    [SerializeField] float normalMoveSpeed = 5f;
    [SerializeField] float rageMoveSpeed = 10f;
    float currentMoveSpeed;
    Vector2 moveDirection;
    Vector2 mousePos;

    [Header("Components and Stuff")]
    [SerializeField] Rigidbody2D rb;

    void Awake()
    {
        currentMoveSpeed = normalMoveSpeed;
    }

    void Update()
    {
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.x = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * currentMoveSpeed * Time.fixedDeltaTime);        
    }

}
