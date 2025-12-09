using UnityEngine;
using TMPro;

public class CharacterInfoHeader : MonoBehaviour {

    public TMP_Text characterName, characterClass;

    void Start()
    {
        characterName.text = CharacterCustomizationData.characterName.ToString();
        characterClass.text = PlayerAttributesData.characterClass.ToString();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            characterName.text = "Character Name: " + CharacterCustomizationData.characterName.ToString();
            characterClass.text = "Character Class: " + PlayerAttributesData.characterClass.ToString();
        }
    }

}