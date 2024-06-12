using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupItem : MonoBehaviour
{
    private InventoryManager inventoryManager;

    void Start()
    {
        Transform parentTransform = transform.parent;
        inventoryManager = parentTransform.GetComponent<InventoryManager>();

        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found in the scene");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Belt"))
        {
            GameObject gameObjectCurrent = gameObject;
            bool added = inventoryManager.AddItem(gameObjectCurrent);
            if (added) {
                // Destroy(gameObjectCurrent);
                gameObjectCurrent.SetActive(false);
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