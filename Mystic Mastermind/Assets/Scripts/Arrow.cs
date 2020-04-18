using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Health player; //Player Health Script
    private AudioSource hit; //Hit Sound
    private Rigidbody rb;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Health>();
        hit = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * 900);
        Invoke("Delete", 10.0f);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player.Death();
            hit.Play();
            Debug.Log("Dead");
            Invoke("Delete", 0.2f);
        }
        else
        {
            hit.Play();
            rb.AddForce(-transform.forward * 900);
            Invoke("Delete", 1);
        }
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
