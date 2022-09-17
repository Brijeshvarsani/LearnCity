using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressMenu : MonoBehaviour
{
    [SerializeField] private int CurrentScene;
    [SerializeField] private TextMeshProUGUI WoodGoalValue;
    [SerializeField] private TextMeshProUGUI FoodGoalValue;
    [SerializeField] private TextMeshProUGUI WaterGoalValue;
    [SerializeField] private TextMeshProUGUI PopulationGoalValue;
    [SerializeField] private TextMeshProUGUI StarGoalValue;
    [SerializeField] private TextMeshProUGUI CarGoalValue;
    [SerializeField] private Button Upgradebutton;
    private UIManager UIManager;
    // Start is called before the first frame update
    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        WoodGoalValue.text = "Wood: " + UIManager.Wood.amount.ToString() + "/" + GameSettings.woodProgressionGoal.ToString();
        //FoodGoalValue.text = "Food: " + UIManager.Food.amount.ToString() + "/" + GameSettings.foodProgressionGoal.ToString();
        WaterGoalValue.text = "Gold: " + UIManager.Gold.amount.ToString() + "/" + GameSettings.goldProgressionGoal.ToString();
        StarGoalValue.text = "Star: " + UIManager.Star.amount.ToString() + "/" + GameSettings.starProgressionGoal.ToString();
        PopulationGoalValue.text = "Population: " + UIManager.CurrentPopulation.ToString() + "/" + GameSettings.populationProgressionGoal.ToString();
        PopulationGoalValue.text = "Population: " + UIManager.CurrentPopulation.ToString() + "/" + GameSettings.populationProgressionGoal.ToString();
        CarGoalValue.text = "Car: " + UIManager.CarCount.ToString() + "/" + GameSettings.carProgressionGoal.ToString();
        if (CurrentScene == 3)
        {
            Upgradebutton.interactable = UIManager.CarCount >= GameSettings.carProgressionGoal;
        }
        else
        {
            Upgradebutton.interactable =
                UIManager.Wood.amount >= GameSettings.woodProgressionGoal &&
                //UIManager.Food.amount >= GameSettings.foodProgressionGoal &&
                //UIManager.Water.amount >= GameSettings.waterProgressionGoal &&
                UIManager.Gold.amount >= GameSettings.goldProgressionGoal &&
                UIManager.CurrentPopulation >= GameSettings.populationProgressionGoal &&
            UIManager.Star.amount >= GameSettings.starProgressionGoal;
        }
    }
}
