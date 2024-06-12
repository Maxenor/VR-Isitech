using UnityEngine;

public class GrabHandler : MonoBehaviour
{
    public int sphereIndex;

    public void onGrab() {
        Debug.Log("onGrab");

        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();

        inventoryManager.RemoveItem();
    }
}
