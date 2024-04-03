using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFighting : MonoBehaviour
{
    protected Rigidbody2D rb;

    public float damage = 10;

    public float health = 100;

    public abstract void attack();

    public void getDamage(PlayerLife scripts)
    {
        scripts.collisionDamage = damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
