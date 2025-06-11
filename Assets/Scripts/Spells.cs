using System;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public Fireball fireball;

    public void Fireball(GameObject casterGameobject, Vector2 aimDirection)
    {
        fireball.CastSpell(casterGameobject, aimDirection.x, aimDirection.y, casterGameobject.GetComponent<ManaController>().conduit.offenseCost, 1);
    }
}
