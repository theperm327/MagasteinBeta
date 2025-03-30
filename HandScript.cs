using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScript : MonoBehaviour
{
    public Shader Unlitifier;
    //public Material[] HandMat;
    public int HandNumber = 1;
    public int toolNumber;
    public GameObject TextDisplayer;
    public GameObject HandChild;
    public GameObject OldHandChild;
    public TileGenerator EditorBlock;
    public FaceDirection FD;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.shader = Unlitifier;
        //this.GetComponent<Renderer>().material.color = new Color(2, 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        HandChild.transform.position = this.transform.position;
        HandChild.transform.rotation = this.transform.rotation;


        if (Input.GetButtonDown("TextureRight"))
        {
            HandNumber++;
            if (HandNumber > EditorBlock.EditorBlockPrefab.Length - 1)
                {
                HandNumber = 1;
                }
            OldHandChild = HandChild;
            HandChild = Instantiate(EditorBlock.EditorBlockPrefab[HandNumber], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            HandChild.GetComponent<BoxCollider>().isTrigger = true;
            HandChild.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(OldHandChild);

        }

        if (Input.GetButtonDown("TextureLeft"))
        {
            HandNumber--;
            if (HandNumber < 0)
                {
                HandNumber = EditorBlock.EditorBlockPrefab.Length - 1;
                }
            OldHandChild = HandChild;
            HandChild = Instantiate(EditorBlock.EditorBlockPrefab[HandNumber], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            HandChild.GetComponent<BoxCollider>().isTrigger = true;
            HandChild.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(OldHandChild);
            

        }

        if (Input.GetButtonDown("Fire2"))
            {
            HandNumber++;
            
            if (HandNumber > EditorBlock.EditorBlockPrefab.Length - 1) 
                { 
                HandNumber = 1; 
                }
            OldHandChild = HandChild;
            HandChild = Instantiate(EditorBlock.EditorBlockPrefab[HandNumber], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            HandChild.GetComponent<BoxCollider>().isTrigger = true;
            HandChild.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
            Destroy(OldHandChild);

        }

        if (Input.GetButtonDown("PaintBlock")) {
            toolNumber = 0;
            TextDisplayer.GetComponent<Text>().text = "Paint Blocks";
        }

        if (Input.GetButtonDown("AddBlock"))
        {
            toolNumber = 1;
            TextDisplayer.GetComponent<Text>().text = "Add New Block";
        }

        if (Input.GetButtonDown("DeleteBlock"))
        {
            toolNumber = 2;
            TextDisplayer.GetComponent<Text>().text = "Erase Blocks";
        }

        if (Input.GetButtonDown("LightAdd"))
        {
            toolNumber = 1337;
            TextDisplayer.GetComponent<Text>().text = "Add Light";
        }

    }
    
}
