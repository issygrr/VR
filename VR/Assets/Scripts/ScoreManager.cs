using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
   // public GameObject winUI;
    // singleton to allow the pickup script access
    public static ScoreManager Instance { get; private set; }

    private void Update()
    {
        UpdateScoreTxt();
        Win();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddPoints(int points)
    {
        score += points;
    }
    public int GetScore()
    {
        return score;
    }
    public void UpdateScoreTxt()
    {
        if (scoreText != null)
        {
            scoreText.text = "Balls collected: " + score.ToString();
        }
    }
    public void Win()
    {
        if(score >= 20)
        {
            //winUI.SetActive(true);
            SceneManager.LoadScene(1);
        }
    }

    
}
