using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTarget : MonoBehaviour
{
    public Light targetLight;
    public AudioSource source;
    public AudioClip beep;
    bool isHit;

    public string findTag;

    public FireTargetManager fireTargetManager;
    public ObjectiveUI objectiveUI;
    public Material hitMat;
    void Start()
    {
        targetLight = GetComponentInChildren<Light>();
        source = GetComponent<AudioSource>();
        fireTargetManager = GameObject.FindWithTag("FireTargetTrigger").GetComponent<FireTargetManager>();
        objectiveUI = GameObject.FindWithTag("FireTargetObjective").GetComponent<ObjectiveUI>();

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

            fireTargetManager.TargetHit();
            objectiveUI.UpdateCounter();
            this.gameObject.GetComponent<MeshRenderer>().material = hitMat;
        }
    }
}
