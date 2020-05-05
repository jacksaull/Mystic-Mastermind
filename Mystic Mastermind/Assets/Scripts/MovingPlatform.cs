using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool vertical;
    public float delay;
    Animator movingPlatform;
    void Start()
    {
        movingPlatform = GetComponent<Animator>();
        Invoke("startPlatform", delay);
    }

    void Update()
    {
        if (vertical == true)
        {
            movingPlatform.SetBool("Vertical", true);
        }
    }

    void startPlatform()
    {
        movingPlatform.SetBool("Delay", true);
    }
}
