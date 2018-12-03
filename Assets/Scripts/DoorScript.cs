using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=X-lW15kaZtM

public class DoorScript : MonoBehaviour {

    public Animation openDoor;
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKey (KeyCode.E))
        {
            openDoor.Play();
        }
	}
}
