using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    private float speed = 1800.0f; //Speed of Boulder
    private Rigidbody m_Rigidbody; //Rigidbody of Boulder
    private AudioSource source;
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * speed);
        Invoke("DestroySelf", 4);
    }

    void Update()
    {
        
    }

    void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Player")
        {
            source.Play();
        }
    }
}
