using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class item : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected bool isThrown;

    [SerializeField] protected float duration;

    protected float velocityX;

    protected GameObject playergb;

    [SerializeField] protected float throwSpeed;

    // public GameObject playergb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        velocityX = 0;
    }

    void Update()
    {
        throwMovement(throwSpeed);
    }
    public abstract void giveEffect(GameObject gb);
    public abstract void removeEffect(GameObject gb);

    public abstract void giveSuperEffect(GameObject gb);

    public abstract void removeSuperEffect(GameObject gb);

    public void Throw(GameObject gb)
    {
        gb.GetComponent<Movement>().ItemHeld = null;
    }

    public void getDuration(GameObject gb)
    {
        gb.GetComponent<Movement>().ItemHeldTime = duration;
    }

    public void throwMovement(float speed)
    {
        if (isThrown)
        {
            print("hi");
            transform.parent = null;
            rb.isKinematic = false;
            if (playergb != null)
            {
                if (playergb.GetComponent<Movement>().directionOfPlayer)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                print(playergb.GetComponent<Movement>().rb.velocity);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            velocityX = 0;
        }
    }

    public void bindToPlayer(GameObject gb)
    {
        if (gb.GetComponent<Movement>().ItemHeld == null)
        {
            gameObject.transform.SetParent(gb.transform);
            gameObject.transform.position = gb.transform.position;
            GetComponent<CircleCollider2D>().enabled = false;
            gb.GetComponent<Movement>().ItemHeld = gameObject;
            giveEffect(gb);
            playergb = gb;
        }

    }

    public IEnumerator returnHitbox()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("player") && !isThrown)
        {
            bindToPlayer(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            if (isThrown)
            {
                HitEnemy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            isThrown = false;
        }
        if (!(collision.gameObject.CompareTag("player")))
        {
            isThrown = false;
        }
    }

    public void HitEnemy(GameObject gb)
    {
        Destroy(gb);
        Destroy(gameObject);
    }
}