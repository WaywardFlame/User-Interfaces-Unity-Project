using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class QuestSelectionHandler : MonoBehaviour
{
    // reference static class storing data on each quest
    // can use this script to update PlayerUIScript variables to track quest progress
    public Button banditQuest, wolfQuest, goblinQuest, repeatableQuest;
    public Button ActivateQuestButton;
    public Button SubmitQuestButton;
    public Button ExitButton;

    public TMP_Text QuestName;
    public TMP_Text QuestDesc;

    // new - quest name slots in the UI
    public TMP_Text BanditName;
    public TMP_Text WolfName;
    public TMP_Text GoblinName;
    public TMP_Text BoarName;

    // new - active quest markers 
    public TMP_Text banditActive;
    public TMP_Text wolfActive;
    public TMP_Text goblinActive;
    public TMP_Text boarActive;
    
    string selectedObjective;

    // Quest 1 will be fighting the "Purple Bandit" that is already present
    // Quest 2 will be fighting a wolf in the forest
    // Quest 3 will be fighting a goblin by the pond
    // Quest 4 will be fighting a boar in the field by the shopkeeper

    // scripts to reference for coding: "ClassSelectionHandler.cs", "UIController.cs"

    void Start()
    {
        // set up the quest buttons
        banditQuest.onClick.AddListener(() => {SelectQuest("Bandit");});
        wolfQuest.onClick.AddListener(() => {SelectQuest("Wolf");});
        goblinQuest.onClick.AddListener(() => {SelectQuest("Goblin");});
        repeatableQuest.onClick.AddListener(() => {SelectQuest("Boar");});
        ActivateQuestButton.onClick.AddListener(() => {confirmQuestSelection();});
        SubmitQuestButton.onClick.AddListener(() => {submitQuestSelection();});
        ExitButton.onClick.AddListener(() => {exitButton();});

        // set up the quest name slots in the UI
        BanditName.text = QuestData.BanditName;
        WolfName.text = QuestData.WolfName;
        GoblinName.text = QuestData.GoblinName;
        BoarName.text = QuestData.BoarName;
    }

    void SelectQuest(string objective){
        selectedObjective = objective;

        // clear the active quest markers
        banditActive.text = "";
        wolfActive.text = "";
        goblinActive.text = "";
        boarActive.text = "";
        ActivateQuestButton.gameObject.SetActive(true);
        SubmitQuestButton.gameObject.SetActive(false);

        if(objective == "Bandit"){
            // reference static class with quest data
            QuestName.text = QuestData.BanditName;
            QuestDesc.text = QuestData.BanditDesc;
            banditActive.text = "*";

            if(QuestData.BanditActive){
                ActivateQuestButton.gameObject.SetActive(false);
                SubmitQuestButton.gameObject.SetActive(true);
            }
        } else if(objective == "Wolf"){
            // reference static class with quest data
            QuestName.text = QuestData.WolfName;
            QuestDesc.text = QuestData.WolfDesc;
            wolfActive.text = "*";

            if(QuestData.WolfActive){
                ActivateQuestButton.gameObject.SetActive(false);
                SubmitQuestButton.gameObject.SetActive(true);
            }
        } else if(objective == "Goblin"){
            // reference static class with quest data
            QuestName.text = QuestData.GoblinName;
            QuestDesc.text = QuestData.GoblinDesc;
            goblinActive.text = "*";

            if(QuestData.GoblinActive){
                ActivateQuestButton.gameObject.SetActive(false);
                SubmitQuestButton.gameObject.SetActive(true);
            }
        } else if(objective == "Boar"){
            // reference static class with quest data
            QuestName.text = QuestData.BoarName;
            QuestDesc.text = QuestData.BoarDesc;
            boarActive.text = "*";

            if(QuestData.BoarActive){
                ActivateQuestButton.gameObject.SetActive(false);
                SubmitQuestButton.gameObject.SetActive(true);
            }
        }
    }

    void confirmQuestSelection() {

        if (string.IsNullOrEmpty(selectedObjective))
        {
            Debug.Log("No quest selected");
            return;
        }

        // prevent player from activating another quest while a quest is active
        if(QuestData.BanditActive || QuestData.WolfActive || QuestData.GoblinActive || QuestData.BoarActive){
            if(selectedObjective == "Bandit"){
                QuestDesc.text = QuestData.BanditDesc + "\nAnother quest is already active. Finish that first.";
            } else if(selectedObjective == "Wolf"){
                QuestDesc.text = QuestData.WolfDesc + "\nAnother quest is already active. Finish that first.";
            } else if(selectedObjective == "Goblin"){
                QuestDesc.text = QuestData.GoblinDesc + "\nAnother quest is already active. Finish that first.";
            } else if(selectedObjective == "Boar"){
                QuestDesc.text = QuestData.BoarDesc + "\nAnother quest is already active. Finish that first.";
            }
            return;
        }

        // prevent player from activating a quest if it has already been completed
        if(selectedObjective == "Bandit" && QuestData.BanditQuestFinished){
            QuestDesc.text = QuestData.BanditDesc + "\nQuest already completed.";
            return;
        } else if(selectedObjective == "Wolf" && QuestData.WolfQuestFinished){
            QuestDesc.text = QuestData.WolfDesc + "\nQuest already completed.";
            return;
        } else if(selectedObjective == "Goblin" && QuestData.GoblinQuestFinished){
            QuestDesc.text = QuestData.GoblinDesc + "\nQuest already completed.";
            return;
        } else if(selectedObjective == "Boar" && QuestData.BoarQuestFinished){
            QuestDesc.text = QuestData.BoarDesc + "\nQuest already completed.";
            return;
        }

        // pass the selected quest to the PlayerUIScript
        PlayerUIScript playerUIScript = Object.FindFirstObjectByType<PlayerUIScript>();
        playerUIScript.SetActiveQuest(selectedObjective); 

        // mark appropriate quest as active
        if(selectedObjective == "Bandit"){
            QuestData.BanditActive = true;
        } else if(selectedObjective == "Wolf"){
            QuestData.WolfActive = true;
        } else if(selectedObjective == "Goblin"){
            QuestData.GoblinActive = true;
        } else if(selectedObjective == "Boar"){
            QuestData.BoarActive = true;
        }
        // refresh buttons of currently selected quest
        ActivateQuestButton.gameObject.SetActive(false);
        SubmitQuestButton.gameObject.SetActive(true);

        // hide the quest selection UI
        gameObject.SetActive(false);
        
    }

    void submitQuestSelection(){
        PlayerUIScript playerUIScript = Object.FindFirstObjectByType<PlayerUIScript>();
        if(selectedObjective == "Bandit" && !QuestData.BanditQuestFinished){
            if(QuestData.BanditObjectiveComplete){
                QuestData.BanditQuestFinished = true;
                QuestData.BanditDesc = "QUEST FINISHED - REWARD: 100 Gold";
                QuestDesc.text = QuestData.BanditDesc;
                playerUIScript.ResetQuestPrompts();
                QuestData.BanditActive = false;
                // add gold to player
                PlayerAttributesData.currency += 100;
            }
        } else if(selectedObjective == "Wolf"){
            if(QuestData.WolfObjectiveComplete){
                QuestData.WolfQuestFinished = true;
                QuestData.WolfDesc = "QUEST FINISHED - REWARD: 200 Gold";
                QuestDesc.text = QuestData.WolfDesc;
                playerUIScript.ResetQuestPrompts();
                QuestData.WolfActive = false;
                // add gold to player
                PlayerAttributesData.currency += 200;
            }
        } else if(selectedObjective == "Goblin"){
            if(QuestData.GoblinObjectiveComplete){
                QuestData.GoblinQuestFinished = true;
                QuestData.GoblinDesc = "QUEST FINISHED - REWARD: 300 Gold";
                QuestDesc.text = QuestData.GoblinDesc;
                playerUIScript.ResetQuestPrompts();
                QuestData.GoblinActive = false;
                // add gold to player
                PlayerAttributesData.currency += 300;
            }
        } else if(selectedObjective == "Boar"){
            if(QuestData.BoarObjectiveComplete){
                QuestData.BoarQuestFinished = true;
                QuestData.BoarDesc = "QUEST FINISHED - REWARD: 50 Gold";
                QuestDesc.text = QuestData.BoarDesc;
                playerUIScript.ResetQuestPrompts();
                QuestData.BoarActive = false;
                // add gold to player
                PlayerAttributesData.currency += 50;
            }
        }
    }

    void exitButton() {
        // hide the quest selection UI
        gameObject.SetActive(false);
    }
}
