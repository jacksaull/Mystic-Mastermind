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
    }


    void Update()
    {
        
    }

    /*This method manages what occurs when the Spell is selected and Cast*/
    public override void CastSpell()
    {
        if (Physics.Raycast(lookDirection.transform.position, lookDirection.transform.TransformDirection(Vector3.forward), out hit, 25, layerMask) && hit.collider.gameObject.name != "Pillar")
        {
            //Debug.DrawRay(lookDirection.transform.position, lookDirection.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green, 10.0f);
            //Debug.DrawRay(hit.point, hit.normal, Color.green, 10.0f);
            //Debug.Log("Did Hit");
            pillar.transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            Instantiate(pillar, hit.point, pillar.transform.rotation);
        }
        else
        {
            //Debug.DrawRay(lookDirection.transform.position, lookDirection.transform.TransformDirection(Vector3.forward) * 1000, Color.red, 10.0f);
            //Debug.Log("Did not Hit");
        }
    }
}
