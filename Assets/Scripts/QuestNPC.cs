using Unity.VisualScripting;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public PlayerUIScript quest;
    public GameObject QuestFinished;

    void Update()
    {
        if(quest.QuestComplete){
            QuestFinished.SetActive(true);
            this.gameObject.SetActive(false);
        }
    } 
}
