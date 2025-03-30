using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{
    public bool isHighlighting;
    public EditorSave EditorSaver;

    public TileGenerator TileGen;
    public int[,,] EmptyTiles = new int[66, 66, 66];
    public int MapNumber;
    public bool isUtilized;


    // Start is called before the first frame update
    void Start()
    {
        if (isUtilized)
        {
            TileGen.TileGrid = EmptyTiles;

            EditorSaver.filenameString = "Saves/" + MapNumber + ".prm";
            EditorSaver.LoadBlocks();

            print("map " + MapNumber +  " loaded");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((isHighlighting) & Input.GetButtonDown("Fire1"))
        {
            
        }

        isHighlighting = false;
    }
}