using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTriggerEventCounter : MonoBehaviour
{
    public FireTriggerEvent fireTriggerEvent;
    public GameObject eventGameObject;

    public Light targetLight;
    public AudioSource source;
    public AudioClip beep;
    bool isHit;
    public Material hitMat;
    void Start()
    {
        fireTriggerEvent = eventGameObject.GetComponent<FireTriggerEvent>();

        targetLight = GetComponentInChildren<Light>();
        source = GetComponent<AudioSource>();

        isHit = false;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fireball" && !isHit)
        {
            isHit = true;
            source.PlayOneShot(beep, 3.5f);
            targetLight.intensity = 3;

            this.gameObject.GetComponent<MeshRenderer>().material = hitMat;
            fireTriggerEvent.upCounter();
        }
    }
}
