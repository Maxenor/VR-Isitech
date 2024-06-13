using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject itemInSlot;
    public Image slotImage;
    Color originalColor;
    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
    }

    private void OnTriggerStay(Collider other)
    {
        if (itemInSlot != null) return;
        GameObject obj = other.gameObject;
        Debug.Log("Item detected: " + obj);
        if (!isItem(obj)) return;
        if (itemInSlot == null)
        {
            InsertItem(obj);
        }

    }
    bool isItem(GameObject obj)
    {
        return obj.GetComponent<Item>() != null;
    }
    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles =  obj.GetComponent<Item>().slotRotation;
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        itemInSlot = obj;
        slotImage.color = Color.green;
    }

    public void ResetColor (){
        slotImage.color = originalColor;   
    }
}

