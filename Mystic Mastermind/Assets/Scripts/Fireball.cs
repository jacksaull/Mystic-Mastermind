using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float speed = 1800.0f; //Speed of Fireball
    private Rigidbody m_Rigidbody; //Rigidbody of Fireball
    public GameObject Explosion; //Explosion Effect
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    
    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * speed);
        Invoke("Explode", 3);
    }


    void Update()
    {

    }

    void Explode()
    {
        Instantiate(Explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Player")
        {
            Instantiate(Explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Invoke("Explode", 0.05f);
        }
    }
}
