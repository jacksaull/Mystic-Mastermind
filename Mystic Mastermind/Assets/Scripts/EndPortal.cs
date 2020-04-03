using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class EndPortal : MonoBehaviour
{
    public GameObject endScreen; //The End Screen Canvas
    public TextMeshProUGUI levelTitle; //Title of current Level
    public TextMeshProUGUI body; //The main body text of End Screen
    public TextMeshProUGUI deathsUI; //Deaths in UI
    public string bodyText; //The text to fill the body text

    public string level; //Next level to load

    public SpellManager spellManager;
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;
    public Health health;
    public Timer gameTimer;

    public AudioSource portalEffect; //Portals Ambient Effect
    public AudioSource musicPlayer; //The Music Audiosource of the Player
    public AudioClip musicClip; //Clip to become current Music
    void Start()
    {
        endScreen.SetActive(false);
        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        mouseLook = GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>();
        health = GameObject.FindWithTag("Player").GetComponent<Health>();
        gameTimer = GetComponent<Timer>();

        levelTitle.text = SceneManager.GetActiveScene().name;
        body.text = bodyText;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            gameTimer.isPlaying = false;
            endScreen.SetActive(true);
            spellManager.enabled = false;
            playerMovement.enabled = false;
            mouseLook.enabled = false;

            deathsUI.text = health.deaths.ToString();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            portalEffect.Stop();
            StartCoroutine(SoundFader.StartFade(musicPlayer, 5, 0));
            Invoke("MusicChange", 5);
        }
    }

    void MusicChange()
    {
        musicPlayer.clip = musicClip;
        musicPlayer.Play();
        StartCoroutine(SoundFader.StartFade(musicPlayer, 5, 1));
    }

    public void Quit()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(level);
    }
}
