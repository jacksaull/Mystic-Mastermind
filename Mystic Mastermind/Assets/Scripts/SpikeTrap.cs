using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Health player; //Player Health Script
    public Animator spikeTrap;
    public float offset; //Offset for when Trap starts
    void Start()
    {
        spikeTrap = this.GetComponent<Animator>();
        Invoke("StartTrap", offset);
        player = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        
    }

    void StartTrap()
    {
        spikeTrap.SetBool("trapStart", true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player.Death();
            Debug.Log("Dead");
        }
    }
}
