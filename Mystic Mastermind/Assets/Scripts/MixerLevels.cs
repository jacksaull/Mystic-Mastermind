using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MixerLevels : MonoBehaviour
{
    public AudioMixer masterMixer; //The Master Audio Mixer
    public AudioClip musicTest; //Audio to test Music
    public AudioClip playerTest; //Audio to test Player
    public AudioClip spellTest; //Audio to test Spells
    public AudioClip effectTest; //Audio to test Effects
    public AudioSource playerSource; //Player Sound Source
    public AudioSource musicSource; //Music Sound Source
    public AudioSource spellSource; //Spell Sound Source
    public AudioSource effectSource; //Effects Sound Source

    public void MasterLevel(float masterVol)
    {
        masterMixer.SetFloat("masterVol", masterVol);
    }
    public void MusicLevel(float musicVol)
    {
        masterMixer.SetFloat("musicVol", musicVol);
    }

    public void PlayerLevel(float playerVol)
    {
        masterMixer.SetFloat("playerVol", playerVol);
        if (!playerSource.isPlaying)
        {
            playerSource.PlayOneShot(playerTest);
        }
    }

    public void SpellLevel(float spellVol)
    {
        masterMixer.SetFloat("spellVol", spellVol);
        if (!spellSource.isPlaying)
        {
            spellSource.PlayOneShot(spellTest);
        }
    }

    public void EffectsLevel(float effectVol)
    {
        masterMixer.SetFloat("effectVol", effectVol);
        if (!effectSource.isPlaying)
        {
            effectSource.PlayOneShot(effectTest);
        }
    }
}
