using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileNameApp : MonoBehaviour
{
    public int C100;
    public int X010;
    public int I001;

    public int CXItotal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ButtonUpdater()
    {
        CXItotal = (C100 * 100) + (X010 * 10) + I001;
    }


}
