using UnityEngine;

public class Destructiblewall : MonoBehaviour
{
    public float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        { Destroy(gameObject); }
    }
}
