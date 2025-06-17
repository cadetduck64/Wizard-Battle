using System;
using TMPro;
using UnityEngine;

public class SpellSlots : MonoBehaviour
{
    public TextMeshProUGUI currentSpellSlotUi;
    public TextMeshProUGUI offenseSlotUi;
    public TextMeshProUGUI defenseSlotUi;
    public TextMeshProUGUI supportSlotUi;
    public TextMeshProUGUI itemSlotUi;

    public void AddSpell(GameObject spell)
    {
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
        {
            if (defense == null)
            {
                defense = spell.GetComponent<Spell>();
                defense.SetLevel(1);
            }
            else if (defense.GetType() == spell.GetComponent<Spell>().GetType())
            {
                defense.SetLevel(defense.spellLevel + 1);
                Debug.Log("Spell Level: " + defense.spellLevel);
                // return;
            }
            else
            {
                defense = spell.GetComponent<Spell>();
                defense.SetLevel(1);
            }
        }
        else if (spell.GetComponent<Spell>().spellType == Spell.SpellTypeEnum.Support)
        {
            if (support == null)
            {
                support = spell.GetComponent<Spell>();
                support.SetLevel(1);
            }
            else if (support.GetType() == spell.GetComponent<Spell>().GetType())
            {
                support.SetLevel(support.spellLevel + 1);
                Debug.Log("Spell Level: " + support.spellLevel);
                // return;
            }
            else
            {
                support = spell.GetComponent<Spell>();
                support.SetLevel(1);
            }
        }
        currentSpell = spell.GetComponent<Spell>();
    }

// Spell[] spellSlots = new Spell[3];
//     public void AddSpell(GameObject spell)
//     {
//         spellSlots = new Spell[] { offense, defense, support };
//         for (int i = 0; i < spellSlots.Length; i++)
//         {
//             Debug.Log(spellSlots[i].spellType);
//             Debug.Log(spell.GetComponent<Spell>().spellType);

//             // if (spell.GetComponent<Spell>().spellType == spellSlots[i].spellType)
//             // {
//             //     if (spellSlots[i] == null)
//             //     {
//             //         spellSlots[i] = spell.GetComponent<Spell>();
//             //         spellSlots[i].SetLevel(1);
//             //     }
//             //     else if (spellSlots[i].GetType() == spell.GetComponent<Spell>().GetType())
//             //     {
//             //         spellSlots[i].SetLevel(spellSlots[i].spellLevel + 1);
//             //         Debug.Log("Spell Level: " + spellSlots[i].spellLevel);
//             //         // return;
//             //     }
//             //     else
//             //     {
//             //         spellSlots[i] = spell.GetComponent<Spell>();
//             //         spellSlots[i].SetLevel(1);
//             //     }
//             // }
//         }
//     }
        
    void Update()
    {
        offenseSlotUi.text = "Spell: " + offense.ToString() + " Spell Level:" + offense.spellLevel;
        defenseSlotUi.text = "Spell: " + defense.ToString() + " Spell Level:" + defense.spellLevel;
        supportSlotUi.text = "Spell: " + support.ToString() + " Spell Level:" + support.spellLevel;
        currentSpellSlotUi.text = "Spell: " + currentSpell.ToString() + " Spell Level:" + currentSpell.spellLevel;
        Debug.Log("Spell Level: " + offense.spellLevel);
    }

    void Start()
    {
        offense.spellType = Spell.SpellTypeEnum.Offense;
        defense.spellType = Spell.SpellTypeEnum.Defense;
        support.spellType = Spell.SpellTypeEnum.Support;
    }

    //use enums to correspond to spell slots?
    public Spell currentSpell;
    public Spell offense;
    public Spell defense;
    public Spell support;
}
