using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public Transform beltPosition;
    public GameObject beltCollider;
    public GameObject visualIndicator;

    private XRGrabInteractable currentItem;
    private bool isNearBelt = false;

    void Start()
    {
        visualIndicator.SetActive(false);
        if (beltCollider != null)
        {
            beltCollider.GetComponent<Collider>().isTrigger = true;
        }
    }

    void Update()
    {
        if (currentItem != null)
        {
            CheckHandNearBelt();
        }
    }

    public void OnSelectEnter(XRBaseInteractor interactor)
    {
        currentItem = interactor.selectTarget as XRGrabInteractable;
    }

    public void OnSelectExit(XRBaseInteractor interactor)
    {
        if (isNearBelt)
        {
            inventory.AddItem(currentItem.gameObject);
            Destroy(currentItem.gameObject);
            isNearBelt = false;
            visualIndicator.SetActive(false);
        }
        currentItem = null;
    }

    private void CheckHandNearBelt()
    {
        float distanceToBelt = Vector3.Distance(currentItem.transform.position, beltPosition.position);
        if (distanceToBelt < 0.2f && !isNearBelt)
        {
            isNearBelt = true;
            visualIndicator.SetActive(true);
        }
        else if (distanceToBelt >= 0.2f && isNearBelt)
        {
            isNearBelt = false;
            visualIndicator.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == currentItem.gameObject)
        {
            isNearBelt = true;
            visualIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentItem.gameObject)
        {
            isNearBelt = false;
            visualIndicator.SetActive(false);
        }
    }
}