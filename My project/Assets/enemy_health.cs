using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    
    public int maxEnemyHealth;
    public int currentEnemyHealth;
    public GameObject actualBeamPrefab;
    public GameObject warningBeamPrefab;
    public Transform firePoint;
    public float beamSpeed = 10f;
    public Animator animator;

    private float attackTimer = 3f;
    private float warningTime = 2f;
    private float actualBeamTime = 2f;

    public CollisionZone chargeZone;
    bool HasTarget;
    private Vector3 enemyPosition;
    private Vector3 playerPosition;

    bool shooting = false;
    bool isWarningBeam = true;

    private Vector2 direction;

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

        HasTarget = chargeZone.detectedColliders.Count > 0;

        if (HasTarget && !shooting)
        {
            InvokeRepeating("StartAttackSequence", 0, 4f); // 7s = 2s (warning) + 2s (actual) + 3s (rest)
            shooting = true;
        }
        else if (!HasTarget && shooting)
        {
            CancelInvoke("StartAttackSequence");
            shooting = false;
            isWarningBeam = true;
        }

    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            currentEnemyHealth -= 3;
        }
    }

    void StartAttackSequence()
    {
        if (isWarningBeam)
        {
            FireBeam();
            
            Invoke("FireBeam", warningTime);
        }

        isWarningBeam = !isWarningBeam;
    }

    void FireBeam()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            

            

            if (isWarningBeam)
            {
                playerPosition = player.transform.position;
                enemyPosition = transform.position;
                direction = enemyPosition - playerPosition;
                direction = Quaternion.Euler(0, 0, 90) * direction;
                GameObject warningBeam = Instantiate(warningBeamPrefab, playerPosition, Quaternion.identity);
                warningBeam.transform.right = direction.normalized;
                Destroy(warningBeam, warningTime);   
            }
            else
            {
                GameObject actualBeam = Instantiate(actualBeamPrefab, playerPosition, Quaternion.identity);
                actualBeam.transform.right = direction.normalized;

                float beamLength = Vector3.Distance(playerPosition, enemyPosition);
                actualBeam.transform.localScale = new Vector3(actualBeam.transform.localScale.x,beamLength,  actualBeam.transform.localScale.z);


                Destroy(actualBeam, actualBeamTime);
            }
        }
    }
}







