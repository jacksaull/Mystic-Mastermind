using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public AudioSource player; //AudioSource to use
    public AudioClip soundEffect; //Sound Effect to play upon use
    void Start()
    {
        player.PlayOneShot(soundEffect, 1);
        Invoke("Clean", 1);
    }

    void Update()
    {
        
    }

    void Clean()
    {
        Destroy(this.gameObject);
    }
}
