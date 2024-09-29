using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// https://www.youtube.com/watch?v=hxpUk0qiRGs

public class TimerScript : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn;

    public TextMeshProUGUI timerTxt;


    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);

            }
            else
            {
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        timerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
