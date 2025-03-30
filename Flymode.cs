using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flymode : MonoBehaviour
{
    public bool isFlying = false;
    public Chunk Dandy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -300 ){
            this.transform.position = new Vector3(1, 1, -22.2f);
        }
        


        if (Input.GetButtonDown("FlyToggle")){ isFlying = !isFlying;}

        if (!isFlying) {
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Jump>().isFlying = false;
        }

        if (isFlying)
        {

            this.GetComponent<Jump>().isFlying = true;

            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            if (Input.GetButton("FlyUp"))
            {
                this.transform.position = this.transform.position + new Vector3(0, 0.2f, 0);
            }

            if (Input.GetButton("FlyDown"))
            {
                this.transform.position = this.transform.position + new Vector3(0, -0.12f, 0);
            }


        }


    }
}
