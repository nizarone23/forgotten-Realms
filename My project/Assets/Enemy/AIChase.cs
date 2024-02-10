using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damadge = 2;
    bool isEnemyDash = false;
    public float enemyDashcooldown;
    private float enemyTimedash;
    public float enemyDashSpeed;
    public GameObject player;
    public float speed;
    public Rigidbody2D rb;
    private float distance;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void enemydashAttack () 
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity += direction*enemyDashSpeed;
        
    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;



        rb.velocity = direction * speed;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        if((distance <= 6)&&Time.time >= enemyTimedash + enemyDashcooldown)
        {
            StartCoroutine(dashTelegraph());
        }       

    }
    ///
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isEnemyDash && collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamadge(damadge);
        }
    }
///
    IEnumerator dashTelegraph()
    {
        enemyTimedash = Time.time;
        float backupSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(0.4f);
        isEnemyDash = true;
        speed = backupSpeed;
        enemydashAttack();
        
        yield return new WaitForSeconds(1.0f);
        isEnemyDash = false;
    }
}
