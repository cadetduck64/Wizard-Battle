using UnityEngine;

public class Teleport : Spell
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spellType = SpellTypeEnum.Support;
        SpellElement = SpellElementEnum.Air;
    }

    public override void CastSpell(GameObject caster, Vector2 aim)
    {
        // throw new System.NotImplementedException();
        caster.transform.position = new Vector2(
        caster.transform.position.x + aim.x * spellLevel * 1.5f,
        caster.transform.position.y + aim.y * spellLevel * 1.5f);
    }
}
