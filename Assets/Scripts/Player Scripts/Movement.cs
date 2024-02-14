using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] Transform groundCheck;

    [SerializeField] LayerMask ground;

    [SerializeField] int maxExtraJumps = 0;

    [SerializeField] float sprintSpeed = 1f;

    [SerializeField] public float movementSpeed = 3f;

    [SerializeField] float jumpForce = 100f;


    int jumps;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumps = maxExtraJumps;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(0, rb.velocity.y);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontalInput*movementSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") &&  jumps > 0)
        {
            Jump();
            jumps--;
        }

        if(isGrounded()){
            jumps = maxExtraJumps;
        }
    }

    void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
    }

 
}

