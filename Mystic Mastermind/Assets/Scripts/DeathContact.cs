using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathContact : MonoBehaviour
{
    public Health player; //Player Health Script
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        
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
