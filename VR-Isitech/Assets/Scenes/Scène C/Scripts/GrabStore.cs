using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAndStore : MonoBehaviour
{
    public Inventory inventory;
    public Transform hand;
    private GameObject heldItem;
    public XRDirectInteractor directInteractor;

    void Update()
    {
        if (heldItem != null && IsHandNearBelt())
        {
            // Show visual cue to store item
            ShowStoreCue();
            if (Input.GetButtonDown("Drop")) // Assuming "Drop" is mapped to a VR controller button
            {
                inventory.AddItem(heldItem);
                heldItem = null;
            }
        }
    }

    void OnEnable()
    {
        directInteractor.selectEntered.AddListener(OnSelectEntered);
        directInteractor.selectExited.AddListener(OnSelectExited);
    }

    void OnDisable()
    {
        directInteractor.selectEntered.RemoveListener(OnSelectEntered);
        directInteractor.selectExited.RemoveListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (heldItem == null)
        {
            heldItem = args.interactableObject.transform.gameObject;
            heldItem.transform.parent = hand;
            heldItem.transform.position = hand.position;
        }
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        if (heldItem == args.interactableObject.transform.gameObject)
        {
            heldItem.transform.parent = null;
            heldItem = null;
        }
    }

    bool IsHandNearBelt()
    {
        // Check if hand is near the belt position
        return Vector3.Distance(hand.position, inventory.beltPosition.position) < 0.2f;
    }

    void ShowStoreCue()
    {
        Console.WriteLine("Store item in inventory");
    }
}