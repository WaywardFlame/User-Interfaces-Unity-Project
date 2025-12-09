using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    public GameObject StatsUI;
    public GameObject AttributesUI;
    public GameObject SkillsUI;
    public GameObject InventoryUI;
    public GameObject SettingsUI;
    public GameObject QuestUI;

    // new - trying to allow the user to toggle UIs by clicking buttons
    public Button StatsButton;
    public Button AttributesButton;
    public Button SkillsButton;
    public Button InventoryButton;
    
    public Button QuestButton;

    // new - trying to alter the health/mp bars accordingly, within this script first
    public Slider HealthBar;
    public Slider MagicBar;
    public PlayerAttributes playerAttributes;


    void Start()
    {
        if(StatsButton) {
            StatsButton.onClick.AddListener(() => {ToggleUI(StatsUI);});
        }
        if(AttributesButton) {
            AttributesButton.onClick.AddListener(() => {ToggleUI(AttributesUI);});
        }
        if(SkillsButton) {
            SkillsButton.onClick.AddListener(() => {ToggleUI(SkillsUI);});
        }
        if(InventoryButton) {
            InventoryButton.onClick.AddListener(() => {ToggleUI(InventoryUI);});
        }
        if(QuestButton) {
            QuestButton.onClick.AddListener(() => {ToggleUI(QuestUI);});
        }

        // initialize the health and magic bars
        if(HealthBar) {
            HealthBar.maxValue = playerAttributes.MaxHealth;
            HealthBar.value = playerAttributes.Health;
        }
        if(MagicBar) {
            MagicBar.maxValue = playerAttributes.MaxMagic;
            MagicBar.value = playerAttributes.Magic;
        }
    }

    void ToggleUI(GameObject ui)
    {
        //close other panels first 
        StatsUI.SetActive(false);
        AttributesUI.SetActive(false);
        SkillsUI.SetActive(false);
        InventoryUI.SetActive(false);
        SettingsUI.SetActive(false);
        QuestUI.SetActive(false);

        // then toggle the selected panel
        ui.SetActive(true);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SettingsUI.activeInHierarchy)
            {
                SettingsUI.SetActive(false);
            }
            else
            {
                ToggleUI(SettingsUI);
                //SettingsUI.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
           if (AttributesUI.activeInHierarchy)
            {
                AttributesUI.SetActive(false);
            }
            else
            {
                ToggleUI(AttributesUI);
                //AttributesUI.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryUI.activeInHierarchy)
            {
                InventoryUI.SetActive(false);
            }
            else
            {
                ToggleUI(InventoryUI);
                //InventoryUI.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (StatsUI.activeInHierarchy)
            {
                StatsUI.SetActive(false);
            }
            else
            {
                ToggleUI(StatsUI);
                //StatsUI.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (SkillsUI.activeInHierarchy)
            {
                SkillsUI.SetActive(false);
            }
            else
            {
                ToggleUI(SkillsUI);
                //SkillsUI.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (QuestUI.activeInHierarchy)
            {
                QuestUI.SetActive(false);
            }
            else
            {
                ToggleUI(QuestUI);
                //QuestUI.SetActive(true);
            }
        }

        if (HealthBar && playerAttributes) {
            HealthBar.value = playerAttributes.Health;
        }
        
        if (MagicBar && playerAttributes) {
            MagicBar.value = playerAttributes.Magic;
        }

    }

    
}
