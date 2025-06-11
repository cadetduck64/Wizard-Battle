using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float health;
    public float damageThreshold;

    void Start()
    {
        health = 5;
    }
    public void ApplyDamage(float damage)
    {
        // if (damage < damageThreshold)
        // { return; }
        health -= damage;
        if (health <= 0)
        { Kill(gameObject); }
    }

    public void Kill(GameObject gameObject)
    {
        if (gameObject.transform.parent.gameObject)
        { Destroy(gameObject.transform.parent.gameObject); }
        else { Destroy(gameObject); }
    }
}
