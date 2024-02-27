using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public Rigidbody2D rb;

    public float duration;

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