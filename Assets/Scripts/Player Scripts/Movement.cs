using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject ItemHeld;

    public float ItemHeldTime;

    [SerializeField] Transform groundCheck;

    [SerializeField] LayerMask ground;

    [SerializeField] public int maxExtraJumps = 0;

    [SerializeField] public float sprintSpeed = 1f;

    [SerializeField] public float movementSpeed = 3f;

    [SerializeField] public float jumpForce = 100f;

    int jumps;
    //right is true left is false
    public bool directionOfPlayer = false;
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
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        if (rb.velocity.x > 0)
        {
            directionOfPlayer = true;
        }
        else if (rb.velocity.x < 0)
        {
            directionOfPlayer = false;
        }
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            Jump();
            jumps--;
        }

        if (isGrounded())
        {
            jumps = maxExtraJumps;
        }

        if (Input.GetButtonDown("Fire1") && ItemHeld != null)
        {
            StartCoroutine(eatItem());
        }

        if (Input.GetButtonDown("Fire3") && ItemHeld != null)
        {
            // ItemHeld.SendMessage("removeEffect", gameObject);
            ItemHeld.SendMessage("Throw", gameObject);


        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
    }

    IEnumerator eatItem()
    {
        ItemHeld.SendMessage("getDuration", gameObject);
        ItemHeld.GetComponent<SpriteRenderer>().enabled = false;
        ItemHeld.SendMessage("removeEffect", gameObject);
        ItemHeld.SendMessage("giveSuperEffect", gameObject);
        GameObject ItemAte = ItemHeld;
        ItemHeld = null;
        yield return new WaitForSeconds(ItemHeldTime);
        ItemAte.SendMessage("removeSuperEffect", gameObject);
        Destroy(ItemAte);
        print("hi");

    }
}

