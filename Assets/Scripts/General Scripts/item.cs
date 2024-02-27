using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool isThrown;

    public float duration;
    public float velocityX = 0;
    public GameObject playergb;

    public float throwSpeed;

    // public GameObject playergb;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void giveEffect(GameObject gb)
    {

    }

    public void removeEffect(GameObject gb){
  
    }

   public  void giveSuperEffect(GameObject gb){

    }

    public void removeSuperEffect(GameObject gb){

    }

    public void Throw(GameObject gb)
    {
        gb.GetComponent<Movement>().ItemHeld = null;

    }

    public void getDuration(GameObject gb)
    {
        gb.GetComponent<Movement>().ItemHeldTime = duration;
    }

    public void throwMovement(float speed){
        if (isThrown)
        {
            transform.parent = null;
            rb.isKinematic = false;
            if(playergb != null){
            if(velocityX == 0){
                velocityX = playergb.GetComponent<Movement>().rb.velocity.x;
            }
            if(velocityX >= 0){
            rb.velocity = new Vector2(speed, rb.velocity.y);
            }else{
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

    public void bindToPlayer(GameObject gb){
       
            // StartCoroutine(TempSpeedBuff(collision.gameObject));
            gameObject.transform.SetParent(gb.transform);
            gameObject.transform.position = gb.transform.position;
            GetComponent<CircleCollider2D>().enabled = false;
            gb.GetComponent<Movement>().ItemHeld = gameObject;
            // movementSpeed *=3;
            // Destroy(gameObject);
            
    }
}