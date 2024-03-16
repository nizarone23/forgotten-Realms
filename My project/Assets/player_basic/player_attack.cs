using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public GameObject sword;

    public float spawnDistance = 1;
    public float attackMoveSpeed = 5;

    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newSword = Instantiate(sword, new Vector2(transform.position.x, transform.position.y) + movement.lastForward * spawnDistance, transform.rotation);
            newSword.GetComponent<Rigidbody2D>().velocity = movement.lastForward * attackMoveSpeed;
        }
    }
}
