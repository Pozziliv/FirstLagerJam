using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterract : MonoBehaviour
{
    [SerializeField] private KeyCode _interractKey = KeyCode.E;
    [SerializeField] private float _sphereRadius = 0.5f;
    [SerializeField] private Transform _cameraPosition;

    private float _rayDistance = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(_interractKey))
        {
            Interract();
        }
    }

    private void Interract()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, _rayDistance);
        Collider[] targets = Physics.OverlapSphere(hit.point, _sphereRadius);

        foreach (Collider target in targets)
        {
            if (target.gameObject.TryGetComponent(out IInteractable interactable))
            {
                
                interactable.Interact();
                break;
            }
        }
    }
}
