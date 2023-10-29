using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GeneratorInteractable : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isActive;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ProgressGenerator()
    {
        isActive = !isActive;
        animator.SetBool("isActive", isActive);
        Debug.Log("Repairing");
    }

    public void Interact(Transform interactorTransform)
    {
        ProgressGenerator();
    }

    public string GetInteractText()
    {
        return "Repair";
    }
}
