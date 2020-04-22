using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrb : MonoBehaviour
{
    private float speed = 500.0f; //Speed of Fireball
    private Rigidbody m_Rigidbody; //Rigidbody of Fireball
    private Light orbLight; //Light of the Orb
    float minIntensity = 0.5f;
    float maxIntensity = 2f;
    float lightChangeSpeed = 1f;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        orbLight = GetComponent<Light>();
    }

    void Start()
    {
        m_Rigidbody.AddForce(m_Rigidbody.transform.forward * speed);
        Invoke("Delete", 10);
    }

    void Update()
    {
        orbLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time, lightChangeSpeed));
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
