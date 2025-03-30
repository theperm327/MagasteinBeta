using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSlateButton : MonoBehaviour
{
    public GameObject TileGenerator;

    public int RTimer;
    public bool isHighlighting;
    public bool isActivated;
    
    // Start is called before the first frame update
    void Start()
    {
        RTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((isHighlighting) & Input.GetButtonDown("Fire1"))
        {
            TileGenerator.GetComponent<TileGenerator>().Order66 = true;
            isActivated = true;
        }

        if (isActivated)
        {
            RTimer++;
    
            if (RTimer == 60)
            {
                TileGenerator.GetComponent<TileGenerator>().Order66 = false;
                RTimer = 0;
                isActivated = false;
            }
        }

        isHighlighting = false;
    }
}
