using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseQuiz : MonoBehaviour
{
    public string SceneName;
    public void GoToQuizScene()
    {
        if (SceneName != null && buildingUnlocked)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    private bool buildingUnlocked;
    private bool buildingCompelete;

    public SpriteRenderer StarImage;
    public SpriteRenderer LockImage;

    public bool BuildingUnlocked { get => buildingUnlocked; set { buildingUnlocked = value; LockImage.enabled = !value; } }
    public bool BuildingCompelete { get => buildingCompelete; set { buildingCompelete = value; StarImage.enabled = value; } }

    private void Start()
    {
        StarImage = transform.Find("Star").GetComponent<SpriteRenderer>();
        LockImage = transform.Find("Lock").GetComponent<SpriteRenderer>();
        BuildingUnlocked = false;
        BuildingCompelete = false;
    }
}
