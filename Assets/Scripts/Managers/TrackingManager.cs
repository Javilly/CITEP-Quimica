using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ChallengeManager challengeManager;
    [SerializeField] private MenuManager menuManager;

    public void elementTracked(string elementSlug)
    {
        if (!inventoryManager.isInInventory(elementSlug))
        {
            inventoryManager.addElementToInventory(elementSlug);

            Element addedElement = inventoryManager.getElementBySlug(elementSlug);
            StartCoroutine(menuManager.elementAddedToInventory(addedElement.name, addedElement.sprite));
            if (challengeManager.hasActiveChallenge)
            {
                challengeManager.elementAddedToInventory();
            }
        }
    }
}
