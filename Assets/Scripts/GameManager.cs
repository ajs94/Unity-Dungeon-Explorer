using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    North, East, South, West
};

public class GameManager : MonoBehaviour {

    public int score = 0;

    public Text scoreText;

    public BoardManager boardScript;

    // Use this for initialization
    void Awake()
    {
        /*if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        */
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupBoard(0);
    }

    public void AddToScore(int numToAdd)
    {
        score += numToAdd;
        print(score.ToString());
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
