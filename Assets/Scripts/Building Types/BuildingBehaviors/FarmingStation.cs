using System.Collections.Generic;
using UnityEngine;

public class FarmingStation : Building
{
    [SerializeField] private CropSO currentCrop;
    [SerializeField] private List<Transform> plantLocations;
    [SerializeField] public List<GameObject> plantObjects;
    [SerializeField] private float wateredStateDuration;
    [SerializeField] private Sprite WateredSprite;
    [SerializeField] private GameObject FertilizedEffect;
    private Sprite unWateredSprite;

    private SpriteRenderer spriteRenderer;
    private bool watered;
    private bool fertilized;

    public CropSO CurrentCrop
    {
        get => currentCrop;
        set
        {
            if (currentCrop != value)
            {
                currentCrop = value;
                SpawnCropSprites();
            }
        }
    }

    public bool Watered
    {
        get => watered; set
        {
            watered = value;
            spriteRenderer.sprite = (value ? WateredSprite : unWateredSprite);
        }
    }

    public bool Fertilized
    {
        get => fertilized; set
        {
            Debug.Log(fertilized);
            fertilized = value;
            FertilizedEffect.SetActive(value);
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        unWateredSprite = spriteRenderer.sprite;
    }

    public void RestartAllCropGrowth()
    {
        if (currentCrop != null)
        {
            foreach (GameObject plant in plantObjects)
            {
                plant.GetComponent<PlantGrowth>().RestartGrowth();
            }
        }
    }
    public void SpawnCropSprites()
    {
        if (currentCrop != null)
        {
            foreach (GameObject plant in plantObjects)
            {
                Destroy(plant);
            }
            plantObjects = new List<GameObject>();
            foreach (Transform location in plantLocations)
            {
                GameObject plant = Instantiate(CurrentCrop.Prefab, location);
                plant.GetComponent<PlantGrowth>().farmingStation = this;
                plantObjects.Add(plant);
            }
        }
    }
    public void Water()
    {
        Watered = true;
    }

    private void UnWater()
    {
        Watered = false;
    }
    public void Fertilize()
    {
        Fertilized = true;
    }
}
