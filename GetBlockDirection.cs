using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBlockDirection : MonoBehaviour
{
    public string EditorBlockFace; //String that holds face direction value of Block.
    public Camera TheCamera; //Camera to be used for Raycast that determines face direction.
    public GameObject HighLightCursor; //The block that Surrounds a selected block.




    // Start is called before the first frame update
    void Start()
    {
        
        TheCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        HighLightCursor = GameObject.FindGameObjectWithTag("HLS");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetEditorBlockFace();
    }

    //Determines the face orientation of the block being highlighted
    void GetEditorBlockFace()
    {
        RaycastHit hit;
        Ray ray = TheCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {


            //Determine Which Side of Cube The Ray Hits

            Vector3 incomingVec = hit.normal - Vector3.up;

            if (incomingVec == new Vector3(0, -1, -1))
            {
                EditorBlockFace = "South";
            }


            if (incomingVec == new Vector3(0, -1, 1))
            {
                EditorBlockFace = "North";
            }

            if (incomingVec == new Vector3(0, 0, 0))
            {
                EditorBlockFace = "Up";
            }

            if (incomingVec == new Vector3(0, -2, 0))
            {
                EditorBlockFace = "Down";
            }

            if (incomingVec == new Vector3(-1, -1, 0))
            {
                EditorBlockFace = "West";
            }

            if (incomingVec == new Vector3(1, -1, 0))
            {
                EditorBlockFace = "East";
            }

            Transform objectHit = hit.transform;

            if (objectHit.GetComponent<EditorBlockScipt>() == true)  //looks for an editorblock component
            {
                objectHit.GetComponent<EditorBlockScipt>().isHighlighting = true;
            }

            if (objectHit.GetComponent<NumberBlock>() == true)  //looks for a numberblock component
            {
                objectHit.GetComponent<NumberBlock>().isHighlighting = true;
            }

            if (objectHit.GetComponent<ClearSlateButton>() == true)  //looks for a ClearSlateButton component
            {
                objectHit.GetComponent<ClearSlateButton>().isHighlighting = true;
            }

            if (objectHit.GetComponent<LoadButton>() == true)  //looks for a LoadButton component
            {
                objectHit.GetComponent<LoadButton>().isHighlighting = true;
            }

            if (objectHit.GetComponent<SaveButton>() == true)  //looks for a SaveButton component
            {
                objectHit.GetComponent<SaveButton>().isHighlighting = true;
            }

            if (objectHit.GetComponent<NewGrid>() == true)  //looks for a NewGridButton component
            {
                objectHit.GetComponent<NewGrid>().isHighlighting = true;
            }

            if (objectHit.GetComponent<LoadMap>() == true)  //looks for a LoadMap component
            {
                objectHit.GetComponent<LoadMap>().isHighlighting = true;
            }



            HighLightCursor.transform.position = hit.transform.position; //Moves the Highlight block to Object being hit's location.
            HighLightCursor.transform.localScale = hit.transform.lossyScale + new Vector3(0.1f, 0.1f, 0.1f);


        }
    }




}
