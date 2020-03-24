using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public AudioSource source;
    public AudioClip breakEffect;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            source.PlayOneShot(breakEffect, 1.5f);
            Invoke("Break", 0.2f);
        }
    }

    void Break()
    {
        Destroy(this.gameObject);
    }
}