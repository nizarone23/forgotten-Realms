using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
{
    public float despawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Despawn", despawnTime);
    }

    // Update is called once per frame
    void Despawn()
    {
        Destroy(gameObject);
    }
}
