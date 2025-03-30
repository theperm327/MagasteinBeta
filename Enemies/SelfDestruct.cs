using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public bool isOriginal;
    public float DeathTimer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOriginal)
        {
            Destroy(gameObject, DeathTimer);
        }
    }
}
