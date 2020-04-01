using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientEffectSceneChange : MonoBehaviour
{
    public AudioSource source; //Source to play ambient effect from
    public AudioClip effect; //Effect to play
    public GameObject sceneChangeObject;
    private bool hasPlayed;
    void Start()
    {
        hasPlayed = false;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && hasPlayed == false)
        {
            source.PlayOneShot(effect);
            hasPlayed = true;

            if (sceneChangeObject.activeSelf == false)
            {
                sceneChangeObject.SetActive(true);
                Debug.Log("ON");
            }
            else if (sceneChangeObject.activeSelf == true)
            {
                sceneChangeObject.SetActive(false);
                Debug.Log("OFF");
            }
        }
    }
}
