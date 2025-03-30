using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorBlockScipt : MonoBehaviour
{

    public bool isHighlighting = false; //Is the block being HighLighted?
    
    public int TileXCoord; //The Block's X Coordinates.
    public int TileYCoord; //The Block's Y Coordinates.
    public int TileZCoord; // The Block's Z Coordinates.
    public Vector3 TileGenSpot; //The Vector3 location + offset of the Block.
    public Vector3 TileTimes3;
    public GameObject TileGeneratorObject; //The TileGenerator as GameObject
    

    public int SuitNumber;  // Tells block what type it is.
    public Shader shaderCache; //Stores Old Shader Value before Highlight.
    public Shader unlitMaker; //Stores highlighting shader.

    public GameObject TheHand; //The hand which holds the information on what Blocktype is being used.
    public TileGenerator EditorBlock; //The TileGenerators tile generation component.
    public int toolNumber;  //The tool type being used.

    public GameObject[] NewBlock; // New Block Prefab.
    public GameObject AddBlock; // Block to be generated in the future.

    public GameObject NewLightPrefab; //New Light Prefab.
    public GameObject Newlight; // Light to be generated in the future.

    public string EditorBlockFace; //String that holds face direction value of Block.
    public GameObject TheCameraObject; // References the Camera Object.

    public FaceDirection ebf;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        TheHand = GameObject.FindGameObjectWithTag("Hand");
        TheCameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        EditorBlock = GameObject.FindGameObjectWithTag("EditorBlock").GetComponent<TileGenerator>();//References the Editor Block to Change it's data
        TileGeneratorObject = GameObject.FindGameObjectWithTag("EditorBlock"); //References the gameObject of the editor Block for other stuff

        TileGenSpot = new Vector3(TileXCoord * 3, TileYCoord *3, TileZCoord * 3);
       
        this.transform.position = TileGeneratorObject.transform.position + TileGenSpot;

    }

    // Update is called once per frame
    void Update()
    {
        if (EditorBlock.Order66 == true)
        {
            Destroy(gameObject);
        }

        //Calls Raycast to determine block direction.
        GetEditorBlockFace();

         if (ebf == FaceDirection.Down)
        {
            //print ("1");
        }
        
        //Gets Tool being used from Hand
        toolNumber = TheHand.GetComponent<HandScript>().toolNumber;


        //Add Light Tool. For Editing only. Does not save light coords.
        if (isHighlighting & toolNumber == 1337 & Input.GetButtonDown("Fire1"))
        {
            Newlight = Instantiate(NewLightPrefab, TheHand.transform.position, Quaternion.identity);
        }


        
        //Paint Block tool. 
        if (isHighlighting & Input.GetButton("Fire1") & (toolNumber == 0))
        {
            SuitNumber = TheHand.GetComponent<HandScript>().HandNumber;
            AddBlock = Instantiate(EditorBlock.EditorBlockPrefab[SuitNumber], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            AddBlock.GetComponent<EditorBlockScipt>().isHighlighting = false;
            AddBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileXCoord;
            AddBlock.GetComponent<EditorBlockScipt>().TileYCoord = TileYCoord;
            AddBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileZCoord;
            EditorBlock.TileGrid[TileXCoord, TileYCoord, TileZCoord] = SuitNumber;
            Destroy(gameObject);
        }


        //Add New Block Tool
        if (isHighlighting & Input.GetButtonDown("Fire1") & (toolNumber == 1))
        {

            if ((TileXCoord > 0) & (TileXCoord < 255) & (TileYCoord > -1) & (TileYCoord < 25) & (TileZCoord > 0) & (TileZCoord < 255))
            {


                if (EditorBlockFace == "Up")
                {
                    if (EditorBlock.TileGrid[TileXCoord, TileYCoord + 1, TileZCoord] == 0)
                    {
                        SuitNumber = TheHand.GetComponent<HandScript>().HandNumber;
                        AddBlock = Instantiate(EditorBlock.EditorBlockPrefab[SuitNumber], new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
                        AddBlock.GetComponent<EditorBlockScipt>().isHighlighting = false;
                        AddBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileXCoord;
                        AddBlock.GetComponent<EditorBlockScipt>().TileYCoord = TileYCoord + 1;
                        AddBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileZCoord;
                        EditorBlock.TileGrid[TileXCoord, TileYCoord + 1, TileZCoord] = SuitNumber;
                    }
                }

                if (EditorBlockFace == "Down")
                {
                    if (EditorBlock.TileGrid[TileXCoord, TileYCoord - 1, TileZCoord] == 0)
                    {
                        SuitNumber = TheHand.GetComponent<HandScript>().HandNumber;
                        AddBlock = Instantiate(EditorBlock.EditorBlockPrefab[SuitNumber], new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z), Quaternion.identity);
                        AddBlock.GetComponent<EditorBlockScipt>().isHighlighting = false;
                        AddBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileXCoord;
                        AddBlock.GetComponent<EditorBlockScipt>().TileYCoord = TileYCoord - 1;
                        AddBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileZCoord;
                        EditorBlock.TileGrid[TileXCoord, TileYCoord - 1, TileZCoord] = SuitNumber;
                    }
                }

                if (EditorBlockFace == "West" & (TileXCoord > 1))
                {
                    if (EditorBlock.TileGrid[TileXCoord - 1, TileYCoord, TileZCoord] == 0)
                    {
                        SuitNumber = TheHand.GetComponent<HandScript>().HandNumber;
                        AddBlock = Instantiate(EditorBlock.EditorBlockPrefab[SuitNumber], new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        AddBlock.GetComponent<EditorBlockScipt>().isHighlighting = false;
                        AddBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileXCoord - 1;
                        AddBlock.GetComponent<EditorBlockScipt>().TileYCoord = TileYCoord;
                        AddBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileZCoord;
                        EditorBlock.TileGrid[TileXCoord - 1, TileYCoord, TileZCoord] = SuitNumber;
                    }
                }

                if (EditorBlockFace == "East" & (TileXCoord < 256))
                {
                    if (EditorBlock.TileGrid[TileXCoord + 1, TileYCoord, TileZCoord] == 0)
                    {
                        SuitNumber = TheHand.GetComponent<HandScript>().HandNumber;
                        AddBlock = Instantiate(EditorBlock.EditorBlockPrefab[SuitNumber], new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                        AddBlock.GetComponent<EditorBlockScipt>().isHighlighting = false;
                        AddBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileXCoord + 1;
                        AddBlock.GetComponent<EditorBlockScipt>().TileYCoord = TileYCoord;
                        AddBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileZCoord;
                        EditorBlock.TileGrid[TileXCoord + 1, TileYCoord, TileZCoord] = SuitNumber;
                    }
                }

                if (EditorBlockFace == "North" & (TileZCoord < 256))
                {
                    if (EditorBlock.TileGrid[TileXCoord, TileYCoord, TileZCoord + 1] == 0)
                    {
                        SuitNumber = TheHand.GetComponent<HandScript>().HandNumber;
                        AddBlock = Instantiate(EditorBlock.EditorBlockPrefab[SuitNumber], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1), Quaternion.identity);
                        AddBlock.GetComponent<EditorBlockScipt>().isHighlighting = false;
                        AddBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileXCoord;
                        AddBlock.GetComponent<EditorBlockScipt>().TileYCoord = TileYCoord;
                        AddBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileZCoord + 1;
                        EditorBlock.TileGrid[TileXCoord, TileYCoord, TileZCoord + 1] = SuitNumber;
                    }
                }

                if (EditorBlockFace == "South" & (TileZCoord > 1))
                {
                    if (EditorBlock.TileGrid[TileXCoord, TileYCoord, TileZCoord - 1] == 0)
                    {
                        SuitNumber = TheHand.GetComponent<HandScript>().HandNumber;
                        AddBlock = Instantiate(EditorBlock.EditorBlockPrefab[SuitNumber], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1), Quaternion.identity);
                        AddBlock.GetComponent<EditorBlockScipt>().isHighlighting = false;
                        AddBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileXCoord;
                        AddBlock.GetComponent<EditorBlockScipt>().TileYCoord = TileYCoord;
                        AddBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileZCoord - 1;
                        EditorBlock.TileGrid[TileXCoord, TileYCoord, TileZCoord - 1] = SuitNumber;
                    }
                }
            }
        }
        
        //Destroy Block Tool
        if (isHighlighting & Input.GetButtonDown("Fire1") & (toolNumber == 2) & TileYCoord > 0)
        {
                EditorBlock.TileGrid[TileXCoord, TileYCoord, TileZCoord] = 0;
                Destroy(gameObject);
        }

        isHighlighting = false; //Deselects unselected blocks.
    }


    //Determines the face orientation of the block being highlighted
    void GetEditorBlockFace()
    {
        EditorBlockFace = TheCameraObject.GetComponent<GetBlockDirection>().EditorBlockFace;
    }








}