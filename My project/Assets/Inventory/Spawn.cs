using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private Transform Player;

    private void Start()
    {
        player = Player.GetComponent<Transform>().transform;

    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y+3);
        Instantiate(item, playerPos, Quaternion.identity);
    }
 
}
