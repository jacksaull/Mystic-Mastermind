using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : BaseSpell
{
    public GameObject lookDirection; //The Object of which the RayCast will come from
    int layerMask = 1 << 8; //The Layer that the RayCast should make contact with
    RaycastHit hit; //The Raycast
    public GameObject pillar; //Earth Pillar Spell Object

    void Start()
    {
        spellName = "Earth";

        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
    }


    void Update()
    {
        
    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public override void CastSpell(string spellSlot)
    {
        castSpellSlot = spellSlot;
        if (Physics.Raycast(lookDirection.transform.position, lookDirection.transform.TransformDirection(Vector3.forward), out hit, 25, layerMask) && hit.collider.gameObject.name == "Dirt")
        {
            pillar.transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            Instantiate(pillar, hit.point, pillar.transform.rotation);
        }
    }
}
