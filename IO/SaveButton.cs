using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public bool isHighlighting;
    public EditorSave EditorSaver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isHighlighting) & Input.GetButtonDown("Fire1"))
        {
            EditorSaver.SaveBlocks();
            print("saved");
        }


        isHighlighting = false;

    }
}
