using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float totalTime = 120f;
    private float currentTime;
    public bool timeStart = false;
    public Text countDowntText;
    public GameObject gameOverText;
    public GameObject lightObj;
    void Start()
    {
        gameOverText.SetActive(false);
        lightObj.SetActive(true);
        currentTime = totalTime;
    }

    // Update is called once per frame
    public void Update()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        if (timeStart == true)
        {
            if (currentTime <= 0f)
            {
                Death();

                enabled = false;
            }
            else
            {
                currentTime -= Time.deltaTime;

                countDowntText.text = Mathf.CeilToInt(currentTime).ToString();
            }
        }
    }
    public void TimeStarter()
    {
        timeStart = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Death()
    {
        gameOverText.SetActive(true);
        lightObj.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
