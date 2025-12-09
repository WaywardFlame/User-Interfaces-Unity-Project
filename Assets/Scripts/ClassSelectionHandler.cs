using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClassSelectionHandler : MonoBehaviour
{

    public Button fighterButton, mageButton, medicButton, assassinButton;
    public TMP_Text classText;
    public Button confirmButton;
    string classSelected;

    void Start()
    {
        fighterButton.onClick.AddListener(() => {SelectClass("Fighter");});
        mageButton.onClick.AddListener(() => {SelectClass("Mage");});
        medicButton.onClick.AddListener(() => {SelectClass("Medic");});
        assassinButton.onClick.AddListener(() => {SelectClass("Assassin");});
        confirmButton.onClick.AddListener(() => {SetClassValues(classSelected); Debug.Log(classSelected + PlayerAttributesData.strength + PlayerAttributesData.intelligence +
            PlayerAttributesData.dexterity +
            PlayerAttributesData.agility +
            PlayerAttributesData.constitution +
            PlayerAttributesData.perception);   });
    }

    void SelectClass(string className)
    {
        classText.text = className;
        classSelected = className;
    }

    void SetClassValues(string classSelected)
    {
        PlayerAttributesData.currency = 120;
        switch(classSelected)
        {
            case "Fighter":
            // strength = 
            PlayerAttributesData.characterClass = "Fighter";
            PlayerAttributesData.strength = 4;
            PlayerAttributesData.intelligence = 4;
            PlayerAttributesData.dexterity = 4;
            PlayerAttributesData.agility = 4;
            PlayerAttributesData.constitution = 4;
            PlayerAttributesData.perception = 4;
            break;

            case "Mage":
            PlayerAttributesData.characterClass = "Mage";
            PlayerAttributesData.strength = 3;
            PlayerAttributesData.intelligence = 3;
            PlayerAttributesData.dexterity = 3;
            PlayerAttributesData.agility = 3;
            PlayerAttributesData.constitution = 3;
            PlayerAttributesData.perception = 3;
            break;

            case "Medic":
            PlayerAttributesData.characterClass = "Medic";
            PlayerAttributesData.strength = 2;
            PlayerAttributesData.intelligence = 2;
            PlayerAttributesData.dexterity = 2;
            PlayerAttributesData.agility = 2;
            PlayerAttributesData.constitution = 2;
            PlayerAttributesData.perception = 2;
            break;

            case "Assassin":
            PlayerAttributesData.characterClass = "Assassin";
            PlayerAttributesData.strength = 1;
            PlayerAttributesData.intelligence = 1;
            PlayerAttributesData.dexterity = 1;
            PlayerAttributesData.agility = 1;
            PlayerAttributesData.constitution = 1;
            PlayerAttributesData.perception = 1;
            break;

            default:
            Debug.Log("no class selected");
            break;
        }
    }


}
