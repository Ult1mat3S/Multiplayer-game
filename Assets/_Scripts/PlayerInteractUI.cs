using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TMP_Text InteractTMP_Text;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }

    }

    private void Show(IInteractable interactable)
    {
        containerGameObject.SetActive(true);
        InteractTMP_Text.text = interactable.GetInteractText();
        Debug.Log("showing");
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
        Debug.Log("hiding");
    }
}
