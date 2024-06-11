using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] slots; // Corresponds to inventory slots
    private int currentIndex = 0;

    void Start()
    {
        ClearSlots(); // Clear the inventory at the start
    }

    public void AddItem()
    {
        if (currentIndex < slots.Length)
        {
            slots[currentIndex].color = Color.green; // Change the color to indicate an item was added
            currentIndex++;
            Debug.Log("Item added to inventory");
        }
        else
        {
            Debug.Log("Inventory full!");
        }
    }

    public void ClearSlots()
    {
        foreach (var slot in slots)
        {
            slot.color = Color.white; // Reset the color
        }
        currentIndex = 0;
    }
}