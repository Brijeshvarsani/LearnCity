using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolMenuUI : MonoBehaviour
{
    [SerializeField] private List<ToolSO> toolSOList;
    [SerializeField] private float offset = 60;
    [SerializeField] private GameObject ToolUI;
    [SerializeField] ToolSO activeToolSO;
    [SerializeField] private List<ToolTypeUIData> toolUIList = new List<ToolTypeUIData>();
    [SerializeField] private Color32 highlightColor;
    [SerializeField] private Color32 normalColor;
    [SerializeField] private GameObject ToolModeCancelButton;
    [SerializeField] private GameObject ToolModeButtons;
    [SerializeField] public bool toolMode;
    [SerializeField] private Image selectedToolImage;

    private const string waterBucketName = "WaterBucket";
    private const string fertilizerName = "Fertilizer";

    public void toggleToolUI()
    {
        ToolUI.SetActive(!ToolUI.activeInHierarchy);
    }

    private struct ToolTypeUIData
    {
        public Image selectButtonImage;
        public Sprite toolImage;
        public ToolSO toolSO;
    }


    private void Awake()
    {
        Transform toolBtnTemplate = transform.Find("toolBtnTemplate");
        toolBtnTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ToolSO toolSO in toolSOList)
        {
            Transform toolBtnTransform = Instantiate(toolBtnTemplate, transform);
            toolBtnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * offset, 0);
            toolBtnTransform.Find("SelectButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                activeToolSO = toolSO;
                selectedToolImage.sprite = toolSO.ToolSprite;
                ToolModeButtons.SetActive(true);
                toolMode = true;
            });
            toolBtnTransform.Find("ToolImage").GetComponent<Image>().sprite = toolSO.ToolSprite;
            toolBtnTransform.gameObject.SetActive(true);

            ToolTypeUIData toolTypeUIData = new ToolTypeUIData();
            toolTypeUIData.selectButtonImage = toolBtnTransform.Find("SelectImage").GetComponent<Image>();
            toolTypeUIData.toolImage = toolBtnTransform.Find("ToolImage").GetComponent<Image>().sprite;
            toolTypeUIData.toolSO = toolSO;
            toolUIList.Add(toolTypeUIData);

            index++;
        }
        ToolModeCancelButton.GetComponent<Button>().onClick.AddListener(() => Cancel());
    }

    private void Update()
    {
        if (activeToolSO != null)
        {
            foreach (ToolTypeUIData toolTypeUIData in toolUIList)
            {
                toolTypeUIData.selectButtonImage.color = (toolTypeUIData.toolSO.Name == activeToolSO.Name) ? highlightColor : normalColor;
            }
        }
        else
        {
            foreach (ToolTypeUIData toolTypeUIData in toolUIList)
            {
                toolTypeUIData.selectButtonImage.color = normalColor;
            }
        }
    }

    public bool IsActiveToolWaterBucket()
    {
        return activeToolSO.Name == waterBucketName;
    }

    public bool IsActiveToolFertilizer()
    {
        Debug.Log(activeToolSO.Name);
        Debug.Log(fertilizerName);
        return activeToolSO.Name == fertilizerName;
    }

    public void Cancel()
    {
        activeToolSO = null;
        toolMode = false;
        ToolModeButtons.SetActive(false);
    }
}

