using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField]
    private InventoryManager inventoryManager;

    [Header("Render Cameras Logic")]
    [SerializeField]
    private Canvas mainCanvas;

    [SerializeField]
    private Camera mainUICamera;

    [SerializeField]
    private Camera vuforiaCamera;

    [Header("Menu Selector")]
    [SerializeField]
    private TMP_Text badgeNumber;

    [Header("Inventory")]
    [SerializeField]
    private GameObject inventoryUI;

    [SerializeField]
    private GameObject elementInfoUI;

    [SerializeField]
    private TMP_Text elementInfoText;

    [Header("Camera")]
    [SerializeField]
    private GameObject scanCameraAssets;

    [SerializeField]
    private GameObject scanCameraUI;

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private TMP_Text cameraScoreText;

    [SerializeField]
    private TMP_Text cameraMoleculeText;

    [SerializeField]
    private GameObject notificationCanvas;

    [SerializeField]
    private Image notificationImage;

    [SerializeField]
    private TMP_Text notificationText;

    [Header("Main Menu")]
    [SerializeField]
    private GameObject mainMenu;

    [Header("Challenge")]
    [SerializeField]
    private GameObject challengeUI;

    [Header("Challenge - Difficulty")]
    [SerializeField]
    private GameObject challengeDificultyUI;

    [Header("Challenge - Introduction")]
    [SerializeField]
    private GameObject challengeIntroductionUI;

    [Header("Challenge - Question")]
    [SerializeField]
    private GameObject challengeQuestionUI;

    [SerializeField]
    private TMP_Text challengeScoreText;

    [SerializeField]
    private TMP_Text challengeMoleculeText;

    [SerializeField]
    private TMP_Text challengeQuestionText;

    [SerializeField]
    private Text challengeFirstResponseText;

    [SerializeField]
    private Text challengeSecondResponseText;

    [SerializeField]
    private Text challengeThirdResponseText;

    [SerializeField]
    private TMP_Text questionFeedback;

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private Toggle[] responseToggles;

    [Header("Challenge - Geometry")]
    [SerializeField]
    private GameObject challengeGeometryQuestionUI;

    [SerializeField]
    private Button firstGeometryOption;

    [SerializeField]
    private Button secondGeometryOption;

    [SerializeField]
    private Button thirdGeometryOption;

    [SerializeField]
    private TMP_Text geometryFeedback;

    [SerializeField]
    private Button geometryContinueButton;

    [Header("Challenge - Build Molecule")]
    [SerializeField]
    private GameObject challengeBuildMoleculeUI;

    [SerializeField]
    private GameObject[] elementToggles;

    [SerializeField]
    GameObject moleculeToBuildCanvas;

    [SerializeField]
    GameObject moleculeToBuild;

    [Header("Challenge - End Game")]
    [SerializeField]
    private GameObject endGameUI;

    [SerializeField]
    GameObject moleculeModelCanvas;

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private TMP_Text pointsText;

    [SerializeField]
    GameObject moleculeModel;

    [Header("Variables")]
    [SerializeField]
    private int challengeStep = 1;

    [SerializeField]
    private int inventoryCounter = 0;

    public void goToInventory()
    {
        mainCanvas.GetComponent<Canvas>().worldCamera = mainUICamera;
        scanCameraAssets.SetActive(false);
        scanCameraUI.SetActive(false);
        challengeUI.SetActive(false);
        mainMenu.SetActive(false);
        mainCamera.SetActive(true);
        inventoryUI.SetActive(true);
    }

    public void goToScanCamera()
    {
        mainCanvas.GetComponent<Canvas>().worldCamera = vuforiaCamera;
        inventoryUI.SetActive(false);
        mainCamera.SetActive(false);
        challengeUI.SetActive(false);
        mainMenu.SetActive(false);
        scanCameraAssets.SetActive(true);
        scanCameraUI.SetActive(true);
    }

    public void goToChallenge()
    {
        mainCanvas.GetComponent<Canvas>().worldCamera = mainUICamera;
        mainMenu.SetActive(false);
        scanCameraAssets.SetActive(false);
        scanCameraUI.SetActive(false);
        inventoryUI.SetActive(false);
        mainCamera.SetActive(true);
        challengeUI.SetActive(true);
        if (challengeStep == 1)
        {
            challengeIntroductionUI.SetActive(false);
            challengeQuestionUI.SetActive(false);
            challengeGeometryQuestionUI.SetActive(false);
            challengeBuildMoleculeUI.SetActive(false);
            endGameUI.SetActive(false);
            challengeDificultyUI.SetActive(true);
        }
        else if (challengeStep == 2)
        {
            challengeDificultyUI.SetActive(false);
            challengeQuestionUI.SetActive(false);
            challengeGeometryQuestionUI.SetActive(false);
            challengeBuildMoleculeUI.SetActive(false);
            endGameUI.SetActive(false);
            challengeIntroductionUI.SetActive(true);
        }
        else if (challengeStep == 3)
        {
            challengeDificultyUI.SetActive(false);
            challengeIntroductionUI.SetActive(false);
            challengeGeometryQuestionUI.SetActive(false);
            challengeBuildMoleculeUI.SetActive(false);
            endGameUI.SetActive(false);
            challengeQuestionUI.SetActive(true);
        }
        else if (challengeStep == 4)
        {
            challengeDificultyUI.SetActive(false);
            challengeIntroductionUI.SetActive(false);
            challengeQuestionUI.SetActive(false);
            challengeBuildMoleculeUI.SetActive(false);
            endGameUI.SetActive(false);
            challengeGeometryQuestionUI.SetActive(true);
        }
        else if (challengeStep == 5)
        {
            challengeDificultyUI.SetActive(false);
            challengeIntroductionUI.SetActive(false);
            challengeQuestionUI.SetActive(false);
            challengeGeometryQuestionUI.SetActive(false);
            endGameUI.SetActive(false);
            challengeBuildMoleculeUI.SetActive(true);
        }
        else if (challengeStep == 6)
        {
            challengeDificultyUI.SetActive(false);
            challengeIntroductionUI.SetActive(false);
            challengeQuestionUI.SetActive(false);
            challengeGeometryQuestionUI.SetActive(false);
            challengeBuildMoleculeUI.SetActive(false);
            endGameUI.SetActive(true);
        }
    }

    public void nextChallengeStep()
    {
        challengeStep++;
        goToChallenge();
    }

    public void previousChallengeStep()
    {
        challengeStep--;
        if (challengeStep == 0)
        {
            Application.Quit();
        }
        goToChallenge();
    }

    public void updateScoreText(string newText)
    {
        cameraScoreText.text = newText;
        challengeScoreText.text = newText;
    }

    public void updateMoleculeText(string newText)
    {
        cameraMoleculeText.text = newText;
        challengeMoleculeText.text = newText;
    }

    public void updateQuestionText(
        string question,
        string firstResponse,
        string secondResponse,
        string thirdResponse
    )
    {
        challengeQuestionText.text = question;
        challengeFirstResponseText.text = firstResponse;
        challengeSecondResponseText.text = secondResponse;
        challengeThirdResponseText.text = thirdResponse;
    }

    public IEnumerator elementAddedToInventory(string elementName, Sprite elementSprite)
    {
        inventoryCounter++;
        badgeNumber.text = inventoryCounter.ToString();
        notificationImage.sprite = elementSprite;
        notificationText.text = elementName;
        notificationCanvas.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        notificationCanvas.SetActive(false);
    }

    public void answerQuestion(string feedback, bool isOk)
    {
        if (isOk)
        {
            questionFeedback.color = new Color(0.1f, 0.8f, 0);
            continueButton.interactable = true;
        }
        else
        {
            questionFeedback.color = Color.red;
            continueButton.interactable = false;
        }
        questionFeedback.text = feedback;
    }

    public void updateGeometryOptionImage(
        Sprite firstOption,
        Sprite secondOption,
        Sprite thirdOption
    )
    {
        firstGeometryOption.GetComponent<Image>().sprite = firstOption;
        secondGeometryOption.GetComponent<Image>().sprite = secondOption;
        thirdGeometryOption.GetComponent<Image>().sprite = thirdOption;
    }

    public void answerGeometryQuestion(string feedback, bool isOk)
    {
        if (isOk)
        {
            geometryFeedback.color = new Color(0.1f, 0.8f, 0);
            geometryContinueButton.interactable = true;
        }
        else
        {
            geometryFeedback.color = Color.red;
            geometryContinueButton.interactable = false;
        }
        geometryFeedback.text = feedback;
    }

    public void updateBuildMoleculeToggles(Element[] elements)
    {
        for (int i = 0; i < elementToggles.Length; i++)
        {
            elementToggles[i].SetActive(false);
        }
        for (int i = 0; i < elements.Length; i++)
        {
            elementToggles[i].SetActive(true);
            elementToggles[i].transform.Find("Background").GetComponent<Image>().sprite = elements[
                i
            ].sprite;
        }
    }

    public void setMoleculeToBuild(GameObject moleculePrefab)
    {
        moleculeToBuild = Instantiate(moleculePrefab);
        moleculeToBuild.transform.SetParent(moleculeToBuildCanvas.transform, false);
        moleculeToBuild.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        moleculeToBuild.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        moleculeToBuild.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        moleculeToBuild.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }

    public void placeElement(Transform elementButton, Sprite elementSprite)
    {
        elementButton.GetComponent<Image>().sprite = elementSprite;
        elementButton.GetComponent<Image>().color = new Color(
            elementButton.GetComponent<Image>().color.r,
            elementButton.GetComponent<Image>().color.g,
            elementButton.GetComponent<Image>().color.b,
            1f
        );
        elementButton.Find("Image").gameObject.SetActive(false);
    }

    public void setMoleculeModel(GameObject moleculePrefab)
    {
        moleculeModel = Instantiate(moleculePrefab);
        moleculeModel.transform.SetParent(moleculeModelCanvas.transform, false);
    }

    public void restartGame()
    {
        challengeStep = 0;
        Destroy(moleculeToBuild);
        Destroy(moleculeModel);
        nextChallengeStep();
        challengeScoreText.text = "";
        cameraScoreText.text = "";

        for (int i = 0; i < responseToggles.Length; i++)
        {
            responseToggles[i].isOn = false;
        }

        questionFeedback.text = "";
        questionFeedback.color = Color.black;

        for (int i = 0; i < elementToggles.Length; i++)
        {
            elementToggles[i].GetComponent<Toggle>().isOn = false;
        }

        geometryFeedback.text = "";
    }

    public void setTimer(float timer)
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void setPoints(int points)
    {
        pointsText.text = "" + points;
    }

    public void toggleElementInfo(string elementSlug)
    {
        if (!elementInfoUI.activeSelf)
        {
            elementInfoText.text = inventoryManager
                .getElementBySlug(elementSlug)
                .elementDescription;
            ;
            elementInfoUI.SetActive(true);
        }
        else if (elementInfoUI.activeSelf)
        {
            elementInfoUI.SetActive(false);
        }
    }
}
