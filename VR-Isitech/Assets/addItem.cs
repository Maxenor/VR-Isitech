using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class addItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter()");
 
        GameObject gameObject = other.gameObject;
        if (gameObject.name == "object" && gameObject.GetComponent<XRGrabInteractable>())
        {
            Debug.Log("Item dans inventaire !");
            AttachToCube(gameObject);
        }
    }
 
    void AttachToCube(GameObject item)
    {
        // Définir le cube (ce GameObject) comme parent de l'item
        item.transform.SetParent(this.transform);
 
        // Réinitialiser la position locale de l'item pour qu'il soit positionné correctement dans le cube
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        item.transform.localScale = Vector3.one;
 
        // Réduit la taille du cube
        item.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
 
        var rigidbody = item.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }
 
        // Remet le grab
        var grabInteractable = item.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(OnItemGrabbed);
        }
 
    }
 
    void OnItemGrabbed(SelectExitEventArgs args)
    {
        GameObject item = args.interactableObject.transform.gameObject;
 
        // Rendre le rigidbody non-cinématique pour permettre les interactions physiques
        var rigidbody = item.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = false;
        }
 
        // Permettre à l'item d'être repris
        var grabInteractable = item.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(OnItemGrabbed); // Nettoyer l'événement pour éviter les appels multiples
        }
 
        // Réinitialiser l'échelle de l'item pour sa taille originale
        item.transform.localScale = Vector3.one;
    }
}
