using UnityEngine;

public class Fireball : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector2(0, 0.1f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ENTERED");
        if (!collision.gameObject.CompareTag("Player"))
        {Destroy(gameObject);}
    }
}
