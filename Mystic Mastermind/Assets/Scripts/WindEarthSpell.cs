using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEarthSpell : BaseComboSpell
{
    public GameObject lookDirection; //The Object of which the Boulder will come from
    public GameObject Boulder; //Boulder Object
    void Start()
    {
        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();

        spellName = "Boulder Throw";
        element1 = "Wind";
        element2 = "Earth";
    }

    void Update()
    {

    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public override void CastSpell()
    {
        player.PlayOneShot(soundEffect, 1);
        Instantiate(Boulder, lookDirection.transform.position, lookDirection.transform.rotation);

        Invoke("Recharge", 4.0f);
    }

    void Recharge()
    {
        RechargeSpell();
    }
}
