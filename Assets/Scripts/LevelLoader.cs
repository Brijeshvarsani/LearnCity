using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transitions;
    public float transitionTime = 4f;

    public string level1SceneName;
    public string level2SceneName;
    public string level3SceneName;
    public string level4SceneName;

    IEnumerator StartAnimation(string LevelIndex)
    {
        transitions.SetTrigger("Start");

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(LevelIndex);
    }
    public void LoadLevel1()
    {
        StartCoroutine(StartAnimation(level1SceneName));
    }
    
    public void LoadLevel2()
    {
        StartCoroutine(StartAnimation(level2SceneName));
    }
    public void LoadLevel3()
    {
        StartCoroutine(StartAnimation(level3SceneName));
    }
    public void LoadLevel4()
    {
        StartCoroutine(StartAnimation(level4SceneName));
    }
}
