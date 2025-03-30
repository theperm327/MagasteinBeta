using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public bool isHighlighting = false;
    public Color colorCache;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            colorCache = this.GetComponent<Renderer>().material.color;
            this.GetComponent<Renderer>().material.color = new Color(2, 2, 2);
            isHighlighting = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            this.GetComponent<Renderer>().material.color = colorCache;
                
                
            isHighlighting = false;
        }
    }



}
