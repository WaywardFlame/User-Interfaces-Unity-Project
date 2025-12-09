using UnityEngine;

public class CharacterCustomized : MonoBehaviour
{
   
    public CharacterColorData[] characterColorData;
    

    [System.Serializable]
    public class CharacterColorData {
        public Material[] materialArray;
        public Material material;
        public MeshRenderer meshRenderer;
    }

    

    public void ChangeColor() 
    {
    int meshIndex = System.Array.IndexOf(characterColorData[0].materialArray, characterColorData[0].meshRenderer.sharedMaterial);
    int newIndex = (meshIndex + 1) % characterColorData[0].materialArray.Length;
    characterColorData[0].meshRenderer.sharedMaterial = characterColorData[0].materialArray[newIndex];
    CharacterCustomizationData.colorIndex = newIndex;
    }

    public void ChangeEyes() 
    {
    int meshIndex = System.Array.IndexOf(characterColorData[1].materialArray, characterColorData[1].meshRenderer.sharedMaterial);
    int newIndex = (meshIndex + 1) % characterColorData[1].materialArray.Length;
    characterColorData[1].meshRenderer.sharedMaterial = characterColorData[1].materialArray[newIndex];
    CharacterCustomizationData.eyeColorIndex = newIndex;
    }

    public void ChangeName(string charName)
    {
        CharacterCustomizationData.characterName = charName;
        Debug.Log(CharacterCustomizationData.characterName);
    }

}
