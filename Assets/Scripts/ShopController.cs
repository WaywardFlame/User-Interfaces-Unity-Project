using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public AttributesUIController attributesUIController; //ui reference to update static values in stats and attributes

    // the general structure of this script is the same as the QuestSelectionHandler
    // so look to that script for reference on how to complete this one

    // different items for player to select
    // each item will raise specified attribute by 1 point
    // each item will cost 20 gold / currency
    // currency may be added as static variable to PlayerAttributesData (exists as non static in PlayerAttributes)

    // a shopkeepers needs to be implemented in order to use this UI
    // basically just walk up, press E

    public Button strengthItem, intelligenceItem, dexterityItem, agilityItem, constitutionItem, perceptionItem;
    public Button ConfirmSaleButton;
    public Button CloseShopButton;

    public TMP_Text SaleInfo;
    public TMP_Text GoldText;
    public TMP_Text StrengthText;
    public TMP_Text IntelligenceText;
    public TMP_Text DexterityText;
    public TMP_Text AgilityText;
    public TMP_Text ConstitutionText;
    public TMP_Text PerceptionText;

    string selectedItem = "";

    // the shop window on the left should display the player's currency amount
    // and their attribute levels

    void Start()
    {
        strengthItem.onClick.AddListener(() => {SelectItem("strength");});
        intelligenceItem.onClick.AddListener(() => {SelectItem("intelligence");});
        dexterityItem.onClick.AddListener(() => {SelectItem("dexterity");});
        agilityItem.onClick.AddListener(() => {SelectItem("agility");});
        constitutionItem.onClick.AddListener(() => {SelectItem("constitution");});
        perceptionItem.onClick.AddListener(() => {SelectItem("perception");});
        ConfirmSaleButton.onClick.AddListener(() => {ConfirmPurchase();});
        CloseShopButton.onClick.AddListener(() => {ExitShop();});

        Refresh();
    }

    // ensures proper text is displayed
    public void Refresh(){
        SaleInfo.text = "";
        GoldText.text = "Gold: " + PlayerAttributesData.currency;
        StrengthText.text = "Strength: " + PlayerAttributesData.strength;
        IntelligenceText.text = "Intelligence: " + PlayerAttributesData.intelligence;
        DexterityText.text = "Dexterity: " + PlayerAttributesData.dexterity;
        AgilityText.text = "Agility: " + PlayerAttributesData.agility;
        ConstitutionText.text = "Constitution: " + PlayerAttributesData.constitution;
        PerceptionText.text = "Perception: " + PlayerAttributesData.perception;
    }

    // display selected item in the middle shop window
    void SelectItem(string item){
        selectedItem = item;

        if(selectedItem == "strength"){
            SaleInfo.text = "Strength +1 Potion - 20 Gold";
        } else if(selectedItem == "intelligence"){
            SaleInfo.text = "Intelligence +1 Potion - 20 Gold";
        } else if(selectedItem == "dexterity"){
            SaleInfo.text = "Dexterity +1 Potion - 20 Gold";
        } else if(selectedItem == "agility"){
            SaleInfo.text = "Agility +1 Potion - 20 Gold";
        } else if(selectedItem == "constitution"){
            SaleInfo.text = "Constitution +1 Potion - 20 Gold";
        } else if(selectedItem == "perception"){
            SaleInfo.text = "Perception +1 Potion - 20 Gold";
        }
    }

    // for the confim sale button, purchases the item and reflects change in the left window
    void ConfirmPurchase(){
        // check for no selected item
        if (string.IsNullOrEmpty(selectedItem))
        {
            Debug.Log("No item selected");
            SaleInfo.text = "Select an item";
            return;
        }

        // check for enough gold
        if(PlayerAttributesData.currency < 20){
            SaleInfo.text = "Not enough gold";
            return;
        }

        // check which item is being purchased and then change appropriate values
        switch(selectedItem){
            case "strength":
                PlayerAttributesData.strength += 1;
                StrengthText.text = "Strength: " + PlayerAttributesData.strength;
                break;
            case "intelligence":
                PlayerAttributesData.intelligence += 1;
                IntelligenceText.text = "Intelligence: " + PlayerAttributesData.intelligence;
                break;
            case "dexterity":
                PlayerAttributesData.dexterity += 1;
                DexterityText.text = "Dexterity: " + PlayerAttributesData.dexterity;
                break;
            case "agility":
                PlayerAttributesData.agility += 1;
                AgilityText.text = "Agility: " + PlayerAttributesData.agility;
                break;
            case "constitution":
                PlayerAttributesData.constitution += 1;
                ConstitutionText.text = "Constitution: " + PlayerAttributesData.constitution;
                break;
            case "perception":
                PlayerAttributesData.perception += 1;
                PerceptionText.text = "Perception: " + PlayerAttributesData.perception;
                break;
            default:
                Debug.Log("Error purchasing item");
                break;
        }
        PlayerAttributesData.currency -= 20;
        attributesUIController.PopulateAttributes(); // reference to other uis referencing static variables
        GoldText.text = "Gold: " + PlayerAttributesData.currency;
        SaleInfo.text = "Thank you for your purchase!";
    }

    // for the close shop button, closes the shop interface
    void ExitShop(){
        selectedItem = "";
        SaleInfo.text = "";
        gameObject.SetActive(false);
    }
}
