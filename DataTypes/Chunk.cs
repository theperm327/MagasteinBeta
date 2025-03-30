using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public MapAddress ChunkLocation;
    public int[,,] ChunkData = new int[8, 8, 8];
}
