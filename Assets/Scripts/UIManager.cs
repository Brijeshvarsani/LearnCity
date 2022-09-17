using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float QuizErrorPenalty = 0.3f;
    [Header("Resource InfoPanel")]
    public ResourceDepositSO activeResourceDeposit;
    public GameObject InfoPanel;
    public GameObject InfoPanel_Name;
    public GameObject InfoPanel_Description;
    public GameObject InfoPanel_Image;
    public GameObject QuizPanel;

    [Header("Other UI")]
    public GameObject DialogBox;
    public GameObject TownHallPanel;
    public GameObject FarmPanel;
    public ToolMenuUI toolMenuUI;

    [Header("Population")]
    public TextMeshProUGUI PopulationValue;
    private int maxPopulation;
    public int populationGrowthInterval;
    private int currentPopulation;

    [Header("Stamina Bar")]
    public Image staminaBar;
    private float stamina;
    public float maxStamina;

    [Header("Resource Bar")]
    public ResourceTypeSO Wood;
    public TextMeshProUGUI WoodValue;
    public ResourceTypeSO Food;
    public TextMeshProUGUI FoodValue;
    public ResourceTypeSO Water;
    public TextMeshProUGUI WaterValue;
    public ResourceTypeSO Gold;
    public TextMeshProUGUI GoldValue;
    public ResourceTypeSO Star;
    public TextMeshProUGUI StarValue;
    public ResourceTypeSO Iron;
    public TextMeshProUGUI IronValue;

    [Header("Others")]
    public Target target;
    public BuildingManager buildingManager;
    private GameObject objectHit;

    [Header("Dialog")]
    public DialogueObject welcomeDialog;
    public DialogueObject resourceDialog;
    public DialogueObject houseBuildingDialog;
    public DialogueObject firstToolsDialog;
    public bool firstToolsDialogShown = false;
    public bool resourceDialogShown = false;
    public bool houseBuildingDialogShown = false;
    public DialogUI dialogUI;

    [Header("Level3")]
    public int CarCount = 0;

    public float Stamina { get => stamina; set { stamina = value; staminaBar.fillAmount = stamina / maxStamina; } }

    public int CurrentPopulation { get => currentPopulation; set { currentPopulation = value; PopulationValue.text = generatePopulationText(); } }

    private string generatePopulationText()
    {
        return currentPopulation.ToString() + '/' + maxPopulation.ToString();
    }

    public int MaxPopulation { get => maxPopulation; set { maxPopulation = value; PopulationValue.text = generatePopulationText(); } }

    private void OnEnable()
    {
        QuizManager.OnquizAnswer += AddToResource;
        QuizManager_Old.OnquizAnswer += AddToResource;
        House.OnHouseBuilt += AddToMaxPopulation;
    }

    private void OnDisable()
    {
        QuizManager.OnquizAnswer -= AddToResource;
        QuizManager_Old.OnquizAnswer -= AddToResource;
        House.OnHouseBuilt -= AddToMaxPopulation;
    }
    private void Awake()
    {
    }
    private void Start()
    {
        Wood.amount = GameSettings.woodStartingAmount;
        Food.amount = GameSettings.foodStartingAmount;
        Water.amount = GameSettings.waterStartingAmount;
        Gold.amount = GameSettings.goldStartingAmount;
        if (Star != null)
            Star.amount = GameSettings.starStartingAmount;
        if (Iron != null)
            Iron.amount = GameSettings.ironStartingAmount;

        Wood.progressionGoal = GameSettings.woodProgressionGoal;
        Food.progressionGoal = GameSettings.foodProgressionGoal;
        Water.progressionGoal = GameSettings.waterProgressionGoal;
        Gold.progressionGoal = GameSettings.goldProgressionGoal;
        if (Star != null)
            Star.progressionGoal = GameSettings.starProgressionGoal;
        if (Iron != null)
            Iron.progressionGoal = GameSettings.ironProgressionGoal;

        CurrentPopulation = 0;
        MaxPopulation = 0;
        stamina = maxStamina;
        dialogUI.ShowDialogue(welcomeDialog);
        InvokeRepeating(nameof(GrowPopulation), 0f, populationGrowthInterval);
    }

    // Update is called once per frame
    void Update()
    {
        WoodValue.text = Wood.amount.ToString();
        FoodValue.text = Food.amount.ToString();
        WaterValue.text = Water.amount.ToString();
        GoldValue.text = Gold.amount.ToString();
        StarValue.text = Star.amount.ToString();
        if (IronValue != null)
            IronValue.text = Iron.amount.ToString();



        objectHit = Helpers.Raycast();
        if (CanClickUI())
        {
            //Debug.Log(objectHit.tag);
            if (objectHit.tag == "Resource")
            {
                InfoPanel.SetActive(true);
                activeResourceDeposit = objectHit.GetComponent<ResourceDepositInfo>().resourceDepositSO;
                InfoPanel_Name.GetComponent<TextMeshProUGUI>().text = activeResourceDeposit.name;
                InfoPanel_Description.GetComponent<TextMeshProUGUI>().text = activeResourceDeposit.description;
                InfoPanel_Image.GetComponent<Image>().sprite = activeResourceDeposit.sprite;

                if (!resourceDialogShown)
                {
                    dialogUI.ShowDialogue(resourceDialog);
                    resourceDialogShown = true;
                }
            }
            else if (objectHit.tag == "Ground")
            {
                target.moveTarget();
            }
            else if (objectHit.tag == "TownHall")
            {
                TownHallPanel.SetActive(true);
            }
            else
            {
                FarmingStation farmingStation = objectHit.GetComponent<FarmingStation>();
                if (farmingStation != null)
                {
                    if (toolMenuUI.toolMode)
                    {
                        if (toolMenuUI.IsActiveToolWaterBucket())
                            farmingStation.Water();
                        else if (toolMenuUI.IsActiveToolFertilizer())
                            farmingStation.Fertilize();
                    }
                    else
                    {
                        FarmPanel.SetActive(true);
                        activeResourceDeposit = objectHit.GetComponent<ResourceDepositInfo>().resourceDepositSO;
                        CropTypeSelectUI cropTypeSelectUI = FarmPanel.GetComponent<CropTypeSelectUI>();
                        cropTypeSelectUI.Initialize(farmingStation);
                    }
                    return;
                }
                HouseQuiz houseQuiz = objectHit.GetComponent<HouseQuiz>();
                if (houseQuiz != null)
                {
                    houseQuiz.GoToQuizScene();
                    return;
                }
            }
        }
    }

    private void AddToMaxPopulation(int houseSize)
    {
        MaxPopulation += houseSize;
    }

    private void GrowPopulation()
    {
        if (CurrentPopulation + 1 <= MaxPopulation)
        {
            CurrentPopulation++;
        }
    }
    private bool CanClickUI()
    {
        return objectHit != null &&
            !EventSystem.current.IsPointerOverGameObject(0) &&
            !buildingManager.BuildingMode &&
            !DialogBox.activeInHierarchy;

    }

    private void AddToResource(bool result)
    {
        if (activeResourceDeposit != null)
        {
            if (result)
            {
                activeResourceDeposit.resourceType.amount += activeResourceDeposit.resourceAmount;
            }
            else
            {
                activeResourceDeposit.resourceType.amount += (int)(activeResourceDeposit.resourceAmount * QuizErrorPenalty);
            }
            Stamina -= 10;
        }
    }
    public void OpenQuizPanel()
    {
        QuizPanel.SetActive(true);
        QuizManager quizManager = QuizPanel.GetComponent<QuizManager>();
        if (quizManager != null)
        {
            quizManager.LoadQuestion();
        }
        else
        {
            QuizPanel.GetComponent<QuizManager_Old>().LoadQuestion();
        }
        CloseInfoPanel();
    }
    public void CloseTownHallPanel()
    {
        TownHallPanel.SetActive(false);
    }

    public void CloseQuizPanel()
    {
        QuizPanel.SetActive(false);

        if (!houseBuildingDialogShown)
        {
            dialogUI.ShowDialogue(houseBuildingDialog);
            houseBuildingDialogShown = true;
        }
    }

    public void CloseInfoPanel()
    {
        InfoPanel.SetActive(false);
    }

    public void BuildingPlaced()
    {
        if (!firstToolsDialogShown)
        {
            dialogUI.ShowDialogue(firstToolsDialog);
            firstToolsDialogShown = true;
        }
    }
}
