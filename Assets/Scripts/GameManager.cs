using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public bool isGameStarted = false;
    public bool isGameFinished = false;
    void Start()
    {
        
    }

    void Update()
    {//Start game with mouse click.
        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            isGameStarted = true;
            GameStart();
        }
    }
    public void NextLevel(string newGameLevel)
    {//Next level after finishing the game.
        SceneManager.LoadScene(newGameLevel);
    }
    void GameStart()
    {
        PlayerController.instance.GameStart();
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
}
