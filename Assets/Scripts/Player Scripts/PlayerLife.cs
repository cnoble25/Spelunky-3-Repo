using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    float health = 100;

    bool canBeHit = true;

    public float collisionDamage;
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            collision.gameObject.SendMessage("getDamage",  this);
            StartCoroutine(GetHit(collisionDamage));

        }
    }

     void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Movement>().enabled = false;
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    IEnumerator GetHit(float damage)
    {
        
        if (canBeHit)
        {
           
            health -= damage;
            canBeHit = false;
            if(health <= 0)
            {
                Die();
            }
            print(health);
            yield return new WaitForSeconds(1);
            canBeHit = true;
        }
        

    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
