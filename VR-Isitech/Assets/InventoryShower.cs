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
                spheresObjectArray[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show(int spheres) {
        for (int i = 0; i < spheresObjectArray.Length; i++) {  
            if (i < spheres) {
                spheresObjectArray[i].SetActive(true);
            } else {
                spheresObjectArray[i].SetActive(false);
            }  
        }
    }
}
