using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComboSpell : MonoBehaviour
{
    public string spellName; //Name of Spell for UI purposes
    public bool isDisabled; //Checks whether the Spell is disabled for the current Level
    public string element1; //First element of Combo Spell
    public string element2; //Second element of Combo Spell

    public AudioSource player; //AudioSource to use
    public AudioClip soundEffect; //Sound Effect to play upon use

    public SpellManager spellManager;
    void Start()
    {
        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
    }

    void Update()
    {
        
    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public virtual void CastSpell()
    {
    }
    /*This method manages recharging of the Spell*/
    public virtual void RechargeSpell()
    {
        spellManager.QStartRecharge();
        spellManager.EStartRecharge();
    }
}
