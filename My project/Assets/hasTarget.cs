using UnityEngine;

public class Wave : MonoBehaviour
{
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

    bool shooting = false;
    bool isWarningBeam = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HasTarget = chargeZone.detectedColliders.Count > 0;

        if (HasTarget && !shooting)
        {
            InvokeRepeating("StartAttackSequence", 0, 7f); // 7s = 2s (warning) + 2s (actual) + 3s (rest)
            shooting = true;
        }
        else if (!HasTarget && shooting)
        {
            CancelInvoke("StartAttackSequence");
            shooting = false;
            isWarningBeam = true;
        }
    }

    void StartAttackSequence()
    {
        if (isWarningBeam)
        {
            animator.SetBool("WarnBeam", true);
            Invoke("FireBeam", warningTime);
        }
        else
        {
            Invoke("FireBeam", 0);
        }

        isWarningBeam = !isWarningBeam;
    }

    void FireBeam()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 enemyPosition = chargeZone.detectedColliders[0].transform.position;

            Vector2 direction = enemyPosition - playerPosition;

            if (isWarningBeam)
            {
                GameObject warningBeam = Instantiate(warningBeamPrefab, playerPosition, Quaternion.identity);
                warningBeam.transform.right = direction.normalized;
                Destroy(warningBeam, warningTime);
            }
            else
            {
                GameObject actualBeam = Instantiate(actualBeamPrefab, playerPosition, Quaternion.identity);
                actualBeam.transform.right = direction.normalized;

                float beamLength = Vector3.Distance(playerPosition, enemyPosition);
                actualBeam.transform.localScale = new Vector3(beamLength, actualBeam.transform.localScale.y, actualBeam.transform.localScale.z);

                Rigidbody2D rb = actualBeam.GetComponent<Rigidbody2D>();
                rb.velocity = direction.normalized * beamSpeed;

                Destroy(actualBeam, actualBeamTime);
            }
        }
    }
}