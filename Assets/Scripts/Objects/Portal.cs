using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Portal : MonoBehaviour {

    public string destination;
    public SpriteRenderer rend;
    public AudioSource loopSound;
    public AudioSource activateSound;
    public AudioSource enterSound;

    // the script for the enter/exit portal behavior
    void Start ()
    {
        rend = GetComponent<SpriteRenderer>();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("key"))
        {
            col.gameObject.SetActive(false);
            rend.enabled = true;
            activateSound.Play();
            loopSound.Play();
        }
        else if (col.gameObject.CompareTag("Player") && rend.enabled == true)
        {
            enterSound.Play();
            SceneManager.LoadScene(destination);
        }
        else if (!col.gameObject.CompareTag("Player") && rend.enabled == true)
        {
            enterSound.Play();
            col.gameObject.SetActive(false);
        }
    }
}