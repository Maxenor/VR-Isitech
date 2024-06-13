using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    public InputActionProperty toggleInventoryAction; // Action pour le bouton de bascule
    public GameObject inventory; // Référence à l'objet inventaire

    private bool inventoryVisible = false; // État actuel de l'inventaire

    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(inventoryVisible); // Masquer l'inventaire au départ
    }

    // Update is called once per frame
    void Update()
    {
        // Mettre à jour les animations des mains
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        handAnimator.SetFloat("Grip", gripValue);

        // Lire la valeur de l'action de bascule
        if (toggleInventoryAction.action.WasPressedThisFrame())
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        inventoryVisible = !inventoryVisible;
        inventory.SetActive(inventoryVisible); // Afficher ou masquer l'inventaire
    }
}
