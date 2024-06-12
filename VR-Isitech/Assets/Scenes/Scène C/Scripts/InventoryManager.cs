using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>(3);
    public Camera cameraGame;

    void Start()
    {

    }

    public bool AddItem(GameObject item)
    {
        for (int i = 0; i < items.Capacity; i++)
        {
            if (items.Count <= i)
            {
                Debug.Log("On ajoute :");
                Debug.Log(item);
                items.Add(item);
                InventoryShower inventoryShower = FindObjectOfType<InventoryShower>();
                inventoryShower.show(items.Count);
                return true;
            }
        }
        Debug.Log("Inventory is full");
        return false;
    }

    public void RemoveItem()
    {
        GameObject item = items[0];
        items.RemoveAt(0);

        // Vector3 positionCamera = cameraGame.transform.position;
        // Quaternion rotationCamera = cameraGame.transform.rotation;
        // Vector3 positionDevantCamera = positionCamera + (rotationCamera * Vector3.forward * 3f);
        // item.transform.position = positionDevantCamera;

        item.SetActive(true);
        InventoryShower inventoryShower = FindObjectOfType<InventoryShower>();
        inventoryShower.show(items.Count);

        Debug.Log($"Item removed from slot {0}");
    }

    public bool IsSlotOccupied(int slotIndex)
    {
        return items[slotIndex] != null;
    }
}