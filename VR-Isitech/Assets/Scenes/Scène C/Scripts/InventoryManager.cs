using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>(3);
    public Camera cameraGame;
    public Transform userTransform; // Transform du joueur
    public float distanceInFrontOfUser = 2.0f; // Distance devant l'utilisateur où l'objet doit apparaître
    public float minHeight = 2.0f;

    void Start()
    {

    }
    public bool AddItem(GameObject item)
    {
        if (items.Count <= items.Capacity)
        {
            Debug.Log("On ajoute :");
            Debug.Log(item);
            items.Add(item);
            InventoryShower inventoryShower = FindObjectOfType<InventoryShower>();
            inventoryShower.show(items.Count);
            Debug.Log(items.Count);
            return true;
        }
        Debug.Log("Inventory is full");
        return false;
    }
    public void RemoveItem()
    {
        if (items.Count != 0  )
        {
            // Récupère l'objet à retirer de l'inventaire
            GameObject item = items[0];
            items.RemoveAt(0);
            // Met l'objet actif
            item.SetActive(true);

            // Calcule la nouvelle position basée sur la position du joueur et la direction où il regarde
            Vector3 newPosition = userTransform.position + userTransform.forward * distanceInFrontOfUser;

        // Vérifier et ajuster la hauteur minimale
            if (newPosition.y < minHeight)
            {
                newPosition.y = minHeight;
            }
            // Place l'objet à la nouvelle position
            item.transform.position = newPosition;

            //item.transform.rotation = userTransform.rotation;

            Debug.Log(newPosition);
            Debug.Log(userTransform.rotation);

            // Met à jour l'affichage de l'inventaire
            InventoryShower inventoryShower = FindObjectOfType<InventoryShower>();
            inventoryShower.show(items.Count);

            Debug.Log($"Item removed from slot {0} and placed at {newPosition}");
        }
        else
        {
            Debug.LogWarning("No items to remove from inventory.");
        }
    }

    public bool IsSlotOccupied(int slotIndex)
    {
        return items[slotIndex] != null;
    }
}