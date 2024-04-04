using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private TMP_Text introductionUI;

    [Header("Managers")]
    [SerializeField]
    private MenuManager menuManager;

    [SerializeField]
    private InventoryManager inventoryManager;

    [SerializeField]
    private EventManager eventManager;

    [Header("Challenge")]
    [SerializeField]
    private Challenge[] challenges;

    [SerializeField]
    public Challenge actualChallenge;

    [SerializeField]
    public int difficulty;

    [SerializeField]
    private Sprite[] moleculeGeometrySprites;

    [SerializeField]
    private string elementSelected = "";

    [SerializeField]
    private GameObject[] correctGeometries;

    [SerializeField]
    private int elementsLeftToPlace;

    [SerializeField]
    private GameObject[] moleculeModels;

    [Header("Variables")]
    [SerializeField]
    public bool hasActiveChallenge;

    [SerializeField]
    private int points = 0;

    [SerializeField]
    private float timer = 0;

    [SerializeField]
    public bool challengeFinished;

    void Start()
    {
        challenges = new Challenge[10];
        challenges[0] = new Challenge(
            "El amoníaco constituye una fuente de nitrógeno para muchos procesos químicos. En particular, se investiga su uso para capturar CO2, un gas de efecto invernadero. En este desafío el reto es construir una molécula de amoníaco.",
            1,
            "Amoníaco",
            "NH3",
            new Element[2] { inventoryManager.inventory[4], inventoryManager.inventory[5] },
            "¿Cuál es la geometría electrónica que presenta la molécula de amoníaco?",
            "Tetraédrica",
            "Piramidal con base triangular",
            "Plana trigonal",
            1,
            new string[3]
            {
                "Respuesta correcta. ¡Muy bien!",
                "¡Intentá de nuevo! Observá que esta representación corresponde a la geometría molecular, que difiere con la geometría electrónica ya que hay un par electrónico libre sobre el nitrógeno.",
                "¡Intentá de nuevo! Observá que el átomo de nitrógeno central se encuentra unido a 3 átomos de hidrógeno mediante enlaces covalentes simples, y además hay un par electrónico libre sobre el átomo de nitrógeno."
            },
            moleculeGeometrySprites[0],
            moleculeGeometrySprites[1],
            moleculeGeometrySprites[2],
            1,
            new string[3]
            {
                "Geometría correcta. ¡Muy bien!",
                "Esta geometría no minimiza la repulsión electrónica. ¡Volvé a intentar!",
                "Esta geometría no minimiza la repulsión electrónica. ¡Volvé a intentar!"
            },
            correctGeometries[0],
            4,
            moleculeModels[0]
        );

        challenges[1] = new Challenge(
            "El agua resulta esencial para la vida en la Tierra, y también actúa como gas de efecto invernadero ante el calentamiento global. En este desafío te proponemos construir una molécula de agua.",
            1,
            "Agua",
            "H2O",
            new Element[2] { inventoryManager.inventory[5], inventoryManager.inventory[3] },
            "Sabiendo que la geometría electrónica de una molécula de agua es tetraédrica, ¿qué ángulo de enlace HÔH esperarías?",
            "109,5°",
            "<109°",
            "120°",
            2,
            new string[3]
            {
                "¡Intentá de nuevo! Si bien la geometría electrónica para una molécula de agua es tetraédrica, su geometría molecular es angular y, para esta geometría, el ángulo de enlace esperado es menor.",
                "Respuesta correcta. ¡Muy bien!",
                "¡Intentá de nuevo! Las moléculas que presentan ángulos de 120° son aquellas de geometría molecular plana trigonal."
            },
            moleculeGeometrySprites[3],
            moleculeGeometrySprites[4],
            moleculeGeometrySprites[5],
            2,
            new string[3]
            {
                "Esta geometría no minimiza la repulsión electrónica. ¡Volvé a intentar!",
                "Geometría correcta. ¡Muy bien!",
                "Esta geometría es la geometría electrónica, no la molecular. ¡Volvé a intentar!"
            },
            correctGeometries[1],
            3,
            moleculeModels[1]
        );

        challenges[2] = new Challenge(
            "El dióxido de carbono es un gas de efecto invernadero cuya concentración en la atmósfera terrestre se ha incrementado por combustión de derivados del petróleo. En este desafío te proponemos construir esta molécula triatómica.",
            1,
            "Dióxido de carbono",
            "CO2",
            new Element[2] { inventoryManager.inventory[0], inventoryManager.inventory[3] },
            "Basándote en la geometría molecular del CO2, ¿qué podrías decir acerca de la polaridad de sus enlaces y la polaridad de la molécula?",
            "El enlace C=O es polar y la molécula CO2 es polar.",
            "El enlace C=O es no polar y la molécula CO2 no polar.",
            "El enlace C=O es polar y la molécula CO2 es no polar.",
            3,
            new string[3]
            {
                "¡Intentá de nuevo! Si bien cada enlace C=O es polar, la molécula de CO2 tiene geometría molecular lineal y es simétrica. Esto hace que los momentos dipolares de cada enlace se cancelan y el momento dipolar total sea nulo. Por lo tanto, la molécula es no polar.",
                "¡Intentá de nuevo! Si bien la molécula de CO2 es no polar, cada uno de los enlaces C=O son polares.",
                "Respuesta correcta. ¡Muy bien!"
            },
            moleculeGeometrySprites[6],
            moleculeGeometrySprites[4],
            moleculeGeometrySprites[7],
            3,
            new string[3]
            {
                "Geometría incorrecta. ¡Volvé a intentar!",
                "Geometría incorrecta, observá que el carbono no presenta pares libres. ¡Volvé a intentar!",
                "Geometría correcta. ¡Muy bien!"
            },
            correctGeometries[2],
            3,
            moleculeModels[2]
        );

        challenges[3] = new Challenge(
            "El trióxido de azufre es un gas nocivo producido por la quema de derivados del petróleo azufrados, y es responsable de la lluvia ácida. En este desafío el reto es construir esta molécula tetraatómica.",
            1,
            "Trióxido de azufre",
            "SO3",
            new Element[2] { inventoryManager.inventory[1], inventoryManager.inventory[3] },
            "¿Cuáles son las fuerzas intermoleculares que esperarías encontrar en una molécula de SO3?",
            "London y dipolo-dipolo",
            "London",
            "Dipolo-dipolo",
            2,
            new string[3]
            {
                "¡Intentá de nuevo! Si bien las fuerzas de London están presentes (como en toda molécula), la geometría molecular del SO3 es plana trigonal, los momentos dipolares de cada enlace se cancelan entre sí, haciendo que la molécula sea no polar. Una molécula no polar no presenta interacciones dipolo-dipolo.",
                "Respuesta correcta. ¡Muy bien!",
                "¡Intentá de nuevo! Observá que la geometría molecular del SO3 es plana trigonal, de manera que los momentos dipolares de cada enlace se cancelan entre sí, haciendo que la molécula sea no polar. Una molécula no polar no presenta interacciones dipolo-dipolo."
            },
            moleculeGeometrySprites[0],
            moleculeGeometrySprites[8],
            moleculeGeometrySprites[9],
            2,
            new string[3]
            {
                "Geometría incorrecta, observá que no hay pares libres sobre el azufre. ¡Volvé a intentar!",
                "Geometría correcta. ¡Muy bien!",
                "Esta geometría no minimiza la repulsión electrónica. ¡Volvé a intentar!"
            },
            correctGeometries[3],
            4,
            moleculeModels[3]
        );

        challenges[4] = new Challenge(
            "Los CFC o clorofuorocarburos son gases muy nocivos que se han empleado como refrigerantes y propelentes, y son destructores de la capa de ozono. En este desafío el reto es construir una molécula de triclorofluorometano.",
            2,
            "Triclorofluorometano",
            "CCl3F",
            new Element[3]
            {
                inventoryManager.inventory[0],
                inventoryManager.inventory[6],
                inventoryManager.inventory[2]
            },
            "El CCl3F tiene un punto de ebullición mayor al CH4 si bien ambas moléculas son tetraédricas. ¿Qué opción elegirías para describir esta diferencia?",
            "La molécula CCl3F forma enlaces de H, mientras que CH4 es incapaz de hacerlo.",
            "Al ser polares ambas moléculas, el momento dipolar en CCl3F es mayor al momento dipolar en CH4.",
            "CCl3F presenta interacciones de London y dipolo-dipolo, mientras que CH4 sólo presenta fuerzas de London de menor intensidad.",
            3,
            new string[3]
            {
                "¡Intentá de nuevo! Recordá que los enlaces de hidrógeno intermoleculares sólo tienen lugar cuando existe H unido a los elementos N, O ó F. En este caso, no se encuentran en ninguna de las dos.",
                "¡Intentá de nuevo! Observá que la molécula CCl3F es polar, mientras que CH4 no lo es. Además, las interacciones de London en CCl3F son más intensas respecto a CH4.",
                "Respuesta correcta. ¡Muy bien!"
            },
            moleculeGeometrySprites[10],
            moleculeGeometrySprites[11],
            moleculeGeometrySprites[5],
            3,
            new string[3]
            {
                "Esta geometría no minimiza la repulsión electrónica. ¡Volvé a intentar!x`",
                "Esta geometría no minimiza la repulsión electrónica. ¡Volvé a intentar!",
                "Geometría correcta. ¡Muy bien!"
            },
            correctGeometries[4],
            5,
            moleculeModels[4]
        );

        challenges[5] = new Challenge(
            "El llamado bioetanol es un biocombustible que puede obtenerse por fermentación de biomasa. Su uso como fuente alternativa a los combustibles fósiles presenta ventajas y desventajas. En este desafío deberás construir una molécula de etanol.",
            2,
            "Etanol",
            "C2H6O",
            new Element[3]
            {
                inventoryManager.inventory[0],
                inventoryManager.inventory[5],
                inventoryManager.inventory[3]
            },
            "¿Cuáles de estas opciones describen a la molécula de etanol?",
            "Es un alcohol, forma enlaces de hidrógeno con el agua y su temperatura de ebullición es superior a la del etano.",
            "Pertenece a la familia de los alcoholes, es una molécula polar y es soluble en metanol pero insoluble en agua.",
            "Es un alcohol, forma enlaces de hidrógeno con el agua y su temperatura de ebullición es superior a la del agua.",
            1,
            new string[3]
            {
                "Respuesta correcta. ¡Excelente!",
                "¡Intentá de nuevo! Si bien es un alcohol y se trata de una molécula polar, resulta soluble en metanol y también en agua, ya que puede formar enlaces de hidrógeno con ambos compuestos y su cadena carbonada es relativamente pequeña.",
                "¡Intentá de nuevo! Si bien es un alcohol y forma enlaces de hidrógeno con el agua, su temperatura de ebullición es menor a la del agua, ya que la capacidad del etanol para formar enlaces de hidrógeno es menor a la del agua."
            },
            moleculeGeometrySprites[12],
            moleculeGeometrySprites[13],
            moleculeGeometrySprites[14],
            1,
            new string[3]
            {
                "Geometría correcta. ¡Muy bien!",
                "Esta geometría representa al metanol. ¡Volvé a intentar!",
                "Esta geometría no representa al etanol. ¡Volvé a intentar!"
            },
            correctGeometries[5],
            9,
            moleculeModels[5]
        );

        challenges[6] = new Challenge(
            "El isopreno o 2-metil-1,3-butadieno es un hidrocarburo nocivo para el medio ambiente y es empleado en la fabricación de polímeros similares al caucho natural. En este desafío deberás construir una molécula de isopreno.",
            2,
            "metil-1,3-butadieno",
            "C5H8",
            new Element[2] { inventoryManager.inventory[0], inventoryManager.inventory[5] },
            "¿Cuáles de estas opciones describen a la molécula de isopreno?",
            "Pertenece a la familia de los alquenos y tiene el mismo número de átomos de hidrógeno que el 2-metilbutano.",
            "Pertenece a la familia de los alquenos, presenta 2 insaturaciones y es isómero estructural del 1,3-pentadieno.",
            "Se trata de un alqueno, presenta 2 insaturaciones, y es soluble en agua.",
            2,
            new string[3]
            {
                "¡Intentá de nuevo! Recordá que los alquenos son compuestos insaturados, presentan un número de átomos de hidrógeno menor que sus alcanos equivalentes.",
                "Respuesta correcta. ¡Excelente!",
                "¡Intentá de nuevo! El compuesto no es soluble en agua. Recordá que deben presentar fuerzas intermoleculares similares para ser solubles."
            },
            moleculeGeometrySprites[15],
            moleculeGeometrySprites[16],
            moleculeGeometrySprites[17],
            2,
            new string[3]
            {
                "Geometría incorrecta, observá la posición de los dobles enlaces. ¡Volvé a intentar!",
                "Geometría correcta. ¡Muy bien!",
                "Geometría incorrecta. ¡Volvé a intentar!"
            },
            correctGeometries[6],
            13,
            moleculeModels[6]
        );

        challenges[7] = new Challenge(
            "Los ftalatos como el DMP o benceno-1,2-dicarboxilato de dimetilo se emplean como plastificantes y son grandes contaminantes de aguas, afectando especies marinas y, potencialmente, la humana. En este desafío, el reto es construir una molécula de DMP.",
            3,
            "Benceno-1,2-dicarboxilato de dimetilo",
            "C10H10O4",
            new Element[3]
            {
                inventoryManager.inventory[0],
                inventoryManager.inventory[3],
                inventoryManager.inventory[5]
            },
            "¿Qué grupos funcionales reconocés en esta molécula y qué fuerzas intermoleculares no presenta respecto a un ácido carboxílico?",
            "Dos grupos éter. No presenta enlaces de hidrógeno.",
            "Dos grupos éster. No presenta fuerzas dipolo-dipolo.",
            "Dos grupos éster. No presenta enlaces de hidrógeno.",
            3,
            new string[3]
            {
                "¡Intentá de nuevo! Los éteres R-O-R´presentan dos cadenas carbonadas unidas a un átomo de oxígeno, mientras que los ésteres presentan el grupo funcional –COOR.",
                "¡Intentá de nuevo! Tanto los ésteres RCOOR´como los ácidos carboxílicos RCOOH presentan fuerzas dipolo-dipolo ya que ambos grupos funcionales son polares.",
                "Respuesta correcta. ¡Excelente!"
            },
            moleculeGeometrySprites[18],
            moleculeGeometrySprites[19],
            moleculeGeometrySprites[20],
            3,
            new string[3]
            {
                "Geometría incorrecta, observá que debe presentar sustituyentes en posiciónes 1 y 2. ¡Volvé a intentar!",
                "Esta geometría corresponde a un ácido dicarboxílico. ¡Volvé a intentar!",
                "Geometría correcta. ¡Muy bien!"
            },
            correctGeometries[7],
            24,
            moleculeModels[7]
        );

        challenges[8] = new Challenge(
            "La vainillina o 4-hidroxi-3-metoxibenzaldehído es un compuesto natural producido por algunas plantas cuya versión sintética, fabricada a partir de un derivado petroquímico o de la industria papelera, es empleada en cosmética y alimentos. En este desafío el reto es construir una molécula de vainillina.",
            3,
            "hidroxi-3-metoxibenzaldehido",
            "C8H8O3",
            new Element[3]
            {
                inventoryManager.inventory[0],
                inventoryManager.inventory[3],
                inventoryManager.inventory[5]
            },
            "¿Qué grupos funcionales reconocés en esta molécula? ¿Esperarías que fuera soluble en agua o en hexano?",
            "Grupos: carbonilo de aldehído, éster y fenol. Soluble en agua y soluble hexano.",
            "Grupos: carbonilo de aldehído, éter y fenol. Soluble en agua e insoluble en hexano.",
            "Grupos: carbonilo de cetona, éter y fenol. Soluble en agua y soluble en hexano.",
            2,
            new string[3]
            {
                "¡Intentá de nuevo! Observá que no se trata de un éster sino de un grupo éter, y que no es soluble en hexano sino en agua, por la presencia de grupos polares capaces de formar enlaces de hidrógeno con el agua.",
                "Respuesta correcta. ¡Excelente!",
                "¡Intentá de nuevo! Observá que no se trata de un carbonilo de cetona sino de aldehído, y que no es soluble en hexano sino en agua, por la presencia de grupos polares capaces de formar enlaces de hidrógeno con el agua."
            },
            moleculeGeometrySprites[21],
            moleculeGeometrySprites[22],
            moleculeGeometrySprites[23],
            2,
            new string[3]
            {
                "Geometría incorrecta, observá la posición del grupo OH. ¡Volvé a intentar!",
                "Geometría correcta. ¡Muy bien!",
                "Geometría incorrecta, observá la posición del grupo OH. ¡Volvé a intentar!"
            },
            correctGeometries[8],
            19,
            moleculeModels[8]
        );

        challenges[9] = new Challenge(
            "La asparagina es un aminoácido importante en la fotosíntesis. En este desafío, el reto es construir una molécula de asparagina. Presenta una cadena saturada de 4 átomos de carbono con un grupo ácido carboxílico en posición 1, un grupo amino en posición 2, y un grupo amida en posición 4.",
            3,
            "Asparagina",
            "C4H8N2O3",
            new Element[4]
            {
                inventoryManager.inventory[0],
                inventoryManager.inventory[4],
                inventoryManager.inventory[3],
                inventoryManager.inventory[5]
            },
            "¿Qué grupos funcionales reconocés en esta molécula? ¿Esperarías que fuera soluble en agua?",
            "Grupos: ácido carboxílico, amina y carbonilo de cetona. Soluble en agua.",
            "Grupos: éster, amina y amida. Insoluble en agua.",
            "Grupos: ácido carboxílico, amina y amida. Soluble en agua.",
            3,
            new string[3]
            {
                "¡Intentá de nuevo! Observá que se trata de un grupo amida y no un carbonilo de cetona. El compuesto es soluble en agua por la presencia de grupos polares capaces de formar enlaces de hidrógeno con el agua.",
                "¡Intentá de nuevo! Observá que se trata de un ácido carboxílico y no de un éster. Además, el compuesto es soluble en agua por la presencia de grupos polares capaces de formar enlaces de hidrógeno con el agua.",
                "Respuesta correcta. ¡Excelente!"
            },
            moleculeGeometrySprites[24],
            moleculeGeometrySprites[25],
            moleculeGeometrySprites[26],
            3,
            new string[3]
            {
                "Geometría incorrecta, la cadena carbonada debe ser saturada. ¡Volvé a intentar!",
                "Geometría incorrecta, no presenta el grupo amino. ¡Volvé a intentar!",
                "Geometría correcta. ¡Muy bien!"
            },
            correctGeometries[9],
            17,
            moleculeModels[9]
        );
    }

    void Update()
    {
        if (hasActiveChallenge && !challengeFinished)
        {
            timer += Time.deltaTime;
        }
    }

    public void restartGame()
    {
        hasActiveChallenge = false;
        elementSelected = "";
        points = 0;
        timer = 0;
        menuManager.restartGame();
    }

    public void placeElement(string buttonElement, Transform buttonGO)
    {
        if (buttonElement == elementSelected)
        {
            eventManager.disableButton(buttonGO.gameObject.name);
            Sprite elementSprite = inventoryManager
                .getElementBySymbol(buttonGO.gameObject.tag)
                .sprite;
            menuManager.placeElement(buttonGO, elementSprite);
            elementsLeftToPlace--;

            if (elementsLeftToPlace == 0)
            {
                challengeFinished = true;
                menuManager.setTimer(timer);
                menuManager.setPoints(points);
                StartCoroutine(nextChallengeStepWithSleep(1));
            }
        }
    }

    public void changeElementSelected(int toggleId)
    {
        elementSelected = actualChallenge.necessaryElements[toggleId].symbol;
    }

    public void answerGeometryQuestion(int geometrySelected)
    {
        if (actualChallenge.correctGeometryOption == geometrySelected)
        {
            menuManager.answerGeometryQuestion(
                actualChallenge.moleculeGeometryFeedbacks[geometrySelected - 1],
                true
            );
        }
        else
        {
            menuManager.answerGeometryQuestion(
                actualChallenge.moleculeGeometryFeedbacks[geometrySelected - 1],
                false
            );
        }
    }

    public void answerQuestion(int toggleNumber)
    {
        if (actualChallenge.correctOption == toggleNumber)
        {
            menuManager.answerQuestion(actualChallenge.feedbacks[toggleNumber - 1], true);
        }
        else
        {
            menuManager.answerQuestion(actualChallenge.feedbacks[toggleNumber - 1], false);
        }
    }

    private IEnumerator nextChallengeStepWithSleep(int secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        menuManager.nextChallengeStep();
    }

    public void elementAddedToInventory()
    {
        List<string> unlockedElements = inventoryManager.getUnlockedElements();
        int unlockedElementForChallengeTotal = 0;
        foreach (string unlockedElement in unlockedElements)
        {
            for (int i = 0; i < actualChallenge.necessaryElements.Length; i++)
            {
                if (actualChallenge.necessaryElements[i].symbol == unlockedElement)
                {
                    unlockedElementForChallengeTotal++;
                    points += 10;
                }
            }
        }
        menuManager.updateScoreText(
            unlockedElementForChallengeTotal + "/" + actualChallenge.necessaryElements.Length
        );
        if (unlockedElementForChallengeTotal == actualChallenge.necessaryElements.Length)
        {
            StartCoroutine(nextChallengeStepWithSleep(3));
        }
    }

    public void StartChallenge(int difficulty)
    {
        this.difficulty = difficulty;
        List<Challenge> availableChallenges = new List<Challenge>();

        for (int i = 0; i < challenges.Length; i++)
        {
            if (challenges[i].difficulty == difficulty)
            {
                availableChallenges.Add(challenges[i]);
            }
        }

        actualChallenge = availableChallenges[Random.Range(0, availableChallenges.Count)];
        hasActiveChallenge = true;
        challengeFinished = false;

        introductionUI.text = actualChallenge.introduction;
        menuManager.nextChallengeStep();
        menuManager.updateMoleculeText(actualChallenge.moleculeName);
        menuManager.updateQuestionText(
            actualChallenge.question,
            actualChallenge.optionA,
            actualChallenge.optionB,
            actualChallenge.optionC
        );
        menuManager.updateGeometryOptionImage(
            actualChallenge.moleculeGeometryOptionA,
            actualChallenge.moleculeGeometryOptionB,
            actualChallenge.moleculeGeometryOptionC
        );
        menuManager.setMoleculeToBuild(actualChallenge.correctGeometryGO);
        menuManager.updateBuildMoleculeToggles(actualChallenge.necessaryElements);
        elementAddedToInventory();
        elementsLeftToPlace = actualChallenge.totalElements;
        eventManager.enableButtons();
        menuManager.setMoleculeModel(actualChallenge.moleculeModel);
    }
}

[System.Serializable]
public class Challenge
{
    public string introduction;
    public int difficulty;
    public string moleculeName;
    public string molecularFormula;

    //public string[] necessaryElements;
    public Element[] necessaryElements;
    public string question;
    public string optionA;
    public string optionB;
    public string optionC;
    public int correctOption;
    public string[] feedbacks;
    public Sprite moleculeGeometryOptionA;
    public Sprite moleculeGeometryOptionB;
    public Sprite moleculeGeometryOptionC;
    public int correctGeometryOption;
    public string[] moleculeGeometryFeedbacks;
    public GameObject correctGeometryGO;
    public int totalElements;
    public GameObject moleculeModel;

    public Challenge(
        string introduction,
        int difficulty,
        string moleculeName,
        string molecularFormula,
        Element[] necessaryElements,
        string question,
        string optionA,
        string optionB,
        string optionC,
        int correctOption,
        string[] feedbacks,
        Sprite moleculeGeometryOptionA,
        Sprite moleculeGeometryOptionB,
        Sprite moleculeGeometryOptionC,
        int correctGeometryOption,
        string[] moleculeGeometryFeedbacks,
        GameObject correctGeometryGO,
        int totalElements,
        GameObject moleculeModel
    )
    {
        this.introduction = introduction;
        this.difficulty = difficulty;
        this.moleculeName = moleculeName;
        this.molecularFormula = molecularFormula;

        this.necessaryElements = new Element[necessaryElements.Length];
        for (int i = 0; i < necessaryElements.Length; i++)
        {
            this.necessaryElements[i] = necessaryElements[i];
        }

        this.question = question;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.correctOption = correctOption;

        this.feedbacks = new string[feedbacks.Length];
        for (int i = 0; i < feedbacks.Length; i++)
        {
            this.feedbacks[i] = feedbacks[i];
        }

        this.moleculeGeometryOptionA = moleculeGeometryOptionA;
        this.moleculeGeometryOptionB = moleculeGeometryOptionB;
        this.moleculeGeometryOptionC = moleculeGeometryOptionC;
        this.correctGeometryOption = correctGeometryOption;

        this.moleculeGeometryFeedbacks = new string[moleculeGeometryFeedbacks.Length];
        for (int i = 0; i < moleculeGeometryFeedbacks.Length; i++)
        {
            this.moleculeGeometryFeedbacks[i] = moleculeGeometryFeedbacks[i];
        }

        this.correctGeometryGO = correctGeometryGO;
        this.totalElements = totalElements;
        this.moleculeModel = moleculeModel;
    }
}
