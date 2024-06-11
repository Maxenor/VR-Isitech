using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InventorySlot : MonoBehaviour
{
    public int slotIndex;
    private InventoryManager inventoryManager;
    private bool isHandNear = false;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found in the scene");
        }
        else
        {
            // Attacher les événements seulement si inventoryManager n'est pas null
            var slotInteractable = GetComponent<XRSimpleInteractable>();
            if (slotInteractable != null)
            {
                slotInteractable.selectEntered.AddListener(OnSelectEntered);
            }
            else
            {
                Debug.LogError("XRSimpleInteractable component not found on slot");
            }
        }
    }

    void OnDestroy()
    {
        if (inventoryManager != null)
        {
            var slotInteractable = GetComponent<XRSimpleInteractable>();
            if (slotInteractable != null)
            {
                slotInteractable.selectEntered.RemoveListener(OnSelectEntered);
            }
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (isHandNear && inventoryManager.IsSlotOccupied(slotIndex))
        {
            GameObject item = inventoryManager.RemoveItem(slotIndex);
            if (item != null)
            {
                Debug.Log($"Objet sorti de l'inventaire du slot {slotIndex}");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isHandNear = true;
            Debug.Log($"Hand near slot {slotIndex}");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isHandNear = false;
            Debug.Log($"Hand left slot {slotIndex}");
        }
    }
}