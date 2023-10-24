using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractable {

    [SerializeField] private string InteractText;
   public void Interact(Transform interactorTransform)
    {
        Debug.Log("Interact!");
    }


    public string GetInteractText()
    {
        return InteractText;
    }
}
