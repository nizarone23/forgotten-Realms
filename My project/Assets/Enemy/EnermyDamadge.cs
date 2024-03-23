using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyDamadge : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public int damadge = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamadge(damadge);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamadge(damadge);
        }
    }
}
