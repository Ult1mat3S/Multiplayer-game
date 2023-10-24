using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer boxMeshRenderer;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material purpleMaterial;

    private bool isColorPurple;

    private void SetColorRed()
    {
        boxMeshRenderer.material = redMaterial;
    }

    private void SetColorPurple()
    {
        boxMeshRenderer.material = purpleMaterial;
    }

    private void ToggleColor()
    {
        isColorPurple = !isColorPurple;
        if (isColorPurple)
        {
            SetColorPurple();
        } else
        {
            SetColorRed();
        }
        }

    public void PushButton()
    {
        ToggleColor();
    }

    public void Interact(Transform interactorTransform)
    {
        PushButton();
    }

    public string GetInteractText()
    {
       return "Push Button";
    }
}
