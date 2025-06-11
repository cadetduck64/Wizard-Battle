using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMonoScript : MonoBehaviour
{
    // public TilemapInfo tilemapInfoVar;
    public TilemapCollisionMonoscript collisionVar;
    public bool tieElevationAndLayer;
    public bool tieElevationAndCollision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        TilemapCollisionMonoscript collisionVar = gameObject.GetComponentInChildren<TilemapCollisionMonoscript>();
        if (tieElevationAndLayer)
        {gameObject.GetComponent<TilemapRenderer>().sortingOrder = (int)gameObject.transform.position.z; }
        if(tieElevationAndCollision)
        {collisionVar.transform.position = new Vector3(collisionVar.transform.position.x, collisionVar.transform.position.y, collisionVar.transform.position.z);}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // List<Collider2D> triggerOverlaps = new List<Collider2D>();
        // List<Collider2D> collisionOverlaps = new List<Collider2D>();
        
        // Debug.Log(gameObject.GetComponent<TilemapCollider2D>().Overlap(gameObject.transform.position, 0, collisionOverlaps));

        // foreach (var item in collisionOverlaps)
        // {Debug.Log(item.name + " " + item.transform.position.z);}

        // if (collision.CompareTag("Player") && collision.Overlap(collision.transform.position, 0, collisionOverlaps) < 1)
        // {
        //     if (transform.position.z == collision.transform.position.z + 1)
        //         {
        //         collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, gameObject.transform.position.z);
        //         collision.GetComponent<SpriteRenderer>().sortingOrder = (int)(collision.transform.position.z + 1);
        //         Debug.Log("raised");
        //         return;
        //         }
        //     else if (transform.position.z == collision.transform.position.z - 1)
        //         {
        //         // Physics2D.IgnoreCollision(item.GetComponentInChildren<TilemapCollisionMonoscript>().elevation);    
        //         collision.transform.position =new Vector3(collision.transform.position.x, collision.transform.position.y, gameObject.transform.position.z);
        //         collision.GetComponent<SpriteRenderer>().sortingOrder = (int)(collision.transform.position.z + 1);
        //         Debug.Log("lowered");
        //         return;
        //         }
        // } 
        // else if (collision.CompareTag("Player") && collision.Overlap(collision.transform.position, 0, collisionOverlaps) >= 1)
        //     {foreach (var item in collisionOverlaps)            
        //         if (item.transform.position.z > collision.transform.position.z + 1) //if the highest platform is 2 levels higher, hide the player
        //             {
        //             collision.GetComponent<SpriteRenderer>().sortingOrder = (int)(collision.transform.position.z - 1);
        //             }
        //         else if (transform.position.z == collision.transform.position.z + 1)
        //             {
        //             collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, gameObject.transform.position.z);
        //             collision.GetComponent<SpriteRenderer>().sortingOrder = (int)(collision.transform.position.z + 1);
        //             Debug.Log("raised");
        //             return;
        //             }
        // }

        
            
        // if (triggerOverlaps.Count >= 1)
        // {foreach (var item in triggerOverlaps)
        //     {
        //         if (!item.isTrigger) {return;}
        //         else if (item.transform.position.z < collision.transform.position.z - 1)
        //             {
        //             //fall damage
        //             collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, gameObject.transform.position.z);
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(collision.transform.position.z + 1);
        //             Debug.Log("Fall DAMAGED");
        //             }
        //         else if (item.transform.position.z > collision.transform.position.z + 1) //if the highest platform is 1 level higher, hide the player
        //             {
        //             collision.GetComponent<SpriteRenderer>().sortingOrder = (int)(collision.transform.position.z - 1);
        //             }
        //         else if (item.transform.position.z == collision.transform.position.z + 1)
        //             {
        //             collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, gameObject.transform.position.z + 1);
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(collision.transform.position.z + 1);
        //             Debug.Log("raised");
        //             return;
        //             }
        //         else if (item.transform.position.z == collision.transform.position.z - 1)
        //             {
        //             // Physics2D.IgnoreCollision(item.GetComponentInChildren<TilemapCollisionMonoscript>().elevation);    
        //             collision.transform.position =new Vector3(collision.transform.position.x, collision.transform.position.y, gameObject.transform.position.z - 1);
        //             gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(collision.transform.position.z + 1);
        //             Debug.Log("raised");
        //             return;
                    
        //             }
        //         else {return;}
        //     }
        // } else {collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, gameObject.transform.position.z);}


        // Debug.Log("Currently on " + tilemapInfoVar.areaName);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("left: " + gameObject.name);
        // List<Collider2D> triggerOverlaps = new List<Collider2D>();

        // if (collision.Overlap(collision.transform.position, 0, triggerOverlaps) > 1)
        // {foreach (var item in triggerOverlaps)
        // {
        //         if (item.transform.position.z > collision.transform.position.z || item.transform.position.z < collision.transform.position.z)
        //         {collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, item.transform.position.z);}
        //         // else if (item.transform.position.z < collision.transform.position.z)
        //         // {collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, item.transform.position.z);}
        //     }
        // }
        // //  else {collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0);}
    }

}

    // private void CheckCollision() {
    //     Vector2 playerPosition = new Vector2(playerRb.transform.position.x, playerRb.transform.position.y);
    //     List<Collider2D> collisionOverlaps = new List<Collider2D>();

    //     Debug.Log(gameObject.GetComponent<BoxCollider2D>().Overlap(playerPosition, 0, collisionOverlaps));
    //     foreach (var item in collisionOverlaps)
    //     {Debug.Log(item.name + " " + item.GetComponent<TilemapCollisionMonoscript>().elevation);

    //     if (item.isTrigger) {return;}
    //     else if (item.GetComponent<TilemapCollisionMonoscript>().elevation != playerElevation)
    //     {Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), item.gameObject.GetComponent<TilemapCollider2D>(), true);}
    //     else if (item.GetComponent<TilemapCollisionMonoscript>().elevation == playerElevation || item.GetComponent<TilemapCollisionMonoscript>().elevation == playerElevation + 1)//platform is too high or low
    //     {Debug.Log("asdf");
    //         Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), item.gameObject.GetComponent<TilemapCollider2D>(), false);}
    //     }
    // }