using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    float health;
    bool isStationary;
    bool isAngy;
    Rigidbody2D rb;

    public float vision;

    [SerializeField] LayerMask player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange()){
            if(Input.GetKeyDown("q")){
                print("hi");
            }
        }
        
    }

    bool playerInRange(){
        return Physics2D.OverlapCircle(rb.position, vision, player);
    }
}
