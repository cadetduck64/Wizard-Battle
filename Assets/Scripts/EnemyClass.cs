using Unity.VisualScripting;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public float speed;
    public GameObject currentTarget;
    public float damage;
    public float health;
    public Rigidbody2D enemyRb;
    public GridScript currentGrid;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(gameObject.transform.position.z + 1);
        currentGrid.TrackElevation(gameObject);
        if (!currentTarget)
        {return;}
        // else {enemyRb.MovePosition(currentTarget.transform.position);}
        else {enemyRb.AddForce(new Vector2(currentTarget.transform.position.x - gameObject.transform.position.x, currentTarget.transform.position.y - gameObject.transform.position.y), ForceMode2D.Impulse);}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.CompareTag("Player"))
        {currentTarget = collision.gameObject;}
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(other + " has left");
        currentTarget = null;
    }
}