using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public Animator player; //Animation Player
    public AnimationClip riseAndFall; //Animation Name
    void Start()
    {
        player.Play("Pillar", 0);
        Destroy(this.gameObject, riseAndFall.length);
    }

    void Update()
    {

    }
}
 