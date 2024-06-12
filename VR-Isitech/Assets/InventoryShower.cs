using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryShower : MonoBehaviour
{
    public GameObject[] spheresObjectArray;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spheresObjectArray.Length; i++) {
            if(spheresObjectArray[i] != null) {
                spheresObjectArray[i].AddComponent<GrabHandler>();
                spheresObjectArray[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show(int spheres) {
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        foreach (GameObject sp in spheresObjectArray) {
            sp.SetActive(false);
        }

        for (int i = 0; i < spheres; i++) {
            if(spheresObjectArray[i] != null) {
                spheresObjectArray[i].SetActive(true);
            }
        }
    }
}
