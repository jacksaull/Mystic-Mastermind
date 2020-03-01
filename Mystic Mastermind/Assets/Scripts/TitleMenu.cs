using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    public GameObject titleScreen; //The Title Menu
    public AudioSource startSound; //Sound when game starts
    public AudioSource ambientMusic;
    public Animator fadeIn;

    void Start()
    {
        titleScreen.SetActive(true);
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        fadeIn.SetBool("isStarted", true);
        titleScreen.SetActive(false);
        startSound.Play();
        ambientMusic.Stop();

        Invoke("Transition", 6.2f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Transition()
    {
        SceneManager.LoadScene("Tutorial - Wind, Earth, Fire");
    }
}
