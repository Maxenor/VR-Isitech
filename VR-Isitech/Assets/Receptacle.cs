using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Receptacle : MonoBehaviour
{
    public GameObject correctObject;
    public Material triggeredMaterial;
    private Material originalMaterial;
    private bool objectPlaced = false;

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!objectPlaced && other.gameObject == correctObject)
        {
            objectPlaced = true;
            other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            other.gameObject.transform.position = transform.position;
            other.gameObject.transform.rotation = transform.rotation;
            GetComponent<Renderer>().material = triggeredMaterial;
        }
    }
}
