using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public int slotIndex;
    private InventoryManager inventoryManager;
    private bool isHandNear = false;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        if (isHandNear && Input.GetButtonUp("Grab")) // "Grab" est le bouton de prise
        {
            if (inventoryManager.IsSlotOccupied(slotIndex))
            {
                GameObject item = inventoryManager.RemoveItem(slotIndex);
                if (item != null)
                {
                    // Mettre l'objet dans la main de l'utilisateur
                    item.transform.SetParent(null);
                    item.SetActive(true);
                    Debug.Log("Objet sorti de l'inventaire.");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isHandNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isHandNear = false;
        }
    }
}