using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrap : MonoBehaviour
{
    public Animator pitTrap;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            pitTrap.SetBool("isTriggered", true);
            Debug.Log("Pit");
        }
    }
}
