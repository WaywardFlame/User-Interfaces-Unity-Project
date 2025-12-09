using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizationUIController : MonoBehaviour
{

    [SerializeField] Button colorButton;
    [SerializeField] Button colorEyes;
    [SerializeField] Button submitButton;
    [SerializeField] TMP_InputField charName;
    [SerializeField] CharacterCustomized characterCustomized;
    void Awake()
    {
        colorButton.onClick.AddListener(() => {
            //Debug.Log("Color Button");
            characterCustomized.ChangeColor();
        });
        colorEyes.onClick.AddListener(() => {
            //Debug.Log("Color Button");
            characterCustomized.ChangeEyes();
        });
        submitButton.onClick.AddListener(() => {
            //Debug.Log("Color Button");
            CharacterCustomizationData.characterName = charName.text;
            characterCustomized.ChangeName(charName.text);
        });
    }

}
