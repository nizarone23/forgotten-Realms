using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{


    public int currenthealth;
    public int maxHealth = 15;
    public Image fillImage;
    private bool heal = true;
    public GameObject[] slots;


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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) &&  !(currenthealth == maxHealth))
        {
            //heal = true;

            foreach (GameObject slot in slots)
            {
                if (slot && slot.transform.childCount > 0 && heal)
                {
                    GameObject potion = slot.transform.GetChild(0).gameObject;
                    if (potion.tag == "inventory_potion")
                    {
                        //GameObject item = GameObject.FindWithTag("inventory_potion");
                        TakeDamadge(-10);   
                        Destroy(potion);
                        //heal = false;
                        break;
                    }
                }
            }
        }
    }
    public void TakeDamadge(int amount)
    {
        currenthealth -= amount;

        if (currenthealth>= maxHealth)
        {
            currenthealth = maxHealth;
        }

        Debug.Log("amount: " + amount + ", currenthealth: " + currenthealth);

        if (currenthealth <=0)
        {
            FindObjectOfType<LevelManager>().Restart();
        }
        
        fillImage.fillAmount = (float)currenthealth / maxHealth;

    }

    public void MaxHealth()
    {
        currenthealth = maxHealth;
    }
    



}
