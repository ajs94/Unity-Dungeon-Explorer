using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SoundWalking : MonoBehaviour {

    public Rigidbody myCharacter;
    public AudioSource mySound;

	// Use this for initialization
	void Start ()
    {
        myCharacter = GetComponent<Rigidbody>();
    }
	/*
	void Update ()
    {
        print(myCharacter.velocity.magnitude);

        Vector3 v = myCharacter.velocity;
        v.y = 0;

        if (v.magnitude > Mathf.Abs(0.00002f) &&
            mySound.isPlaying == false)
        {
            mySound.Play();
        }
	}
    */
    private void TouchpadPressed(object sender)
    {
    }
}
