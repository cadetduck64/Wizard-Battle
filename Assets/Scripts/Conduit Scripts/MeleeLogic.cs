using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MeleeLogic : MonoBehaviour
{
    public ConduitStats stats;

    public enum AttackElementEnum
    {
        Fire,
        Water,
        Earth,
        Air
    }

    public void CalculateMeleeDamage()
    {
            
    }

    private float damage;

    void Start()
    {
        damage = stats.attack;
        LayerMask mask = LayerMask.GetMask("Enemy", "Collision");
    }

    ContactFilter2D contactFilter;

    // public void MeleeHitCheck() {
    //     contactFilter.SetLayerMask(mask);
    //     contactFilter.SetDepth(gameObject.transform.position.z, gameObject.transform.position.z);
    //     List<Collider2D> collisionList = new List<Collider2D>();

    //     gameObject.GetComponent<BoxCollider2D>().Overlap(contactFilter, collisionList);
    //     // collision.Overlap(contactFilter, collisionList);
    //     // collision.Overlap(collisionList);
    //     foreach (var item in collisionList)
    //     {
    //         Debug.Log(item);
    //     }
    // }


    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HealthController>().ApplyDamage(damage);
        Debug.Log(collision);
    }
}
