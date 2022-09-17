using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class multipleChoiceManager : MonoBehaviour
{

    [SerializeField]
    private List<Questions> questions;
    private Questions selectedQuestion;

    // Start is called before the first frame update
    void Start()
    {
        SelectQuestion();
    }

    // Update is called once per frame
    void SelectQuestion()
    {
        int val = Random.Range(0, questions.Count);
        selectedQuestion = questions[val];
    }

    public bool answer(string answer)
    {
        bool isCorrect = false;
        return isCorrect;
    }

    [System.Serializable]
    public class Questions
    {
        public string questionText;
        public List<string> options;
        public List<string> correctAns;
    }

    [System.Serializable]
    public enum questionType
    {
        TEXT
    }
}
