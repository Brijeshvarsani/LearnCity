using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> buildingTypeSOList;
    [SerializeField] public List<Transform> buildingList;
    [SerializeField] private float offset = 60;
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private Image ResourceImage;
    [SerializeField] private TextMeshProUGUI resourceAmountValue;
    [SerializeField] private bool isBuildingTabOpen = false;

    private void Awake()
    {
        Transform buildingBtnTemplate = transform.Find("buildingBtnTemplate");
        buildingBtnTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (BuildingTypeSO buildingTypeSO in buildingTypeSOList)
        {
            Transform buildingBtnTransform = Instantiate(buildingBtnTemplate, transform);
            buildingBtnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * offset, 0);
            buildingBtnTransform.Find("Image").GetComponent<Image>().sprite = buildingTypeSO.sprite;
            buildingBtnTransform.Find("ResourceAmountValue").GetComponent<TextMeshProUGUI>().text = buildingTypeSO.RequiredResourceAmount.ToString();
            //Debug.Log(buildingTypeSO);
            buildingBtnTransform.Find("ResourceImage").GetComponent<Image>().sprite = buildingTypeSO.RequiredResourceType.sprite;
            buildingBtnTransform.gameObject.SetActive(true);

            buildingBtnTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() =>
            {
                buildingManager.SetActiveBuildingType(buildingTypeSO);
                buildingManager.BuildingMode = true;
            });
            buildingList.Add(buildingBtnTransform);
            index++;
        }
    }

    public void ToggleBuildingTab()
    {
        if (isBuildingTabOpen)
        {
            this.gameObject.SetActive(false);
            isBuildingTabOpen = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            isBuildingTabOpen = true;
        }
    }
}
