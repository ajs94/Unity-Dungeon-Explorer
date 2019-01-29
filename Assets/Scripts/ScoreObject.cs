using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour {

    private GameManager gameScript;

    public int objectWorth = 10;
    
    // initialize the reference to the GameManager script
    void Start ()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // add this object's score worth to the total score
    void OnMouseDown()
    {
        gameScript.AddToScore(objectWorth);
    }
}
