using System;
using TMPro;
using UnityEngine;

public class SpellSlots : MonoBehaviour
{
    public TextMeshProUGUI offenseSlotUi;
    public TextMeshProUGUI defenseSlotUi;
    public TextMeshProUGUI supportSlotUi;
    public TextMeshProUGUI itemSlotUi;


    public void AddSpell(GameObject spell)
    {
        Debug.Log(spell.GetComponent<Spell>().spellType == Spell.SpellTypeEnum.Offense);

        if (spell.GetComponent<Spell>().spellType == Spell.SpellTypeEnum.Offense)
        {
            if (offense == null)
            {
                offense = spell.GetComponent<Spell>();
                offense.SetLevel(1);
            }
            else if (offense.GetType() == spell.GetComponent<Spell>().GetType())
            {
                offense.SetLevel(offense.spellLevel + 1);
                Debug.Log("Spell Level: " + offense.spellLevel);
                // return;
            }
            else
            {
                offense = spell.GetComponent<Spell>();
                offense.SetLevel(1);
            }
        }
        else if (spell.GetComponent<Spell>().spellType == Spell.SpellTypeEnum.Defense)
        { defense = spell.GetComponent<Spell>(); }
        else if (spell.GetComponent<Spell>().spellType == Spell.SpellTypeEnum.Support)
        { support = spell.GetComponent<Spell>(); }
        currentSpell = spell.GetComponent<Spell>();
    }

    void Update()
    {
        offenseSlotUi.text = "Spell: " + offense.GetType().ToString() + " Spell Level:" + offense.spellLevel;
        Debug.Log("Spell Level: " + offense.spellLevel);
    }

//use enums to correspond to spell slots?
    public Spell currentSpell;
    public Spell offense;
    public Spell defense;
    public Spell support;
}
