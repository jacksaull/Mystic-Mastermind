using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ComboSpellManager : MonoBehaviour
{
    public TextMeshProUGUI comboSpellName;
    string comboSpellNameText;
    public Image comboBorderImageL;
    public Image comboBorderImageR;
    public Sprite comboBorder;
    public Sprite comboBorderGlow;

    bool comboSpellMatch;

    public SpellManager spellManager;

    public BaseComboSpell[] comboSpells; //List of available Combo Spells
    void Start()
    {
        spellManager = GameObject.FindWithTag("Spell Manager").GetComponent<SpellManager>();
    }

    void Update()
    {
        
    }

    public void CheckComboSpell()
    {
        comboSpellMatch = false;
        for (int i = 0; i < comboSpells.Length; i++)
        {
            if (!comboSpellMatch)
            {
                if (spellManager.qName.text == comboSpells[i].element1 && spellManager.eName.text == comboSpells[i].element2 && comboSpells[i].isDisabled == false || spellManager.eName.text == comboSpells[i].element1 && spellManager.qName.text == comboSpells[i].element2 && comboSpells[i].isDisabled == false)
                {
                    spellManager.isComboSpell = true;
                    comboBorderImageL.sprite = comboBorderGlow;
                    comboBorderImageR.sprite = comboBorderGlow;

                    comboSpellNameText = comboSpells[i].spellName;
                    comboSpellName.text = comboSpellNameText;
                    comboSpellMatch = true;
                    spellManager.comboSpellIndex = i;
                }
                else
                {
                    spellManager.isComboSpell = false;
                    comboBorderImageL.sprite = comboBorder;
                    comboBorderImageR.sprite = comboBorder;

                    comboSpellName.text = "?";
                    comboSpellMatch = false;
                }
            }
        }
    }
}
