using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mathquizManager : MonoBehaviour
{
    [SerializeField] private mathquizUI quizUI;
    [SerializeField]
    private List<Question> questions;
    private Question selectedQuestion;


    // Start is called before the first frame update
    void Start()
    {
        SelectQuestion();
    }

    void SelectQuestion()
    {
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];
         quizUI.SetQuestion(selectedQuestion);

    }

    public bool answer(List<TMP_InputField> userInput)
    {
        bool allCorrect = true;
        for (int i = 0; i < userInput.Count; i++)
        {
            if(userInput[i].text != selectedQuestion.correctAns[i])
            {
                allCorrect = false;
            }
        }

        return allCorrect;

    }

    [System.Serializable]
    public class Question
    {
        public string questionInfo;
        public List<TMP_InputField> userInput;
        public List<string> correctAns;
        public Sprite questionImage;
    }

    [System.Serializable]
    public enum questionType
    {
        IMAGE
    }
}
