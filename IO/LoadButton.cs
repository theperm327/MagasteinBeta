using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public bool isHighlighting;
    public EditorSave EditorSaver;

    public TileGenerator TileGen;
    public int[,,] EmptyTiles = new int[66, 66, 66];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isHighlighting) & Input.GetButtonDown("Fire1"))
        {
            TileGen.TileGrid = EmptyTiles;

            EditorSaver.LoadBlocks();
            print("loaded");
        }

        isHighlighting = false;
    }
}
