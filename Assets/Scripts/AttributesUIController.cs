using UnityEngine;
using TMPro;

public class AttributesUIController : MonoBehaviour {

    public TMP_Text strengthText, intelligenceText, dexterityText, agilityText, constitutionText, perceptionText;
    public TMP_Text abilityPowerText, attackDamageText, attackResistanceText, elementResistanceText, movementSpeedText, critChanceText;

    int abilityPowerMult = 5;
    int attackDamageMult = 5;
    int attackResistanceMult = 6;
    int elementResistanceMult = 6;
    int movementSpeedMult = 2;
    int critChanceMult = 4;
    void Start() 
    {
        strengthText.text = PlayerAttributesData.strength.ToString();
        intelligenceText.text = PlayerAttributesData.intelligence.ToString();
        dexterityText.text = PlayerAttributesData.dexterity.ToString();
        agilityText.text = PlayerAttributesData.agility.ToString();
        constitutionText.text = PlayerAttributesData.constitution.ToString();
        perceptionText.text = PlayerAttributesData.perception.ToString();

        int newAbilityPowerMult = abilityPowerMult * PlayerAttributesData.intelligence;
        int newAttackDamageMult = attackDamageMult * PlayerAttributesData.strength;
        int newAttackResistanceMult  = attackResistanceMult * PlayerAttributesData.constitution;
        int newElementResistanceMult = elementResistanceMult * PlayerAttributesData.perception;
        int newMovementSpeedMult = movementSpeedMult * PlayerAttributesData.agility;
        int newCritChanceMult = critChanceMult * PlayerAttributesData.dexterity;

        abilityPowerText.text = newAbilityPowerMult.ToString();
        attackDamageText.text = newAttackDamageMult.ToString();
        attackResistanceText.text = newAttackResistanceMult.ToString();
        elementResistanceText.text = newElementResistanceMult.ToString();
        movementSpeedText.text = newMovementSpeedMult.ToString();
        critChanceText.text = newCritChanceMult.ToString();
    }

    public void PopulateAttributes()
    {
        strengthText.text = PlayerAttributesData.strength.ToString();
        intelligenceText.text = PlayerAttributesData.intelligence.ToString();
        dexterityText.text = PlayerAttributesData.dexterity.ToString();
        agilityText.text = PlayerAttributesData.agility.ToString();
        constitutionText.text = PlayerAttributesData.constitution.ToString();
        perceptionText.text = PlayerAttributesData.perception.ToString();

        int newAbilityPowerMult = abilityPowerMult * PlayerAttributesData.intelligence;
        int newAttackDamageMult = attackDamageMult * PlayerAttributesData.strength;
        int newAttackResistanceMult  = attackResistanceMult * PlayerAttributesData.constitution;
        int newElementResistanceMult = elementResistanceMult * PlayerAttributesData.perception;
        int newMovementSpeedMult = movementSpeedMult * PlayerAttributesData.agility;
        int newCritChanceMult = critChanceMult * PlayerAttributesData.dexterity;

        abilityPowerText.text = newAbilityPowerMult.ToString();
        attackDamageText.text = newAttackDamageMult.ToString();
        attackResistanceText.text = newAttackResistanceMult.ToString();
        elementResistanceText.text = newElementResistanceMult.ToString();
        movementSpeedText.text = newMovementSpeedMult.ToString();
        critChanceText.text = newCritChanceMult.ToString();
    }

    // void Update()
    // {
    //     if (Input.GetKey(KeyCode.P))
    //     {
    //         PopulateAttributes();
    //     }  
    // }
}