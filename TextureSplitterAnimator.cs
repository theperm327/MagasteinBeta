using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSplitterAnimator : MonoBehaviour
{
    public float uvAnimationTileX = 8f; //Here you can place the number of columns of your sheet.                       
    public float uvAnimationTileY = 8f; //Here you can place the number of rows of your sheet. 
    public float YZFraction;
    public int[,] Split = new int[8, 8];
    public int TileNameX = 1;
    public int TileNameY = 1;
    public int TileNameZ = 1;
    public int TileSetNumber;
    public Vector2 offset;
    public bool turnOn;





    // Start is called before the first frame update
    void Start()
    {
        TileNameX = this.GetComponent<EditorBlockScipt>().TileXCoord;
        TileNameY = this.GetComponent<EditorBlockScipt>().TileYCoord;
        TileNameZ = this.GetComponent<EditorBlockScipt>().TileZCoord;
        uvAnimationTileX = 8;
        uvAnimationTileY = 8;
        YZFraction = 1 / uvAnimationTileY;
        TilePosition();
    }

    // Update is called once per frame
    void Update()
    {
        offset = offset + (new Vector2(Time.deltaTime, 0) * 0.1f);
        this.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }






    void TilePosition()
    {

        Vector2 size = new Vector2(1.0f / uvAnimationTileX, 1.0f / uvAnimationTileY);

        //offset = new Vector2(1 - size.x - TileNameX * size.x, (1 - size.y - TileNameY * size.y) * (1 - size.y - TileNameZ * size.y ));
        offset = new Vector2(1 - size.x - TileNameX * size.x + Time.fixedTime * 0.1f, (1 - size.y - TileNameY * size.y) + (1 - size.y - TileNameZ * size.y) - YZFraction);

        this.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);

        this.GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
    }


















}