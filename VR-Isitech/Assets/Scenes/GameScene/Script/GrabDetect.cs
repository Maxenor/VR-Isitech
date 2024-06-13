using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabDetect : MonoBehaviour
{
    // Référence à l'objet XRGrabInteractable
    public XRGrabInteractable grabInteractable;

    private void OnEnable()
    {
        // Ajouter des listeners aux événements selectEntered et selectExited
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        // Retirer les listeners pour éviter les fuites de mémoire
        grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        grabInteractable.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Logique lorsque l'objet est saisi
        Debug.Log("Item grabbed: " + grabInteractable.gameObject.name);
        if (gameObject.GetComponent<Item>() == null) return;
        if (gameObject.GetComponent<Item>().inSlot)
        {
            gameObject.GetComponentInParent<Slot>().itemInSlot = null;
            gameObject.transform.parent = null;
            gameObject.GetComponent<Item>().inSlot = false;
            gameObject.GetComponent<Item>().currentSlot.ResetColor();   
            gameObject.GetComponent<Item>().currentSlot = null;
            

        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Logique lorsque l'objet est relâché
        Debug.Log("Item released: " + grabInteractable.gameObject.name);
    }
}