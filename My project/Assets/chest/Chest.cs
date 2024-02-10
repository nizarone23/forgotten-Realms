using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    
    [SerializeField]
    private Sprite openSprite, closedSprite;

    public GameObject player;
    public float distance;
    private bool isOpen;
    public void Interact()
    {
        if (isOpen)
        {
            StopInteract();
        }
        else
        {
            isOpen = true;
            spriteRenderer.sprite = openSprite;
        }
    }

    public void StopInteract()
    {

    }
    
    

   void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if ((Input.GetKeyDown(KeyCode.E)) && (distance<=6))
        {
            Interact();
        }
    }
}

internal interface IInteractable
{
}