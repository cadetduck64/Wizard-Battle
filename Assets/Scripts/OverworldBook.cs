using UnityEngine;
using System.Collections;

public class OverworldBook : OverworldItem
{
    public GameObject spell;
    // public ScriptableObject spellStats;

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<SpellSlots>().AddSpell(spell);
        // Debug.Log(collision.gameObject.GetComponent<SpellSlots>().offense);
        // Debug.Log(collision.gameObject.GetComponent<SpellSlots>().defense);
        // Debug.Log(collision.gameObject.GetComponent<SpellSlots>().support);
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }
}
