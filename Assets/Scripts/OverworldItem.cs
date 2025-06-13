using UnityEngine;

public class OverworldItem : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.GetComponent<ItemInventory>().items.Add(gameObject.GetComponent<OverworldItem>());
        foreach (var item in collision.gameObject.GetComponent<ItemInventory>().items)
        {
            
            Debug.Log(item);
        }

        Destroy(gameObject);
    }
}
