using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    public void giveEffect(GameObject gb){

    }

    public void removeEffect(GameObject gb){
  
    }

   public  void giveSuperEffect(GameObject gb){

    }

    public void removeSuperEffect(GameObject gb){

    }


}