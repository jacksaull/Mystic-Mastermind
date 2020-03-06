using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject main; //Pause Menu - Main Section
    public GameObject sound; //Pause Menu - Sound Section
    public GameObject pauseMenu; //The Pause Menu Canvas

    public AudioSource effects; //Source to play Menu sounds
    public AudioSource wake; //Source to play on awakening
    public AudioClip pageTurn;
    public AudioClip bookOpen;
    public AudioClip bookClose;

    public SpellManager spellManager;
    void Start()
    {
        wake.Play();

        pauseMenu.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        sound.gameObject.SetActive(false);
        Time.timeScale = 1;

        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (pauseMenu.gameObject.activeSelf == false)
            {
                effects.PlayOneShot(bookOpen);
                wake.Pause();

                pauseMenu.gameObject.SetActive(true);
                main.gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                spellManager.paused = true;
            }
            else
            {
                effects.PlayOneShot(bookClose);
                wake.UnPause();

                pauseMenu.gameObject.SetActive(false);
                main.gameObject.SetActive(false);
                sound.gameObject.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                spellManager.paused = false;
            }
        }
    }

    public void Continue()
    {
        effects.PlayOneShot(bookClose);
        wake.UnPause();

        pauseMenu.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        sound.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        spellManager.paused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void LoadSound()
    {
        effects.PlayOneShot(pageTurn);
        main.gameObject.SetActive(false);
        sound.gameObject.SetActive(true);
    }

    public void QuitSound()
    {
        effects.PlayOneShot(pageTurn);
        main.gameObject.SetActive(true);
        sound.gameObject.SetActive(false);
    }
}
