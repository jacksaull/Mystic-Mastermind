using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTriggerEvent : MonoBehaviour
{
    public GameObject eventGameObject;
    public int eventTriggerNum = 0;
    public int eventTriggerNumGoal;
    Animator eventAnim;
    void Start()
    {
        eventAnim = eventGameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (eventTriggerNum == eventTriggerNumGoal)
        {
            eventAnim.SetBool("Event Trigger", true);
        }
    }

    public void upCounter()
    {
        eventTriggerNum++;
    }
}
