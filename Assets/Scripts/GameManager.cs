using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public enum Direction
{
    North, East, South, West
};

public class GameManager : MonoBehaviour {

    public int score = 0;

    public Text scoreText;

    public GameObject HUD;
    public BoardManager boardScript;

    // Use this for initialization
    void Awake()
    {
        /*if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        */

        /*
        XRSettings.eyeTextureResolutionScale = 1;
        XRSettings.renderViewportScale = .5f;
        */

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupBoard(0);
        HUD.SetActive(true);
    }

    public void AddToScore(int numToAdd)
    {
        score += numToAdd;
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
