using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public int[,,] TileGrid = new int [257,26,257];
    //public BlockThing[,,] TileGrid2 = new BlockThing[66, 66, 66];
    public Material[] TileSuit;
    public GameObject EditorBlock;
    public GameObject[] EditorBlockPrefab;
    

    public int CheckX;
    public int CheckY;
    public int CheckZ;
    public int CheckXYZ;

    public int RowLength;
    public int CollumnLength;

    public string testmessage;

    public bool Order66; //Destroy all Tile Blocks;
     
    // Start is called before the first frame update
    void Start()
    {
        SquareGen();
    }

    // Update is called once per frame
    void Update()
    {
        CheckXYZ = TileGrid[CheckX, CheckY, CheckZ];
    }

    public void SquareGen()
    {
        for (int TileGenX = 0; TileGenX < RowLength; TileGenX++)
        {
            for (int TileGenZ = 0; TileGenZ < CollumnLength; TileGenZ++)
                
            {       
                    EditorBlock = Instantiate(EditorBlockPrefab[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    EditorBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileGenX;
                    EditorBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileGenZ;
            }
        }
    }
        
    



}
