﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    private Text timerText;
    private float levelTime;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        ResetTimer();
    }

    public void ResetTimer()
    {
        levelTime = 150f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelTime >= 0.0)
        {
            levelTime -= Time.deltaTime;
            timerText.text = "Time Left:  " + Mathf.Round(levelTime);
        }
        else
        {

            SceneManager.LoadScene("GameOver");
        }
    }
}
