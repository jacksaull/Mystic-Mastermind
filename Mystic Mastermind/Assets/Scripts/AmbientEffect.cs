using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientEffect : MonoBehaviour
{
    public AudioSource source; //Source to play ambient effect from
    public AudioClip effect; //Effect to play
    private bool hasPlayed = false;
    void Start()
    {
        
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
        }
    }
}
