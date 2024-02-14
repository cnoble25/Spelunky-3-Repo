using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision){

        Debug.Log(collision);
        if(collision.gameObject.CompareTag("player")){
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
    }
    //this is for later stuff
    // IEnumerator TempSpeedBuff(GameObject gb){
    //     gb.GetComponent<Movement>().movementSpeed *=3;
    //     Debug.Log("HI");
    //     yield return new WaitForSeconds(3f); 
    //     gb.GetComponent<Movement>().movementSpeed /=3;
    // }

    void giveEffect(GameObject gb){
        gb.GetComponent<Movement>().movementSpeed *=3;

    }

    void removeEffect(GameObject gb){
        gb.GetComponent<Movement>().movementSpeed /=3;


    }

    void giveSuperEffect(GameObject gb){
        gb.GetComponent<Movement>().movementSpeed *=6;

    }

    void removeSuperEffect(GameObject gb){
        gb.GetComponent<Movement>().movementSpeed /=6;

    }


}