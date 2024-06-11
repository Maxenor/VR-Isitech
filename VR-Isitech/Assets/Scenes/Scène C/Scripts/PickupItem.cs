using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupItem : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private bool isNearBelt = false;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found in the scene");
        }

        // Attacher les événements
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    void OnDestroy()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        if (isNearBelt)
        {
            if (inventoryManager.AddItem(gameObject))
            {
                Debug.Log("Objet ajouté à l'inventaire.");
            }
            else
            {
                Debug.Log("Inventaire plein.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Belt"))
        {
            Debug.Log("belt");
            inventoryManager.AddItem(gameObject);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Belt"))
        {
            isNearBelt = false;
            Debug.Log("Left belt area");
        }
    }
}