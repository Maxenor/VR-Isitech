using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public int maxSlots = 3;

    public Transform inventoryUI;

    void Start()
    {
        UpdateInventoryUI();
    }

    public void AddItem(GameObject item)
    {
        if (items.Count < maxSlots)
        {
            items.Add(item);
            UpdateInventoryUI();
        }
    }

    void UpdateInventoryUI()
    {
        for (int i = 0; i < inventoryUI.childCount; i++)
        {
            if (i < items.Count)
            {
                inventoryUI.GetChild(i).GetComponent<Renderer>().material = items[i].GetComponent<Renderer>().material;
            }
            else
            {
                inventoryUI.GetChild(i).GetComponent<Renderer>().material = null;
            }
        }
    }
}