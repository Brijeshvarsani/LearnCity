using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTransition : MonoBehaviour
{
    public Animator transitions;
    public float transitionTime = 4f;
    public void StartGame()
    {
        LoadTheGame();
    }

    public void LoadTheGame()
    {
        StartCoroutine(StartAnimation(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator StartAnimation(int LevelIndex)
    {
        transitions.SetTrigger("Start");

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(LevelIndex);
    }
} 
