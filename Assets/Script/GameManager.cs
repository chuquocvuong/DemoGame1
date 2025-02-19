using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    public TextMeshProUGUI scroeText;
    public GameObject gameOverUi ;
    public GameObject gameWin;
    private bool isGameOver = false;
    private bool isGameWin = false;
    void Start()
    {
        updateScore();
        gameOverUi.SetActive(false);
        gameWin.SetActive(false);
    }

    public void Addscore(int point)
    {
        if (!isGameOver || !isGameWin)
        {
            score += point;
            updateScore();
        }
        
    }
    private void updateScore()
    {
        scroeText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
    }
    public void GameWin()
    {
        isGameWin = true;
        score = 0;
        Time.timeScale = 0;
        gameWin.SetActive(true);
    }
    public void Reset()
    {
        isGameOver =false;
        score = 0;
        updateScore() ;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}