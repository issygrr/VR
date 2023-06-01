using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float totalTime = 120f;
    private float currentTime;
    public bool timeStart = false;
    public Text countDowntText;
    void Start()
    {
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        if (timeStart == true)
        {
            if (currentTime <= 0f)
            {
                // enemy attack

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
}
