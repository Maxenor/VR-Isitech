using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupItem : MonoBehaviour
{
    void Start()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Belt") && gameObject.CompareTag("Collectible"))
        {
            GameObject gameObjectCurrent = gameObject;
            InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
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