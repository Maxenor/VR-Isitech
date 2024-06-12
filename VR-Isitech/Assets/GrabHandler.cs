using UnityEngine;

public class GrabHandler : MonoBehaviour
{
    public void onGrab() {
        Debug.Log("onGrab");

        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();

        inventoryManager.RemoveItem();
    }
}
