 using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject parentObj;
    public Inventory inventory;
    public int i;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void Drop()
    {
        
        foreach (Transform child in parentObj.transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            Destroy(child.gameObject);
        }
    }


}
