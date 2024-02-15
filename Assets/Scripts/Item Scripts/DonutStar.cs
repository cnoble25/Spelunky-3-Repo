using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutStar : item
{
   // Rigidbody2D rb;

    bool isThrown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isThrown)
        {
            rb.velocity = new Vector2(15f, rb.velocity.y);
        }
        else
        {

        }
    }

     new void giveEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().movementSpeed *= 3;

    }

     new void removeEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().movementSpeed /= 3;


    }

     new void giveSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().movementSpeed *= 6;

    }

     new void removeSuperEffect(GameObject gb)
    {
        gb.GetComponent<Movement>().movementSpeed /= 6;

    }

     new void Throw(GameObject gb)
    {
        isThrown = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision);
        if (collision.gameObject.CompareTag("player"))
        {
            // StartCoroutine(TempSpeedBuff(collision.gameObject));
            gameObject.transform.SetParent(collision.transform);
            gameObject.transform.position = collision.gameObject.transform.position;
            GetComponent<CircleCollider2D>().enabled = false;
            rb.isKinematic = true;
            collision.gameObject.GetComponent<Movement>().ItemHeld = gameObject;
            Debug.Log(gameObject + "is Being Held Right Now");
            giveEffect(collision.gameObject);
            // movementSpeed *=3;
            // Destroy(gameObject);
            Debug.Log("touched Item");
        }
        if (!(collision.gameObject.CompareTag("player")))
        {
            isThrown = false;
        }
    }

}
