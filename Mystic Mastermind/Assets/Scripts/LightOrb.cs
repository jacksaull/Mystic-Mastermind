using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrb : MonoBehaviour
{
    private float speed = 500.0f; //Speed of Fireball
    private Rigidbody m_Rigidbody; //Rigidbody of Fireball

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * speed);
        Invoke("Delete", 10);
    }

    void Update()
    {
        
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
