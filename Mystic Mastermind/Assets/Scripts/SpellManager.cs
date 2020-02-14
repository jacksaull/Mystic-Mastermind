using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public int qSpellNum; //Index of Spell within the Array for the Q Spell
    public int eSpellNum; //Index of Spell within the Array for the E Spell

    public Image qImage; //Icon for Spell in the Q slot
    public Image eImage; //Icon for Spell in the E slot
    public TextMeshProUGUI qName; //Name for Spell in the Q slot
    public TextMeshProUGUI eName; //Name for Spell in the E slot

    public Sprite[] icons; //List of Icons for Spells
    public BaseSpell[] spells; //List of available Spells
    void Start()
    {
        qSpellNum = 0;
        eSpellNum = 0;
        qImage.sprite = icons[qSpellNum];
        eImage.sprite = icons[eSpellNum];
    }


    void Update()
    {
        if (Input.GetButtonDown("Q Spell"))
        {
            if ((qSpellNum += 1) > spells.Length)
            {
                qSpellNum = 0;
            }
            else
            {
                qSpellNum += 1;
            }

            if (spells[qSpellNum].isDisabled == true)
            {

            }
        }
    }
}
