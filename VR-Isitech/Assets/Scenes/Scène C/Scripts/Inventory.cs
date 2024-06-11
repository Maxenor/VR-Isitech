using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventorySlots = new List<GameObject>(3);
    public Transform beltPosition;
    public GameObject slotPrefab; // Un prefab de cube ou de sprite représentant un slot

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            inventorySlots.Add(null);

            // Créer visuellement les slots d'inventaire
            GameObject slot = Instantiate(slotPrefab, beltPosition);
            slot.transform.localPosition = new Vector3(i * 0.1f, 0, 0); // Espacement des slots
        }
    }

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i] == null)
            {
                inventorySlots[i] = item;
                item.SetActive(false); // Cacher l'objet
                return;
            }
        }
    }

    public void RemoveItem(int slotIndex, Transform hand)
    {
        if (inventorySlots[slotIndex] != null)
        {
            inventorySlots[slotIndex].SetActive(true); // Montrer l'objet
            inventorySlots[slotIndex].transform.position = hand.position;
            inventorySlots[slotIndex].transform.parent = hand;
            inventorySlots[slotIndex] = null;
        }
    }
}