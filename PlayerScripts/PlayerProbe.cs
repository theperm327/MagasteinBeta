using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProbe : MonoBehaviour
{
    public FaceDirection FD;
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
        probe();
    }

    void probe()
    {
        RaycastHit hit;
        Ray ray = TheCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {


            //Determine Which Side of polygon The Ray Hits

            Vector3 incomingVec = hit.normal - Vector3.up;

            if (incomingVec == new Vector3(0, -1, -1))
            {
                FD = FaceDirection.South;
            }


            if (incomingVec == new Vector3(0, -1, 1))
            {
                FD = FaceDirection.North;
            }

            if (incomingVec == new Vector3(0, 0, 0))
            {
                FD = FaceDirection.Up;
            }

            if (incomingVec == new Vector3(0, -2, 0))
            {
                FD = FaceDirection.Down;
            }

            if (incomingVec == new Vector3(-1, -1, 0))
            {
                FD = FaceDirection.West;
            }

            if (incomingVec == new Vector3(1, -1, 0))
            {
                FD = FaceDirection.East;
            }

            Transform objectHit = hit.transform;

            if (objectHit.GetComponent<Interactable>() == true)  //looks for an editorblock component
            {
                objectHit.GetComponent<Interactable>().IsHighlighted = true;
                objectHit.GetComponent<Interactable>().FD = FD;

                HighLightCursor.transform.position = hit.transform.position; //Moves the Highlight block to Object being hit's location.
                HighLightCursor.transform.localScale = hit.transform.lossyScale + new Vector3(0.1f, 0.1f, 0.1f);


            }
        }
    }
}
