using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.z > gameObject.transform.position.z)
        {Debug.Log(collision.contacts);
            return;}
    }

}
