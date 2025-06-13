using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public enum SpellTypeEnum
    {
        Offense,
        Defense,
        Support
    }

    public enum SpellElementEnum
    {
        Fire,
        Water,
        Earth,
        Air,
    }

    public SpellTypeEnum spellType;
    public SpellElementEnum SpellElement;
    public GameObject spellCaster;
    public int spellLevel;
    public void SetLevel(int newLevel)
    {
        if (newLevel > 3)
        {
            spellLevel = 3;
            return;
        }
        else
        { spellLevel = newLevel; }
    }
    public abstract void CastSpell(GameObject caster, Vector2 aim);
}
