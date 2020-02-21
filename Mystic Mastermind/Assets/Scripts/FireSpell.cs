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
    }


    void Update()
    {
        
    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public override void CastSpell()
    {
        player.PlayOneShot(soundEffect, 1);
        Instantiate(Fireball, lookDirection.transform.position, lookDirection.transform.rotation);  
    }
}
