using UnityEngine;

public class Earthball : Fireball
{    
    void Start()
    {
        spellType = SpellTypeEnum.Offense;
        SpellElement = SpellElementEnum.Water;
    }

    public override void CastSpell(GameObject caster, Vector2 aim)
    {
        base.CastSpell(caster, aim);
    }
    
    
    // public float xdirection;
    // public float ydirection;
    // public float damage;
    // public LayerMask validTargets;

    // // public void CastSpell(GameObject caster, float x, float y, int manaCost, int level)
    // // {
    // //     if (caster.GetComponent<ManaController>().currentMana < manaCost)
    // //     { return; }
    // //     spellLevel = level;
    // //     damage = spellLevel * 5;
    // //     caster.GetComponent<ManaController>().currentMana -= manaCost;
    // //     Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>(), true);
    // //     if (xdirection <= 0.1 && ydirection <= 0.1)
    // //     { xdirection = 1; ydirection = 1; }
    // //     else
    // //     {
    // //         xdirection = x;
    // //         ydirection = y;
    // //     }
    // //     Instantiate(gameObject, new Vector3(caster.transform.position.x, caster.transform.position.y, caster.transform.position.z), Quaternion.identity);

    // // }

    // public override void CastSpell(GameObject caster, Vector2 aim)
    // {f
    //     spellCaster = caster;
    //     if (caster.GetComponent<ManaController>().currentMana < caster.GetComponentInChildren<Conduit>().offenseCost)
    //     { return; }
    //     // spellLevel = level;
    //     damage = spellLevel * 5;
    //     caster.GetComponent<ManaController>().currentMana -= caster.GetComponentInChildren<Conduit>().offenseCost;
    //     Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), caster.GetComponent<Collider2D>(), true);
    //     if (xdirection <= 0.1 && ydirection <= 0.1)
    //     { xdirection = 1; ydirection = 1; }
    //     else
    //     {
    //         xdirection = aim.x;
    //         ydirection = aim.y;
    //     }
    //     Instantiate(gameObject, new Vector3(caster.transform.position.x, caster.transform.position.y, caster.transform.position.z), Quaternion.identity);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     gameObject.transform.Translate(new Vector2(xdirection * Time.deltaTime * 0.8f, ydirection * Time.deltaTime * 0.8f));
    //     gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)gameObject.transform.position.z + 1;
    // }

    // // void OnTriggerEnter2D(Collider2D collision)
    // // {

    // //     Debug.Log(collision.tag);       
    // //     if (collision.gameObject.layer == validTargets)
    // //     { Destroy(gameObject); }
    // // }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Destroy(gameObject);
    //     if (collision.gameObject.GetComponent<HealthController>())
    //     {collision.gameObject.GetComponent<HealthController>().ApplyDamage(damage);}
    //     if (collision.gameObject.GetComponent<Rigidbody>())
    //     {collision.gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.transform.position, ForceMode.Impulse);}

    // }
}
