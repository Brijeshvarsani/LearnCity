using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropTypeSelectUI : MonoBehaviour
{
    [SerializeField] private List<CropSO> cropSOList;
    [SerializeField] private Button harvestButton;
    [SerializeField] private float offset = 60;
    [SerializeField] private TextMeshProUGUI currentCropValue;
    [SerializeField] private GameObject currentCropSpriteObject;
    [SerializeField] private TextMeshProUGUI currentStageValue;
    [SerializeField] private Image currentStageProgress;
    [SerializeField] private GameObject ProgressBar;
    [SerializeField] private TextMeshProUGUI FarmLevelDisplay;
    [SerializeField] private TextMeshProUGUI wateredValue;
    [SerializeField] private TextMeshProUGUI fertilizedValue;
    [SerializeField] private Color32 warningColor;
    [SerializeField] private Color32 normalColor;
    [SerializeField] public int FarmLevel = 1;
    public TextMeshProUGUI FarmLevelValue;

    [SerializeField] private List<CropTypeUIData> CropTypeUIDataList = new List<CropTypeUIData>();
    private FarmingStation currentFarmingStation;
    private PlantGrowth currentPlant;

    private UIManager uIManager;
    private Image currentCropImage;

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        currentCropImage = currentCropSpriteObject.GetComponent<Image>();
        foreach (CropSO crop in cropSOList)
        {
            crop.unlocked = false;
        }
        PopulateCropTypes();
    }

    private void Update()
    {
        FarmLevelValue.text = FarmLevel.ToString();

        if (currentFarmingStation != null)
        {
            wateredValue.text = currentFarmingStation.Watered ? "Yes" : "No";
            wateredValue.color = currentFarmingStation.Watered ? normalColor : warningColor;
            fertilizedValue.text = currentFarmingStation.Fertilized ? "Yes" : "No";
            fertilizedValue.color = currentFarmingStation.Fertilized ? normalColor : warningColor;
        }

        if (hasActiveCrop())
        {
            ProgressBar.SetActive(true);
            currentCropSpriteObject.SetActive(true);
            currentPlant = currentFarmingStation.plantObjects[0].GetComponent<PlantGrowth>();
            currentCropImage.sprite = currentPlant.spriteRenderer.sprite;
            harvestButton.interactable = isCurrentCropCompelete();
            currentStageValue.text = (currentPlant.currentProgression + 1).ToString();
            currentStageProgress.fillAmount = currentPlant.StageProgress;
        }
        else
        {
            ProgressBar.SetActive(false);
            currentCropSpriteObject.SetActive(false);
            harvestButton.interactable = false;
            currentStageValue.text = "No Crop";
        }

        foreach (CropTypeUIData cropTypeUIData in CropTypeUIDataList)
        {
            cropTypeUIData.purchaseButton.interactable = cropTypeUIData.unlockCost <= uIManager.Gold.amount;
        }
    }

    private struct CropTypeUIData
    {
        public Button purchaseButton;
        public Button cropTypeButton;
        public CropSO cropSO;
        public int unlockCost;
    }

    public void Initialize(FarmingStation farmingStation)
    {
        currentFarmingStation = farmingStation;
        if (farmingStation.CurrentCrop != null)
        {
            currentCropValue.text = farmingStation.CurrentCrop.Name;
        }
        else
        {
            currentCropValue.text = "Empty";
        }
        Debug.Log(CropTypeUIDataList.Count);
        foreach (CropTypeUIData cropTypeUIData in CropTypeUIDataList)
        {

            cropTypeUIData.cropTypeButton.onClick.AddListener(() =>
            {
                Debug.Log("cropclicked");
                farmingStation.CurrentCrop = cropTypeUIData.cropSO;
                currentCropValue.text = cropTypeUIData.cropSO.Name;
            });
        }
    }

    private void PopulateCropTypes()
    {
        Transform cropSelectTemplate = transform.Find("CropSelectTemplate");
        cropSelectTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (CropSO cropSO in cropSOList)
        {
            CropTypeUIData cropTypeUIData = new CropTypeUIData();
            Transform cropSelectTransform = Instantiate(cropSelectTemplate, transform);
            cropSelectTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * offset, 0);
            cropSelectTransform.Find("Image").GetComponent<Image>().sprite = cropSO.CropSprite;
            cropSelectTransform.gameObject.SetActive(true);

            Button cropTypeButton = cropSelectTransform.Find("Image").GetComponent<Button>();

            cropTypeButton.interactable = cropSO.unlocked;
            cropSelectTransform.Find("PurchaseButton").Find("GoldCost").GetComponent<TextMeshProUGUI>().text = cropSO.unlockCost.ToString();
            cropSelectTransform.Find("PurchaseButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                cropSO.unlocked = true;
                uIManager.Gold.amount -= cropSO.unlockCost;
                cropTypeButton.interactable = true;
                FarmLevel++;
                cropSelectTransform.Find("PurchaseButton").gameObject.SetActive(false);
            });

            cropTypeUIData.unlockCost = cropSO.unlockCost;
            cropTypeUIData.purchaseButton = cropSelectTransform.Find("PurchaseButton").GetComponent<Button>();
            cropTypeUIData.cropSO = cropSO;
            cropTypeUIData.cropTypeButton = cropTypeButton;
            CropTypeUIDataList.Add(cropTypeUIData);
            index++;
        }
    }

    public void HarvestCrop()
    {
        if (hasActiveCrop())
        {
            uIManager.Gold.amount += currentFarmingStation.CurrentCrop.sellValue;
            currentFarmingStation.RestartAllCropGrowth();
        }
    }

    private bool hasActiveCrop()
    {
        return currentFarmingStation != null && currentFarmingStation.CurrentCrop != null;
    }
    private bool isCurrentCropCompelete()
    {
        if (currentPlant != null)
            return currentPlant.currentProgression == currentPlant.totalStageCount - 1;
        return false;
    }
}
