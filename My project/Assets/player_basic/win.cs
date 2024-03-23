using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    
    public Image WINNTEXT;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            WINNTEXT.gameObject.SetActive(true);
        }
    }
}
