using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beans : item
{
    // Rigidbody2D rb;

    // float duration;

    GameObject playergb;
    
    float velocityX = 0;

    bool isThrown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        duration = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrown)
        {
            transform.parent = null;
            rb.isKinematic = false;
            if (playergb != null)
            {
                if (velocityX == 0)
                {
                    velocityX = playergb.GetComponent<Movement>().rb.velocity.x;
                }
                if (velocityX >= 0)
                {
                    rb.velocity = new Vector2(15f, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-15f, rb.velocity.y);
                }
                print(playergb.GetComponent<Movement>().rb.velocity);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.isKinematic = true;
            velocityX = 0;
        }
    }

    new void giveEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().jumpForce *= 2;
    }

    new void removeEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().jumpForce /= 2;

    }

    new void giveSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().maxExtraJumps += 2;

    }
    new void removeSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().jumpForce -= 2;
    }

    new void Throw(GameObject gb)
    {
        base.Throw(gb);
        isThrown = true;
        removeEffect(gb);
        StartCoroutine(returnHitbox());
    }
    new void bindToPlayer(GameObject gb){
         if(gb.GetComponent<Movement>().ItemHeld == null){
        base.bindToPlayer(gb);
        giveEffect(gb);
        playergb = gb;
         }
    }

    IEnumerator returnHitbox()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("player"))
        {
            bindToPlayer(collision.gameObject);
        }
        if (!(collision.gameObject.CompareTag("player")))
        {
            isThrown = false;
        }
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            if(isThrown){
            Destroy(collision.gameObject);
            Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            isThrown = false;
        }
    }
}
