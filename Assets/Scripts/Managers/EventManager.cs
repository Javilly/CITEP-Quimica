using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private Transform moleculeGO;

    [SerializeField]
    private ChallengeManager challengeManager;

    [SerializeField]
    private Transform moleculePrefab;

    public void enableButtons()
    {
        Transform moleculePrefab = moleculeGO.GetChild(0);
        foreach (Transform child in moleculePrefab)
        {
            if (child.name.Contains("Element button"))
            {
                child
                    .GetComponent<Button>()
                    .onClick
                    .AddListener(() => challengeManager.placeElement(child.tag, child));
            }
        }
    }

    public void disableButton(string buttonName)
    {
        Transform moleculePrefab = moleculeGO.GetChild(0);

        moleculePrefab.Find(buttonName).GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
