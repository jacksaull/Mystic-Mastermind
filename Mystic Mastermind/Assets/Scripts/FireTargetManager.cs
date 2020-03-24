using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTargetManager : MonoBehaviour
{
    public int targetLimit;
    public Animator stoneDoor;
    void Start()
    {
        stoneDoor = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void TargetHit()
    {
        targetLimit--;

        if (targetLimit == 0)
        {
            stoneDoor.SetBool("isTriggered", true);
        }
    }
}
