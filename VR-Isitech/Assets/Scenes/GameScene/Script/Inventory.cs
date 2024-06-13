using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class InventoryVR : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;

    // Assignez ceci via l'Inspector ou par code
    public InputActionReference toggleInventoryAction;

    private void OnEnable()
    {
        toggleInventoryAction.action.performed += ToggleInventory;
    }

    private void OnDisable()
    {
        toggleInventoryAction.action.performed -= ToggleInventory;
    }

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }

    private void Update()
    {
        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }

    private void ToggleInventory(InputAction.CallbackContext context)
    {
        UIActive = !UIActive;
        Inventory.SetActive(UIActive);
    }
}
