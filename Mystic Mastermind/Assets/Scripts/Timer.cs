using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isPlaying;
    float gameTimer;
    public TextMeshProUGUI timerText;
    void Start()
    {
        isPlaying = true;
    }

    void Update()
    {
        if (isPlaying)
        {
            gameTimer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(gameTimer / 60F);
            int seconds = Mathf.FloorToInt(gameTimer % 60F);
            int milliseconds = Mathf.FloorToInt((gameTimer * 100F) % 100F);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }
    }
}
