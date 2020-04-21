using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpell : BaseSpell
{
    public GameObject lookDirection; //The Object of which the Orb will come from
    public GameObject Orb; //Orb Object
    void Start()
    {
        spellName = "Light";

        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
    }

    void Update()
    {
        
    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public override void CastSpell(string spellSlot)
    {
        castSpellSlot = spellSlot;
        player.PlayOneShot(soundEffect, 1);
        Instantiate(Orb, lookDirection.transform.position, lookDirection.transform.rotation);

        Invoke("Recharge", 5f);
    }

    void Recharge()
    {
        RechargeSpell(castSpellSlot);
    }
}
