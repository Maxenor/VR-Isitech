using System;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Inventory playerInventory;
    public Sprite itemSprite;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInventory.AddItem();
            Console.WriteLine("ajouté à l'inventaire");
            Destroy(gameObject); // detruit l'objet après ajout
        }
    }
}