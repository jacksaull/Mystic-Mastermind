using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicPlayer; //The Music Audiosource of the Player
    public AudioClip musicClip; //Clip to become current Music

    private bool hasPlayed = false;

    public MixerLevels audioManager;
    void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<MixerLevels>();
        musicPlayer = audioManager.musicSource;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && hasPlayed == false)
        {
            hasPlayed = true;
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
}
