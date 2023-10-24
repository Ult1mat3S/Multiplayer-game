using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    //Create an Animator controller, create an Animation where the door opens,
    //another where the door closes.Then add a Bool parameter IsOpen,
    //when that parameter is true play the open animation, when false play the close animation.
    //Then just control that parameter through code

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null )
            {
                interactable.Interact(transform);
            }
        }
    }

        public IInteractable GetInteractableObject() {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) {
                if (collider.TryGetComponent(out IInteractable interactable)) {
                return interactable;
                }
        }
        return null;
    }
}
