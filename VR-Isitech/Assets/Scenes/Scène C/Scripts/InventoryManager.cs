using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> inventorySlots = new List<GameObject>(3);
    public Transform beltPosition; // La position de la ceinture de l'utilisateur

    private GameObject[] items = new GameObject[3]; // Tableau pour stocker les objets

    void Start()
    {
        // Initialiser les emplacements de l'inventaire à la ceinture
        for (int i = 0; i < 3; i++)
        {
            GameObject slot = inventorySlots[i];
            slot.transform.SetParent(beltPosition);
            slot.transform.localPosition = new Vector3(i * 0.2f - 0.2f, 0, 0); // Espacement des emplacements
        }
    }

    public bool AddItem(GameObject item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                item.transform.SetParent(inventorySlots[i].transform);
                item.transform.localPosition = Vector3.zero;
                item.SetActive(false); // Masquer l'objet
                return true;
            }
        }
        return false;
    }

    public GameObject RemoveItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < items.Length && items[slotIndex] != null)
        {
            GameObject item = items[slotIndex];
            items[slotIndex] = null;
            item.SetActive(true); // Afficher l'objet
            item.transform.SetParent(null);
            return item;
        }
        return null;
    }

    public bool IsSlotOccupied(int slotIndex)
    {
        return items[slotIndex] != null;
    }
}