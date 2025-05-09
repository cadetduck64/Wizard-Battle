using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollisionMonoscript : MonoBehaviour
{

    public List <Collider2D> ignoreList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ignoreList.Add(gameObject.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ignoreList.Count);
                if (ignoreList.Count >= 0)
        {
            for (int i = 0; i < ignoreList.Count; i++)
            {
                // Debug.Log(item.transform.position.z);
                if (ignoreList[i].transform.position.z == gameObject.transform.position.z)
                {Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), ignoreList[i], false);
                ignoreList.RemoveAt(i);
                }

            }

            // foreach (var item in ignoreList)
            // {
            //     Debug.Log(item.transform.position.z);
            //     if (item.transform.position.z == gameObject.transform.position.z)
            //     {Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), item, false);}
            // }
        }
    }
    
    

    
    void OnCollisionEnter2D(Collision2D collision)  {
         if (!collision.gameObject.CompareTag("Platform") && collision.transform.position.z != gameObject.transform.position.z)
        {Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>(), true);
        Debug.Log("ignoring: " + collision.gameObject.name);
        ignoreList.Add(collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
