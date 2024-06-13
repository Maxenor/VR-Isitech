using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; // Le prefab de l'arme à équiper
    private GameObject currentWeaponLeft; // L'arme actuellement équipée sur la main gauche
    private GameObject currentWeaponRight; // L'arme actuellement équipée sur la main droite

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnWeaponPickedUp);
    }

    void OnWeaponPickedUp(XRBaseInteractor interactor)
    {
        // Vérifiez si l'interacteur est la main gauche ou droite
        if (interactor.CompareTag("LeftHand"))
        {
            AttachWeaponToHand(interactor.transform, ref currentWeaponLeft);
        }
        else if (interactor.CompareTag("RightHand"))
        {
            AttachWeaponToHand(interactor.transform, ref currentWeaponRight);
        }
    }

    void AttachWeaponToHand(Transform handTransform, ref GameObject currentWeapon)
    {
        // Si une arme est déjà équipée, la détruire
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // Instancier le prefab de l'arme comme enfant de la main
        currentWeapon = Instantiate(weaponPrefab, handTransform);
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localRotation = Quaternion.identity;

        // Désactiver la visibilité de la main ou de la manette
        XRController controller = handTransform.GetComponent<XRController>();
        if (controller != null && controller.model != null)
        {
            controller.model.gameObject.SetActive(false); // Utiliser gameObject pour accéder à SetActive
        }

        // Définir l'arme comme kinematic pour éviter les problèmes de physique
        Rigidbody rb = currentWeapon.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
