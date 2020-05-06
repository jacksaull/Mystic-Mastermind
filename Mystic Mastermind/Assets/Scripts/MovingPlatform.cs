using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool vertical;
    public float delay;
    Animator movingPlatform;

    public GameObject player;
    void Start()
    {
        movingPlatform = GetComponent<Animator>();
        Invoke("startPlatform", delay);

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (vertical == true)
        {
            movingPlatform.SetBool("Vertical", true);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = null;
        }
    }

    void startPlatform()
    {
        movingPlatform.SetBool("Delay", true);
    }
}
