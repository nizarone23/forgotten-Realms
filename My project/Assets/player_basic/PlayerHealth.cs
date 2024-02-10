using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int currenthealth;
    public int maxHealth = 15;


    public Image fillImage;


    //public float RemainingHealthPercentage
    //{
    //    get
    //    {
    //        return currenthealth / maxHealth;
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
    }

    public void TakeDamadge(int amount)
    {
        currenthealth -= amount;


        fillImage.fillAmount = (float)currenthealth / maxHealth;

        if (currenthealth <=0)
        {
           Destroy(gameObject);
        }
        
    }

   

   
}
