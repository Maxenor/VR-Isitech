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
        // Détecter si l'utilisateur veut prendre un objet de l'inventaire
        if (isHandNear && Input.GetButtonUp("Fire1")) // Utilisez le bouton approprié pour attraper l'objet
        {
            if (inventoryManager.IsSlotOccupied(slotIndex))
            {
                GameObject item = inventoryManager.RemoveItem(slotIndex);
                if (item != null)
                {
                    // Mettre l'objet dans la main de l'utilisateur
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