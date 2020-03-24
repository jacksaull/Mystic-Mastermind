using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTargetManager : MonoBehaviour
{
    public int targetLimit;
    public AudioSource source;
    public AudioClip effect;
    public Animator stoneDoor;
    void Start()
    {
        stoneDoor = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void TargetHit()
    {
        targetLimit--;

        if (targetLimit == 0)
        {
            source.PlayOneShot(effect, 2);
            stoneDoor.SetBool("isTriggered", true);
        }
    }
}
