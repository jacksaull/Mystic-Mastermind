using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : BaseSpell
{
    public GameObject lookDirection; //The Object of which the Fireball will come from
    public GameObject Fireball; //Fireball Object
    void Start()
    {
        spellName = "Fire";

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
        Instantiate(Fireball, lookDirection.transform.position, lookDirection.transform.rotation);

        Invoke("Recharge", 1.5f);
    }

    void Recharge()
    {
        RechargeSpell(castSpellSlot);
    }
}
