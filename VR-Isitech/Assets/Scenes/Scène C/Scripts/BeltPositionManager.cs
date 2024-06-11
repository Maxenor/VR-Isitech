using UnityEngine;

public class BeltPositionManager : MonoBehaviour
{
    public Transform playerCamera;
    public float beltHeightOffset = -1.0f; // Offset de la taille par rapport à la tête (caméra)

    void Update()
    {
        if (playerCamera != null)
        {
            Vector3 beltPosition = playerCamera.position;
            beltPosition.y += beltHeightOffset;
            transform.position = beltPosition;
        }
    }
}