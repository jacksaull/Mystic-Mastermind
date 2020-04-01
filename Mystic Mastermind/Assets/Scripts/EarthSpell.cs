using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : BaseSpell
{
    public GameObject lookDirection; //The Object of which the RayCast will come from
    int layerMask = 1 << 8; //The Layer that the RayCast should make contact with
    RaycastHit hit; //The Raycast
    public GameObject pillar; //Earth Pillar Spell Object
    public GameObject pillarGhost;
    public GameObject eLight;
    void Start()
    {
        spellName = "Earth";

        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
    }

    void Update()
    {
        if (spellManager.qName.text == "Earth" || spellManager.eName.text == "Earth")
        {
            if (Physics.Raycast(lookDirection.transform.position, lookDirection.transform.TransformDirection(Vector3.forward), out hit, 25, layerMask) && hit.collider.gameObject.tag == "Dirt")
            {
                pillarGhost.SetActive(true);
                eLight.SetActive(true);
                pillarGhost.transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                pillarGhost.transform.position = hit.point;
                eLight.transform.position = hit.point;
            }
            else
            {
                pillarGhost.SetActive(false);
                eLight.SetActive(false);
            }
        }
        else
        {
            pillarGhost.SetActive(false);
            eLight.SetActive(false);
        }
    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public override void CastSpell(string spellSlot)
    {
        castSpellSlot = spellSlot;
        if (Physics.Raycast(lookDirection.transform.position, lookDirection.transform.TransformDirection(Vector3.forward), out hit, 25, layerMask) && hit.collider.gameObject.tag == "Dirt")
        {
            pillar.transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            Instantiate(pillar, hit.point, pillar.transform.rotation);

            Invoke("Recharge", 2.5f);
        }
        else
        {
            RechargeSpell(castSpellSlot);
        }
    }

    void Recharge()
    {
        RechargeSpell(castSpellSlot);
    }
}
