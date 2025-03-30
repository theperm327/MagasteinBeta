using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EditorSave: MonoBehaviour {

	public TileGenerator TilegenGuy;
	public GameObject FileNameApp;
    public GameObject EditorBlock;
    public GameObject EditorBlockPrefab;
    public GameObject TheHand;
    public int filename;
	public string filenameString;
	public int[,,] TileGridHere = new int [66,66,66];
    public string testmessage;

	void Update()
	{
	filename = FileNameApp.GetComponent<FileNameApp>().CXItotal;
	filenameString = "Saves/" + filename + ".prm";
    testmessage = TilegenGuy.testmessage;
    
	}
	
	public void SaveBlocks()
        {
            filename = FileNameApp.GetComponent<FileNameApp>().CXItotal;
            filenameString = "Saves/" + filename + ".prm";

            BinaryFormatter bf = new BinaryFormatter();

        if (!File.Exists(filenameString))
        {
            FileStream file = File.Open(filenameString, FileMode.CreateNew);

            TileData data = new TileData();

            // Add new persistent variables to be saved here.
            data.TileGridB = TilegenGuy.TileGrid;
            data.testmessage = TilegenGuy.testmessage;
            bf.Serialize(file, data);
            file.Close();
            print("Saved");
        }

        if (File.Exists(filenameString))
        {
            FileStream file = File.Open(filenameString, FileMode.Open);

            TileData data = new TileData();

            // Add new persistent variables to be saved here.
            data.TileGridB = TilegenGuy.TileGrid;
            data.testmessage = TilegenGuy.testmessage;
            bf.Serialize(file, data);
            file.Close();
            print("Saved");
        }


    }

    public void LoadBlocks()
    {
        //filename = FileNameApp.GetComponent<FileNameApp>().CXItotal;
        //filenameString = "Saves/" + filename + ".prm";

        if (File.Exists(filenameString))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filenameString, FileMode.Open);
            TileData data = (TileData)bf.Deserialize(file);
            file.Close();

            // Add new persistent variables to be loaded here.

            TilegenGuy.TileGrid = data.TileGridB;
            TilegenGuy.testmessage = data.testmessage;
        }
        print("loaded");
        SquareGenB();
    }

    void SquareGenB()
    {
        for (int TileGenX = 0; TileGenX < 66; TileGenX++)
        {
            for (int TileGenZ = 0; TileGenZ < 66; TileGenZ++)

            {
                    int suitnumberA = TilegenGuy.TileGrid[TileGenX, 0, TileGenZ];
                    if (suitnumberA == 0) { suitnumberA = 0; }
                    EditorBlock = Instantiate(TilegenGuy.EditorBlockPrefab[suitnumberA], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    EditorBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileGenX;
                    EditorBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileGenZ;

            }
        }

        for (int TileGenX = 1; TileGenX < 66; TileGenX++)
        {
            for (int TileGenY = 1; TileGenY < 66; TileGenY++)
                for (int TileGenZ = 1;  TileGenZ < 66; TileGenZ++)
                {
                    {
                        if (TilegenGuy.TileGrid[TileGenX, TileGenY, TileGenZ] > 0)
                        {
                            int suitnumberA = TilegenGuy.TileGrid[TileGenX, TileGenY, TileGenZ];
                            EditorBlock = Instantiate(TilegenGuy.EditorBlockPrefab[suitnumberA], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                            EditorBlock.GetComponent<EditorBlockScipt>().TileXCoord = TileGenX;
                            EditorBlock.GetComponent<EditorBlockScipt>().TileYCoord = TileGenY;
                            EditorBlock.GetComponent<EditorBlockScipt>().TileZCoord = TileGenZ;
                            
                        }
                    }
                }
        }


    }



    [Serializable]
		class TileData
        {
		
		
		// Add new variables for loading and saving here.
		public int[,,] TileGridB;
        public string testmessage;
	    }






}
