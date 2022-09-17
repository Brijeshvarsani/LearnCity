using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public int currentProgression = 0;
    public int timeBetweenGrowths;
    public List<Sprite> sprites;
    private Sprite startingSprite;
    public SpriteRenderer spriteRenderer;
    public int totalStageCount;
    public FarmingStation farmingStation;

    public float StageProgress;
    private float timeRemainingToNextStage;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingSprite = spriteRenderer.sprite;
        totalStageCount = sprites.Count + 1;
        timeRemainingToNextStage = timeBetweenGrowths;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemainingToNextStage -= Time.deltaTime;
        if (timeRemainingToNextStage <= 0)
        {
            if (farmingStation != null && farmingStation.Watered && farmingStation.Fertilized)
            {
                Growth();
            }
            else if (farmingStation == null)
            {
                Growth();
            }
        }
        StageProgress = 1 - Mathf.Max(timeRemainingToNextStage, 0) / timeBetweenGrowths;
    }

    public void RestartGrowth()
    {
        currentProgression = 0;
        spriteRenderer.sprite = startingSprite;
        timeRemainingToNextStage = timeBetweenGrowths;
    }

    private void Growth()
    {
        if (currentProgression < sprites.Count)
        {
            currentProgression++;
            spriteRenderer.sprite = sprites[currentProgression - 1];
            timeRemainingToNextStage = timeBetweenGrowths;

            if (farmingStation != null && currentProgression % 2 == 0)
            {
                if (Random.value < GameSettings.unwaterChance)
                {
                    farmingStation.Watered = false;
                }
                if (Random.value < GameSettings.unfertilizeChance)
                {
                    farmingStation.Fertilized = false;
                }
            }

        }
    }
}
