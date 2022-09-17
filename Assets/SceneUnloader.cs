using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloader : MonoBehaviour
{
    public void UnloadCurrentScene()
    {
        SceneManager.LoadScene("level2");
    }
}
