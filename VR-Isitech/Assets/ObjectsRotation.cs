using UnityEngine;

public class ObjectsRotation : MonoBehaviour
{
    // Vitesse de rotation en degrés par seconde
    public float rotationSpeed = 10f;

    void Update()
    {
        // Calculer l'angle de rotation pour cette frame
        float angle = rotationSpeed * Time.deltaTime;

        // Appliquer la rotation autour de l'axe Y
        transform.Rotate(Vector3.up, angle);
    }
}
