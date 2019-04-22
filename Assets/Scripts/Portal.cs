using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Portal : MonoBehaviour {

    public string destination;
    public SpriteRenderer rend;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<SpriteRenderer>();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("key"))
        {
            rend.enabled = true;
        }
        else if (col.gameObject.CompareTag("Player") && rend.enabled == true)
        {
            print("please fucking god");
            SceneManager.LoadScene(destination);
        }
    }
}