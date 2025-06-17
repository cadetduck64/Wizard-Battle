using Unity.Mathematics;
using UnityEngine;

public class SummonWall : Spell
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spellType = SpellTypeEnum.Defense;
        SpellElement = SpellElementEnum.Earth;
    }

    public GameObject wall;

    public override void CastSpell(GameObject caster, Vector2 aim)
    {
        for (int i = 1; i < spellLevel; i++)
        {
            Instantiate(wall, new Vector3(aim.x + caster.transform.position.x + spellLevel - 1, aim.y + caster.transform.position.y, caster.transform.position.z), quaternion.identity);    
        }
        
    }
}
