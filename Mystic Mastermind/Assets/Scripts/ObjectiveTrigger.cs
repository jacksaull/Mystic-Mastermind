using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public GameObject objective;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (objective.transform.GetChild(0).gameObject.activeSelf == false)
            {
                objective.transform.GetChild(0).gameObject.SetActive(true);
                objective.transform.GetChild(1).gameObject.SetActive(true);
                objective.transform.GetChild(2).gameObject.SetActive(true);
                objective.transform.GetChild(3).gameObject.SetActive(true);
                objective.transform.GetChild(4).gameObject.SetActive(true);
            }
            else
            {
                objective.transform.GetChild(0).gameObject.SetActive(false);
                objective.transform.GetChild(1).gameObject.SetActive(false);
                objective.transform.GetChild(2).gameObject.SetActive(false);
                objective.transform.GetChild(3).gameObject.SetActive(false);
                objective.transform.GetChild(4).gameObject.SetActive(false);
            }
        }
    }
}
