using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBlock : MonoBehaviour
{


    public string LetterNumber;
    public int NumberValue;
    public bool isHighlighting;
    public FileNameApp FNApp;


    public GameObject C_Highlight;
    public GameObject X_Highlight;
    public GameObject I_Highlight;

    public GameObject C_place;
    public GameObject X_place;
    public GameObject I_place;
  


    public GameObject FileNameStorage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHighlighting)
        {
            if (Input.GetButton("Fire1"))
            {
                if (LetterNumber == "c")
                {
                    C_Highlight.transform.position = this.transform.position;
                    FileNameStorage.GetComponent<FileNameApp>().C100 = NumberValue;
                    C_place.GetComponent<Renderer>().material.mainTexture = this.GetComponent<Renderer>().material.mainTexture;
                    FNApp.ButtonUpdater();
                    
                }

                if (LetterNumber == "x")
                {
                    X_Highlight.transform.position = this.transform.position;
                    FileNameStorage.GetComponent<FileNameApp>().X010 = NumberValue;
                    X_place.GetComponent<Renderer>().material.mainTexture = this.GetComponent<Renderer>().material.mainTexture;
                    FNApp.ButtonUpdater();
                }

                if (LetterNumber == "i")
                {
                    I_Highlight.transform.position = this.transform.position;
                    FileNameStorage.GetComponent<FileNameApp>().I001 = NumberValue;
                    I_place.GetComponent<Renderer>().material.mainTexture = this.GetComponent<Renderer>().material.mainTexture;
                    FNApp.ButtonUpdater();
                }
            }
        }
        isHighlighting = false;
    }
}
