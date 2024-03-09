using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private Transform Player;
    private float x = 0.05f;
    private float y = 0.04f;
    private float z = 1.0f;
   
    

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    public void addHealth(float playerHP)
    {
        playerHP += 10.0f;
    }


    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y+1);
        GameObject spawned = Instantiate(item, playerPos, Quaternion.identity);
        spawned.transform.localScale = new Vector3(x,y,z);
    }
 
}
