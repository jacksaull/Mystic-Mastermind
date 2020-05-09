using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    public AudioSource source;
    public Animator animator;
    public int correctPlacement = 0;
    void Start()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (correctPlacement == 4)
        {
            Invoke("OpenDoor", 5);
        }
    }

    void OpenDoor()
    {
        animator.SetBool("isTriggered", true);
        source.Play();
    }
}
