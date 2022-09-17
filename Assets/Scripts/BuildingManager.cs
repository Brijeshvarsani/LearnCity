using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] public BuildingTypeSO activeBuildingType;
    [SerializeField] public bool buildingMode;
    [SerializeField] private GameObject buildingModeConfirm;
    [SerializeField] private GameObject buildingModeCancel;
    [SerializeField] private UIManager UiManager;
    public Transform buildingImage;


    public bool BuildingMode
    {
        get => buildingMode; set
        {
            if (!buildingMode && value) InstantiateImage();
            buildingMode = value;
            buildingModeConfirm.SetActive(value);
            buildingModeCancel.SetActive(value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
            //Debug.Log(EventSystem.current.IsPointerOverGameObject(0) + " " + Input.GetTouch(0).position);
            if (BuildingMode && Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject(0))
            {
                Vector3 touchPosition = Helpers.GetTouchPosition();
                buildingImage.transform.position = touchPosition;
            }
        if (buildingMode)
        {
            bool canSpawnBuilding = CanSpawnBuilding();
            buildingModeConfirm.GetComponent<Button>().interactable = canSpawnBuilding;
            //buildingModeConfirm.SetActive(canSpawnBuilding);
            if (!canSpawnBuilding)
            {
                buildingImage.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0f, 0f, 0.2f);

            }
            else
            {
                buildingImage.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
            }
        }
    }

    private void InstantiateImage()
    {
        buildingImage = Instantiate(activeBuildingType.prefab, Helpers.GetMidpoint(), Quaternion.identity);
        buildingImage.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
    }

    public void Confirm()
    {
        buildingImage.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1f);
        BuildingMode = false;
        activeBuildingType.RequiredResourceType.amount -= activeBuildingType.RequiredResourceAmount;
        UiManager.BuildingPlaced();
        if (buildingImage.tag == ("Car"))
        {
            UiManager.CarCount++;
        }
    }

    public void Cancel()
    {
        Destroy(buildingImage.gameObject);
        BuildingMode = false;
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSO)
    {
        activeBuildingType = buildingTypeSO;
    }

    public bool CanSpawnBuilding()
    {
        if (buildingImage != null)
        {
            return !BuildingOverlapping() && CanAffordBuilding();
        }
        return false;
    }

    private bool CanAffordBuilding()
    {
        return activeBuildingType.RequiredResourceType.amount >= activeBuildingType.RequiredResourceAmount;
    }

    private bool BuildingOverlapping()
    {
        BoxCollider2D buildingBoxCollider2D = buildingImage.GetComponent<BoxCollider2D>();

        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(LayerMask.GetMask("Building"));
        buildingBoxCollider2D.OverlapCollider(contactFilter2D, results);
        if (results.Count != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
