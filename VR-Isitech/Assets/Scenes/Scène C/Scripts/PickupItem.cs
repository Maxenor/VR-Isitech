using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private bool isNearBelt = false;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        // Détecter si l'utilisateur met la main au niveau de la ceinture
        if (isNearBelt && Input.GetButtonUp("Grab")) // "Grab" est le bouton de relâchement
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
            isNearBelt = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Belt"))
        {
            isNearBelt = false;
        }
    }
}