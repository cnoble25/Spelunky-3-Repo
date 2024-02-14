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
            StartCoroutine(TempSpeedBuff(collision.gameObject));
            
            // movementSpeed *=3;
            Destroy(gameObject);
            Debug.Log("touched Item");
        }
    }

    IEnumerator TempSpeedBuff(GameObject gb){
        gb.GetComponent<Movement>().movementSpeed *=3;
        Debug.Log("HI");
        yield return new WaitForSeconds(3f); 
        gb.GetComponent<Movement>().movementSpeed /=3;
    }

}