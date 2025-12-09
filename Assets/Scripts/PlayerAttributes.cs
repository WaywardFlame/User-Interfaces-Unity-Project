using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [Header("Player Stats")]
    public int Health;
    public int MaxHealth = 100;
    public int Magic;
    public int MaxMagic = 50;
    public int currency => PlayerAttributesData.currency; // currency / gold

    [Header("Level Info")]
    public int currentXP;
    public int XPToNextLevel;
    public int Level;

    [Header("Attributes")]
    public int strength => PlayerAttributesData.strength; // physical damage
    public int intelligence => PlayerAttributesData.intelligence; // magic damage
    public int dexterity => PlayerAttributesData.dexterity; // parry chance when blocking
    public int agility => PlayerAttributesData.agility; // dodge chance on any turn
    public int constitution => PlayerAttributesData.constitution; // defense
    public int perception => PlayerAttributesData.perception; // crit chance

    void Update()
    {
        // CHECK IF CORRECT VALUES THROUGHOUT SCENES
        if (Input.GetKey(KeyCode.Alpha0))
        {
            Debug.Log(strength+intelligence+dexterity+agility+constitution+perception + "Static " + PlayerAttributesData.strength + PlayerAttributesData.intelligence +
            PlayerAttributesData.dexterity +
            PlayerAttributesData.agility +
            PlayerAttributesData.constitution +
            PlayerAttributesData.perception);
        }
    }
    public (int damage, bool crit) AttackCalculation(int action){ // action 0 is attack, 1 is magic
        int willCrit = Random.Range(1, 101) + perception;

        int todoDamage = 0;
        if(action == 0){ // strength
            todoDamage = (strength * 10);
        } else if(action == 1){ // magic
            todoDamage = (intelligence * 25);
            Magic -= 50;
        }

        if(willCrit < 96){ // 5% base crit chance
            return (damage: todoDamage, crit: false);
        } else {
            return (damage: todoDamage * 2, crit: true);
        }
    }

    public (int damage, bool parry, bool dodge) DefenseCalculation(int action, int attack){ // action 1 is guard, 0 is nothing
        int willParry = Random.Range(1, 101) + dexterity;
        int willDodge = Random.Range(1, 101) + agility;
        int wouldBeDamage = 0;

        if(willParry >= 99 && action == 1){ // 2% base parry chance
            return (damage: wouldBeDamage, parry: true, dodge: false);
        } else if(willDodge >= 96 && action == 0){ // 5% base dodge chance
            return (damage: wouldBeDamage, parry: false, dodge: true);
        } else if(action == 1){ // if guarding
            wouldBeDamage = (attack / 2) - constitution;
        } else { // not guarding
            wouldBeDamage = attack - constitution;
        }
        Health -= wouldBeDamage;
        return (damage: wouldBeDamage, parry: false, dodge: false);
    }
}
