﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public int qSpellNum; //Index of Spell within the Array for the Q Spell
    public int eSpellNum; //Index of Spell within the Array for the E Spell
    private bool qSelectSpell; //Checks whether Spell can be selected
    private bool eSelectSpell; //Checks whether Spell can be selected
    private bool qCastable; //Whether Q Spell can be Cast
    private bool eCastable; //Whether E Spell can be Cast
    public bool paused; //Check is game is paused
    public bool secondaryDisabled;
    public Sprite disabledImage;

    public Image qImage; //Icon for Spell in the Q slot
    public Image eImage; //Icon for Spell in the E slot
    public TextMeshProUGUI qName; //Name for Spell in the Q slot
    public TextMeshProUGUI eName; //Name for Spell in the E slot

    public Sprite[] icons; //List of Icons for Spells
    public BaseSpell[] spells; //List of available Spells

    public GameObject qGem; //Gem of left Staff
    public GameObject eGem; //Gem of right Staff
    public Material recharge; //Recharge Gem Material
    private int qRecharge = 5;
    private int eRecharge = 5;

    public GameObject lookDirection; //The Object of which the RayCast will come from
    int layerMask = 1 << 8; //The Layer that the RayCast should make contact with
    RaycastHit hit; //The Raycast
    public GameObject pillar; //Earth Pillar Spell Object

    public AudioSource player; //AudioSource to use
    public AudioClip rechargeSound; //Sound Effect to play upon use
    public AudioClip changeSound; //Sound Effect to play upon use

    void Start()
    {
        qSpellNum = 0;
        eSpellNum = 1;
        qImage.sprite = icons[qSpellNum];
        eImage.sprite = icons[eSpellNum];
        qName.text = spells[qSpellNum].spellName;
        eName.text = spells[eSpellNum].spellName;
        qGem.GetComponent<MeshRenderer>().material = spells[qSpellNum].colour;
        eGem.GetComponent<MeshRenderer>().material = spells[eSpellNum].colour;
        qCastable = true;
        eCastable = true;

        paused = false;

        pillar.SetActive(false); 

        if (secondaryDisabled == true)
        {
            eGem.GetComponent<MeshRenderer>().material = recharge;
            eName.text = "Disable";
            eImage.sprite = disabledImage;
        }
    }


    void Update()
    {
        if (qCastable == true && paused == false)
        {
            if (Input.GetButtonDown("Q Spell"))
            {
                qSelectSpell = false;
                if ((qSpellNum + 1) > spells.Length - 1)
                {
                    qSpellNum = 0;
                }
                else
                {
                    qSpellNum += 1;
                }

                while (qSelectSpell == false)
                {
                    if (spells[qSpellNum].isDisabled == true || spells[qSpellNum].spellName == spells[eSpellNum].spellName)
                    {
                        if ((qSpellNum + 1) > spells.Length - 1)
                        {
                            qSpellNum = 0;
                        }
                        else
                        {
                            qSpellNum += 1;
                        }
                    }
                    else
                    {
                        qSelectSpell = true;
                    }
                }
                player.PlayOneShot(changeSound, 1);
                qImage.sprite = icons[qSpellNum];
                qName.text = spells[qSpellNum].spellName;
                qGem.GetComponent<MeshRenderer>().material = spells[qSpellNum].colour;
            }
        }
        if (eCastable == true && paused == false && secondaryDisabled == false)
        {
            if (Input.GetButtonDown("E Spell"))
            {
                eSelectSpell = false;
                if ((eSpellNum + 1) > spells.Length - 1)
                {
                    eSpellNum = 0;
                }
                else
                {
                    eSpellNum += 1;
                }

                while (eSelectSpell == false)
                {
                    if (spells[eSpellNum].isDisabled == true || spells[eSpellNum].spellName == spells[qSpellNum].spellName)
                    {
                        if ((eSpellNum + 1) > spells.Length - 1)
                        {
                            eSpellNum = 0;
                        }
                        else
                        {
                            eSpellNum += 1;
                        }
                    }
                    else
                    {
                        eSelectSpell = true;
                    }
                }
                player.PlayOneShot(changeSound, 1);
                eImage.sprite = icons[eSpellNum];
                eName.text = spells[eSpellNum].spellName;
                eGem.GetComponent<MeshRenderer>().material = spells[eSpellNum].colour;
            }
        }

        if (Input.GetButtonDown("Cast Primary") && qCastable == true && paused == false)
        {
            qCastable = false;
            qGem.GetComponent<MeshRenderer>().material = recharge;
            spells[qSpellNum].CastSpell();

            InvokeRepeating("QStartRecharge", 0, 1);
        }
        if (Input.GetButtonDown("Cast Secondary") && eCastable == true && paused == false && secondaryDisabled == false)
        {
            eCastable = false;
            eGem.GetComponent<MeshRenderer>().material = recharge;
            spells[eSpellNum].CastSpell();

            InvokeRepeating("EStartRecharge", 0, 1);
        }

        if (eName.text == "Earth" || qName.text == "Earth")
        {
            if (Physics.Raycast(lookDirection.transform.position, lookDirection.transform.TransformDirection(Vector3.forward), out hit, 25, layerMask))
            {
                pillar.SetActive(true);
                pillar.transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                pillar.transform.position = hit.point;
            }
            else
            {
                pillar.SetActive(false);
            }
        }
        else
        {
            pillar.SetActive(false);
        }
    }

    void QStartRecharge()
    {
        if (qRecharge != 0)
        {
            qRecharge -= 1;
        }
        else
        {
            qRecharge = 5;
            qCastable = true;
            qGem.GetComponent<MeshRenderer>().material = spells[qSpellNum].colour;
            CancelInvoke("QStartRecharge");
            player.PlayOneShot(rechargeSound, 1);
        }
    }

    void EStartRecharge()
    {
        if (eRecharge != 0)
        {
            eRecharge -= 1;
        }
        else
        {
            eRecharge = 5;
            eCastable = true;
            eGem.GetComponent<MeshRenderer>().material = spells[eSpellNum].colour;
            CancelInvoke("EStartRecharge");
            player.PlayOneShot(rechargeSound, 1);
        }
    }
}
