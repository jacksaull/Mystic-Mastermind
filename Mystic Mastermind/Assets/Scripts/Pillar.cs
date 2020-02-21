using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public Animator player; //Animation Player
    public AnimationClip riseAndFall; //Animation Name

    public AudioSource asPlayer; //AudioSource to use
    public AudioClip soundEffect; //Sound Effect to play upon use
    void Start()
    {
        player.Play("Pillar", 0);
        asPlayer.PlayOneShot(soundEffect, 1);
        Destroy(this.gameObject, riseAndFall.length);
    }

    void Update()
    {

    }
}
 