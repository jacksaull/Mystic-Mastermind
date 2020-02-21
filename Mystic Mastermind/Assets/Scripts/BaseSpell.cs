using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseSpell : MonoBehaviour
{
    public string spellName; //Name of Spell for UI purposes
    public bool isDisabled; //Checks whether the Spell is disabled for the current Level
    public Material colour; //Colour associated with the Spell

    public AudioSource player; //AudioSource to use
    public AudioClip soundEffect; //Sound Effect to play upon use
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public virtual void CastSpell()
    {
    }
}
