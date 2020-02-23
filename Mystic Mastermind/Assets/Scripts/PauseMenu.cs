using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject main; //Pause Menu - Main Section
    public GameObject sound; //Pause Menu - Sound Section
    public GameObject pauseMenu;

    public SpellManager spellManager;
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        sound.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (pauseMenu.gameObject.activeSelf == false)
            {
                pauseMenu.gameObject.SetActive(true);
                main.gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;

                spellManager.paused = true;
            }
            else
            {
                pauseMenu.gameObject.SetActive(false);
                main.gameObject.SetActive(false);
                sound.gameObject.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;

                spellManager.paused = false;
            }
        }
    }

    public void Continue()
    {
        pauseMenu.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        sound.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

        spellManager.paused = false;
    }

    public void Quit()
    {
        //SceneManager.LoadScene("Title Screen");
    }

    public void LoadSound()
    {
        main.gameObject.SetActive(false);
        sound.gameObject.SetActive(true);
    }

    public void QuitSound()
    {
        main.gameObject.SetActive(true);
        sound.gameObject.SetActive(false);
    }
}
