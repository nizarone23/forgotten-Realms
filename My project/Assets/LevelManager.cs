using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    Vector2 playerInitPosition;
    public GameObject player;

    void Start() 
    {
        playerInitPosition = player.transform.position;
    }
    public void Restart()
    {
        player.transform.position = playerInitPosition;
        FindObjectOfType<PlayerHealth>().MaxHealth();
    }



}
