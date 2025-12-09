using TMPro;
using Unity.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public PlayerThirdPersonScript playerObject;
    public PlayerAttributes playerAttributes;
    public PlayerUIScript quest;
    public GameObject battleUI;
    public GameObject overworldUI;
    public GameObject QuestUI;

    // temporary variables
    public TMP_Text playerHealth;
    public TMP_Text playerMagic;
    public TMP_Text playerMessage;
    public TMP_Text enemyHealth;
    public TMP_Text enemyMessage;
    bool battleStarted = false;
    bool playerAttacking = false;
    bool playerCasting = false;
    bool playerGuarding = false;
    bool playerFleeing = false;
    
    EnemyData enemy;

    void Update()
    {
        if(battleStarted){
            if(Input.GetKeyDown(KeyCode.Alpha1)){ // attack
                playerAttacking = true;
            } else if(Input.GetKeyDown(KeyCode.Alpha2)){ // magic
                playerCasting = true;
            } else if(Input.GetKeyDown(KeyCode.Alpha3)){ // guard
                playerGuarding = true;
            } else if(Input.GetKeyDown(KeyCode.Alpha4)){ // flee
                playerFleeing = true;
                EndBattle();
                return;
            }
            ProcessPlayerInput();
            if(playerAttributes.Health <= 0){
                playerAttributes.Health = 100; // FIXME: testing purposes only, change for final build
            }
            if(enemy.health <= 0){
                //quest.QuestFulfilled = true;
                enemy.gameObject.SetActive(false);
                EndBattle();
            }
        }
    } 

    void ProcessPlayerInput(){
        if(playerAttacking){
            (int enemyDamage, bool crit) = playerAttributes.AttackCalculation(0);
            (int playerDamage, bool parry, bool dodge) = playerAttributes.DefenseCalculation(0, enemy.attack);

            enemy.health -= enemyDamage;

            playerHealth.text = "Health: " + playerAttributes.Health;
            enemyHealth.text = "Health: " + enemy.health;
            // use damage and bool variables to display turn message
            AdjustMessages(crit, parry, dodge, enemyDamage, playerDamage);
        } else if(playerCasting && playerAttributes.Magic >= 50){
            (int enemyDamage, bool crit) = playerAttributes.AttackCalculation(1);
            (int playerDamage, bool parry, bool dodge) = playerAttributes.DefenseCalculation(0, enemy.attack);

            enemy.health -= enemyDamage;

            playerHealth.text = "Health: " + playerAttributes.Health;
            enemyHealth.text = "Health: " + enemy.health;
            playerMagic.text = "Magic: " + playerAttributes.Magic;
            // use damage and bool variables to display turn message
            AdjustMessages(crit, parry, dodge, enemyDamage, playerDamage);
        } else if(playerGuarding){
            (int playerDamage, bool parry, bool dodge) = playerAttributes.DefenseCalculation(1, enemy.attack);

            playerHealth.text = "Health: " + playerAttributes.Health;
            if(parry){
                enemy.health -= enemy.attack;
                enemyHealth.text = "Health: " + enemy.health;
            }
            // use damage and bool variables to display turn message
            AdjustMessages(false, parry, dodge, 0, playerDamage);
        }
        playerAttacking = false;
        playerCasting = false;
        playerGuarding = false;
    }

    void AdjustMessages(bool crit, bool parry, bool dodge, int enemyDamage, int playerDamage){
        playerMessage.text = "Player dealt " + enemyDamage + " damage";
        if(crit){
            playerMessage.text += ", a critical hit";
        }
        if(parry){
            playerMessage.text += ", and parried";
        }
        if(dodge){
            playerMessage.text += ", and dodged";
        }
        enemyMessage.text = "Enemy dealt " + playerDamage + " damage";
    }

    public void StartBattle(EnemyData foundEnemy)
    {
        battleUI.SetActive(true);
        overworldUI.SetActive(false);
        QuestUI.SetActive(false);
        battleStarted = true;
        enemy = foundEnemy;

        playerHealth.text = "Health: " + playerAttributes.Health;
        playerMagic.text = "Magic: " + playerAttributes.Magic;
        playerMessage.text = "";
        enemyHealth.text = "Health: " + enemy.health;
        enemyMessage.text = "";
    }

    public void EndBattle()
    {
        if(!playerFleeing){ // so if player has actually won the battle
            switch(enemy.quest){
                case 1: // bandit
                    QuestData.BanditObjectiveComplete = true;
                    if(QuestData.BanditActive){
                        quest.QuestFulfilled = true;
                    }
                    playerAttributes.currentXP += 10;
                    // insert some check for level up here or once player leaves battle, if we want that
                    break;
                case 2: // wolf
                    QuestData.WolfObjectiveComplete = true;
                    if(QuestData.WolfActive){
                        quest.QuestFulfilled = true;
                    }
                    playerAttributes.currentXP += 20;
                    break;
                case 3: // goblin
                    QuestData.GoblinObjectiveComplete = true;
                    if(QuestData.GoblinActive){
                        quest.QuestFulfilled = true;
                    }
                    playerAttributes.currentXP += 30;
                    break;
                case 4: // boar
                    QuestData.BoarObjectiveComplete = true;
                    if(QuestData.BoarActive){
                        quest.QuestFulfilled = true;
                    }
                    playerAttributes.currentXP += 5;
                    break;
                default:
                    break;
            }
        }

        playerAttacking = false;
        playerCasting = false;
        playerGuarding = false;
        playerFleeing = false;
        battleStarted = false;
        battleUI.SetActive(false);
        overworldUI.SetActive(true);
        QuestUI.SetActive(true);
        playerObject.inBattle = false;
    }
}
