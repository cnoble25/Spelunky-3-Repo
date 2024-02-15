using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour // Subclassing MonoBehavior
{
    public Rigidbody2D rb;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
            //this is for later stuff
            // IEnumerator TempSpeedBuff(GameObject gb){
            //     gb.GetComponent<Movement>().movementSpeed *=3;
            //     Debug.Log("HI");
            //     yield return new WaitForSeconds(3f); 
            //     gb.GetComponent<Movement>().movementSpeed /=3;
            // }

            public void giveEffect(GameObject gb){

    }

    public void removeEffect(GameObject gb){


    }

   public  void giveSuperEffect(GameObject gb){

    }

    public void removeSuperEffect(GameObject gb){
    }
    public void Throw(GameObject gb)
    {
        
    }




}