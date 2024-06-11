using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Inventory inventory; // Reference to the inventory script

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            Debug.Log("Player collided with a collectible!");
            CollectItem(collision.gameObject);
        }
    }

    void CollectItem(GameObject item)
    {
        inventory.AddItem();

        // Optionally, destroy the item after collecting
        Destroy(item);
    }
}