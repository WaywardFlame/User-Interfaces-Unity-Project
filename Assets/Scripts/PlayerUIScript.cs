using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class PlayerUIScript : MonoBehaviour
{
    public string ActiveQuestName = "";
    public bool QuestActive = false;
    public bool QuestFulfilled = false;
    public bool QuestComplete = false;
    public GameObject QuestPromptAccept;
    public GameObject QuestPromptComplete;
    public GameObject QuestDetailsObjective;
    public GameObject QuestDetailsComplete;
    public GameObject OverWorldUI;
    public GameObject ShopInteractPrompt;

    // new - quest objective text
    public TMP_Text QuestObjectiveText;

    bool inShopArea = false;
    
    void Start()
    {
        ResetQuestPrompts();
        OverWorldUI.SetActive(true);
    }

    public void ResetQuestPrompts(){
        QuestPromptAccept.SetActive(false);
        QuestPromptComplete.SetActive(false);
        QuestDetailsObjective.SetActive(false);
        QuestDetailsComplete.SetActive(false);
        QuestActive = false;
        QuestComplete = false;
        QuestFulfilled = false;
    }

    // new - setactivequest
    public void SetActiveQuest(string questName)
    {
        Debug.Log("Setting active quest: " + questName);
        // set the active quest in the UI
        QuestActive = true;
        QuestComplete = false;
        QuestFulfilled = false;
        ActiveQuestName = questName;

        if(questName == "Bandit" && QuestData.BanditObjectiveComplete){
            QuestFulfilled = true;
            return;
        } else if(questName == "Wolf" && QuestData.WolfObjectiveComplete){
            QuestFulfilled = true;
            return;
        } else if(questName == "Goblin" && QuestData.GoblinObjectiveComplete){
            QuestFulfilled = true;
            return;
        } else if(questName == "Boar" && QuestData.BoarObjectiveComplete){
            QuestFulfilled = true;
            return;
        }

        QuestDetailsObjective.SetActive(true);
        QuestDetailsComplete.SetActive(false);

        switch (questName)
        {
            case "Bandit":
                QuestDetailsObjective.GetComponentInChildren<TMP_Text>().text = "Defeat the Purple Bandit";
                //QuestObjectiveText.text = "Defeat the Purple Bandit";
                break;
            case "Wolf":
                QuestDetailsObjective.GetComponentInChildren<TMP_Text>().text = "Hunt down the Forest Wolf";
                //QuestObjectiveText.text = "Hunt down the Forest Wolf";
                break;
            case "Goblin":
                QuestDetailsObjective.GetComponentInChildren<TMP_Text>().text = "Eliminate the Pond Goblin";    
                //QuestObjectiveText.text = "Eliminate the Pond Goblin";
                break;
            case "Boar":
                QuestDetailsObjective.GetComponentInChildren<TMP_Text>().text = "Hunt a Boar";
                //QuestObjectiveText.text = "Hunt a Boar";
                break;
            default:
                Debug.Log("Unknown quest name: " + questName);
                QuestDetailsObjective.GetComponentInChildren<TMP_Text>().text = "Unknown quest name";
                break;
        }
        
    }

    public void SelectQuest(string questName) {
        SetActiveQuest(questName);
    }

    void Update()
    {
        // most of this probably isn't relevant

        if(QuestPromptAccept.activeSelf){ // if prompt to accept quest is active
            if(Input.GetKeyDown(KeyCode.E)){
                QuestDetailsObjective.SetActive(true);
                QuestActive = true;
                QuestPromptAccept.SetActive(false);
            }
        }

        if(QuestFulfilled){ // if quest objectives have been fulfilled
            QuestDetailsObjective.SetActive(false);
            QuestDetailsComplete.SetActive(true);
        }

        if(QuestPromptComplete.activeSelf){ // if prompt to complete quest is active
            if(Input.GetKeyDown(KeyCode.E)){
                QuestDetailsComplete.SetActive(false);
                QuestPromptComplete.SetActive(false);
                QuestFulfilled = false;
                QuestComplete = true;
            }
        }

        // this should be relevant
        if(inShopArea){
            if(Input.GetKeyDown(KeyCode.E)){
                FindFirstObjectByType<ShopManager>().ShowShop();
            }
        }
    } 


    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shop")){
            Debug.Log("Entered Shop NPC interaction area");
            ShopInteractPrompt.SetActive(true);
            inShopArea = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Shop")){
            Debug.Log("Left Shop NPC interaction area");
            ShopInteractPrompt.SetActive(false);
            inShopArea = false;
        }
    }
}
