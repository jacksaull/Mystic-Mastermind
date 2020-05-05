using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boulder")
        {
            Debug.Log("BOULDER");
            source.Play();
            Destroy(this.gameObject);
        }
    }
}
