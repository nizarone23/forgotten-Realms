using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    
    public int maxEnemyHealth;
    public int currentEnemyHealth;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    public bool _hasTarget = false;


    
    // Update is called once per frame
    void Update()
    {
        if (currentEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            currentEnemyHealth -= 3;
        }
    }
}

