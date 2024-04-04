using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    public Element[] inventory;

    [SerializeField]
    private GameObject hidrogenoBlocker;

    [SerializeField]
    private GameObject carbonoBlocker;

    [SerializeField]
    private GameObject nitrogenoBlocker;

    [SerializeField]
    private GameObject oxigenoBlocker;

    [SerializeField]
    private GameObject fluorBlocker;

    [SerializeField]
    private GameObject cloroBlocker;

    [SerializeField]
    private GameObject azufreBlocker;

    [SerializeField]
    private Sprite hidrogenoSprite;

    [SerializeField]
    private Sprite carbonoSprite;

    [SerializeField]
    private Sprite nitrogenoSprite;

    [SerializeField]
    private Sprite oxigenoSprite;

    [SerializeField]
    private Sprite fluorSprite;

    [SerializeField]
    private Sprite cloroSprite;

    [SerializeField]
    private Sprite azufreSprite;

    private void Awake()
    {
        inventory = new Element[7];
        inventory[0] = new Element(
            "carbono",
            "Carbono",
            "C",
            false,
            carbonoBlocker,
            carbonoSprite,
            "El carbono es un elemento que pertenece al grupo 14, se halla presente en la Tierra en forma libre como grafito o diamante (alótropos), combinado con oxígeno formando CO y CO2, también presenteen sales inorgánicas y en millones de compuestos orgánicos."
        );

        inventory[1] = new Element(
            "azufre",
            "Azufre",
            "S",
            false,
            azufreBlocker,
            azufreSprite,
            "El azufre es un elemento que pertenece al grupo 16, y se lo encuentra en la naturaleza como un sólido amarillo en su estado elemental (S8). También se lo encuentra en forma gaseosa como sus óxidos SO2 y SO3, en sales como sulfuros, sulfitos y sulfatos, como ácido sulfúrico y en compuestos orgánicos."
        );

        inventory[2] = new Element(
            "cloro",
            "Cloro",
            "Cl",
            false,
            cloroBlocker,
            cloroSprite,
            "El cloro es un elemento que pertenece al grupo 17, y en su forma elemental se lo encuentra como molécula diatómica (Cl2), empleada para desinfectar aguas o como agente blanqueador. También forma parte de ácidos inorgánicos (hidrácidos y oxoácidos), sales y compuestos orgánicos halogenados."
        );

        inventory[3] = new Element(
            "oxigeno",
            "Oxigeno",
            "O",
            false,
            oxigenoBlocker,
            oxigenoSprite,
            "El oxígeno es un elemento que pertenece al grupo 16, es el más abundante en masa en la corteza terrestre. Es fundamental para la vida, representa un 21% en volumen como gas diatómico (O2) de la atmósfera terrestre, forma parte del agua, de las biomoléculas, del ozono en la estratósfera así como de óxidos y sales.  "
        );

        inventory[4] = new Element(
            "nitrogeno",
            "Nitrogeno",
            "N",
            false,
            nitrogenoBlocker,
            nitrogenoSprite,
            "El nitrógeno es un elemento que pertenece al grupo 15, se halla en compuestos inorgánicos como el amoníaco, el ácido nítrico, en óxidos de nitrógeno y sales, en ácidos nucleicos y aminoácidos. En forma de gas diatómico (N2) representa el 78% en volumen de la atmósfera terrestre. "
        );

        inventory[5] = new Element(
            "hidrogeno",
            "Hidrogeno",
            "H",
            false,
            hidrogenoBlocker,
            hidrogenoSprite,
            "El hidrógeno es el elemento químico más ligero que existe y el más abundante en masa del universo, su átomo está formado por un protón y un electrón. Presenta dos isótopos naturales, el deuterio y el tritio. Es estable en forma de molécula diatómica (H2). "
        );

        inventory[6] = new Element(
            "fluor",
            "Fluor",
            "F",
            false,
            fluorBlocker,
            fluorSprite,
            "El flúor es un elemento que pertenece al grupo 17, siendo el más electronegativo de la Tabla Periódica y el más reactivo de los halógenos. Forma moléculas diatómicas (F2) que representan agentes oxidantes fuertes, también se lo encuentra como fluoruro en minerales y aguas, y como ácido fluorhídrico (HF) empleado para marcar vidrios."
        );
    }

    public void addElementToInventory(string element)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].slug == element)
            {
                inventory[i].inInventory = true;
                inventory[i].blockerUI.SetActive(false);
            }
        }
    }

    public List<string> getUnlockedElements()
    {
        List<string> unlockedElements = new List<string>();

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].inInventory)
                unlockedElements.Add(inventory[i].symbol);
        }

        return unlockedElements;
    }

    public Element getElementBySlug(string slug)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].slug == slug)
                return inventory[i];
        }
        return null;
    }

    public bool isInInventory(string slug)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].slug == slug && inventory[i].inInventory)
                return true;
        }
        return false;
    }

    public Element getElementBySymbol(string symbol)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].symbol == symbol)
                return inventory[i];
        }
        return null;
    }
}

[System.Serializable]
public class Element
{
    public string slug;
    public string name;
    public string symbol;
    public bool inInventory;
    public GameObject blockerUI;
    public Sprite sprite;
    public string elementDescription;

    public Element(
        string slug,
        string name,
        string symbol,
        bool inInventory,
        GameObject blockerUI,
        Sprite sprite,
        string elementDescription
    )
    {
        this.slug = slug;
        this.name = name;
        this.symbol = symbol;
        this.inInventory = inInventory;
        this.blockerUI = blockerUI;
        this.sprite = sprite;
        this.elementDescription = elementDescription;
    }
}
