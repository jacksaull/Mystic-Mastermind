using System.Collections;
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
    void Start()
    {
        qSpellNum = 0;
        eSpellNum = 0;
        qImage.sprite = icons[qSpellNum];
        eImage.sprite = icons[eSpellNum];
        qName.text = spells[qSpellNum].spellName;
        eName.text = spells[eSpellNum].spellName;
        qGem.GetComponent<MeshRenderer>().material = spells[qSpellNum].colour;
        eGem.GetComponent<MeshRenderer>().material = spells[eSpellNum].colour;
        qCastable = true;
        eCastable = true;
    }


    void Update()
    {
        if (qCastable == true)
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
                    if (spells[qSpellNum].isDisabled == true)
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

                qImage.sprite = icons[qSpellNum];
                qName.text = spells[qSpellNum].spellName;
                qGem.GetComponent<MeshRenderer>().material = spells[qSpellNum].colour;
            }
        }
        if (eCastable == true)
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
                    if (spells[eSpellNum].isDisabled == true)
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

                eImage.sprite = icons[eSpellNum];
                eName.text = spells[eSpellNum].spellName;
                eGem.GetComponent<MeshRenderer>().material = spells[eSpellNum].colour;
            }
        }

        if (Input.GetButtonDown("Cast Primary") && qCastable == true)
        {
            qCastable = false;
            qGem.GetComponent<MeshRenderer>().material = recharge;
            spells[qSpellNum].CastSpell();

            InvokeRepeating("QStartRecharge", 0, 1);
        }
        if (Input.GetButtonDown("Cast Secondary") && eCastable == true)
        {
            eCastable = false;
            eGem.GetComponent<MeshRenderer>().material = recharge;
            spells[eSpellNum].CastSpell();

            InvokeRepeating("EStartRecharge", 0, 1);
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
        }
    }
}
