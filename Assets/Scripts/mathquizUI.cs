using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static mathquizManager;

public class mathquizUI : MonoBehaviour
{
    [SerializeField] private mathquizManager quizManager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private List<TMP_InputField> userInput;
    [SerializeField] private Button submitButton;
    [SerializeField] public GameObject Panel;
    [SerializeField] public GameObject failPanel;
    

    private Question question;
    private bool answered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetQuestion(Question question)
    {
        this.question = question;
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(true);
        questionImage.sprite = question.questionImage;

        questionText.text = question.questionInfo;
        

    }

    public void submitAnswer()
    {
        
        bool val = quizManager.answer(userInput);

        if (val)
        {
            Debug.Log("good job");
            if(Panel != null)
            {
                Panel.SetActive(true);
            }

        }
        else
        {
            Debug.Log("wrong answer");
            if (failPanel != null)
            {
                failPanel.SetActive(true);
                StartCoroutine(RestartGame(SceneManager.GetActiveScene().buildIndex));
               
            }
        }
    }

    IEnumerator RestartGame(int LevelIndex)
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(LevelIndex);
    }

    public void closePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }

        if(failPanel != null)
        {
            failPanel.SetActive(false);
        }

    }
}
