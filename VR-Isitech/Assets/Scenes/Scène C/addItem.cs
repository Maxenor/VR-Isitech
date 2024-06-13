using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;  // Ajouté pour SceneManager

public class addItem : MonoBehaviour
{
    
    public Color canAddColor = Color.green;
    public Color originalColor = new Color(1, 1, 1, 0);
    private Renderer slotRenderer;
    private Dictionary<GameObject, bool> inventoryItems = new Dictionary<GameObject, bool>();
    private void Start()
    {
        slotRenderer = GetComponent<Renderer>();
        slotRenderer.material.color = originalColor;
    }
    private void Update()
    {
       if(inventoryItems.Count == 0 )
       {
        slotRenderer.material.color = canAddColor;
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter()");

        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("collectible") && gameObject.GetComponent<XRGrabInteractable>())
        {
            
            if (inventoryItems.Count == 0)
            {
                AttachToCube(gameObject);
            }
            else
            {
                Debug.Log("Inventaire déjà plein.");
              
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("collectible") && gameObject.GetComponent<XRGrabInteractable>())
        {
            slotRenderer.material.color = originalColor;
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

        // Réduit la taille de l'item
        item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

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

        // Marquer l'objet comme étant dans un inventaire
        if (!inventoryItems.ContainsKey(item))
        {
            inventoryItems.Add(item, true);
        }
        else
        {
            inventoryItems[item] = true;
        }
        slotRenderer.material.color = originalColor;
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

        // Détacher l'objet du parent (inventaire) et l'attacher à la scène principale
        item.transform.SetParent(null);
        SceneManager.MoveGameObjectToScene(item, SceneManager.GetActiveScene());

        // Permettre à l'item d'être repris
        var grabInteractable = item.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(OnItemGrabbed); // Nettoyer l'événement pour éviter les appels multiples
        }

        // Réinitialiser l'échelle de l'item pour sa taille originale
        item.transform.localScale = Vector3.one;

        // Marquer l'objet comme n'étant plus dans un inventaire
        if (inventoryItems.ContainsKey(item))
        {
            inventoryItems[item] = false;
            inventoryItems.Remove(item); // Retirer l'objet du dictionnaire lorsqu'il est sorti de l'inventaire
        }
        slotRenderer.material.color = originalColor;
    }
}
