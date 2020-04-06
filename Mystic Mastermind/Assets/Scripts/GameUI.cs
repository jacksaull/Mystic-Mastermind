using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI deathCount;
    public TextMeshProUGUI timerCount;

    public Health health;
    public Timer gameTimer;
    void Start()
    {
        health = GameObject.FindWithTag("Player").GetComponent<Health>();
        gameTimer = GameObject.FindWithTag("Portal").GetComponent<Timer>();
    }

    void Update()
    {
        deathCount.text = health.deaths.ToString();
        timerCount.text = gameTimer.timerText.text;
    }
}
