using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlate : MonoBehaviour
{
    public SpellManager spellManager;
    public Health health;
    public Animator magicAnimation; //Change Plate Animation
    public GameObject spawnPoint; //GameObject of new Spawn Point

    AudioSource audioSource;

    bool activated; //Has Plate already been activated
    public bool secondaryDisabled; //Whether Secondary Spell is disabled
    public int qSpell; //Primary Spell Slot Array Value
    public int eSpell; //Secondary Spell Slot Array Value
    public bool[] spellDisabled;
    void Start()
    {
        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
        health = GameObject.FindWithTag("Player").GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();

        activated = false;
    }

    void Update()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && activated == false)
        {
            magicAnimation.SetBool("isActive", true);
            audioSource.Play();
            activated = true;

            health.spawnPoint = spawnPoint;

            spellManager.qSpellNum = qSpell;
            spellManager.qImage.sprite = spellManager.icons[qSpell];
            spellManager.qName.text = spellManager.spells[qSpell].spellName;
            spellManager.qGem.GetComponent<MeshRenderer>().material = spellManager.spells[qSpell].colour;


            spellManager.eSpellNum = eSpell;
            spellManager.eImage.sprite = spellManager.icons[eSpell];
            spellManager.eName.text = spellManager.spells[eSpell].spellName;
            spellManager.eGem.GetComponent<MeshRenderer>().material = spellManager.spells[eSpell].colour;

            if (secondaryDisabled)
            {
                spellManager.eGem.GetComponent<MeshRenderer>().material = spellManager.recharge;
                spellManager.eName.text = "Disable";
                spellManager.eImage.sprite = spellManager.disabledImage;
            }

            spellManager.secondaryDisabled = secondaryDisabled;
            for (int i = 0; i < spellManager.spells.Length; i++)
            {
                spellManager.spells[i].isDisabled = spellDisabled[i];
            }
        }
    }
}
