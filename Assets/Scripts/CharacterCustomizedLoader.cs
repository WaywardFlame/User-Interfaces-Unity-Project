using UnityEngine;

public class CharacterCustomizedLoader : MonoBehaviour
{
    [SerializeField] CharacterCustomized characterCustomized;

    void Start()
    {
        characterCustomized.characterColorData[0].meshRenderer.sharedMaterial = 
            characterCustomized.characterColorData[0].materialArray[CharacterCustomizationData.colorIndex];

        characterCustomized.characterColorData[1].meshRenderer.sharedMaterial = 
            characterCustomized.characterColorData[1].materialArray[CharacterCustomizationData.eyeColorIndex];
    }
}
