using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupItem : MonoBehaviour
{
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found in the scene");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Belt"))
        {
            bool added = inventoryManager.AddItem(gameObject);
            if (added) {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Belt"))
        {
            Debug.Log("Left belt area");
        }
    }
}