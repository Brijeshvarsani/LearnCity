using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager_Old : MonoBehaviour
{
    [SerializeField] private List<QuestionSO> questionList;
    [SerializeField] private TextMeshProUGUI QuestionText;
    [SerializeField] private TextMeshProUGUI OptionAText;
    [SerializeField] private TextMeshProUGUI OptionBText;
    [SerializeField] private TextMeshProUGUI OptionCText;
    [SerializeField] private TextMeshProUGUI OptionDText;
    [SerializeField] private GameObject OptionA;
    [SerializeField] private GameObject OptionB;
    [SerializeField] private GameObject OptionC;
    [SerializeField] private GameObject OptionD;
    private Image OptionAImage;
    private Image OptionBImage;
    private Image OptionCImage;
    private Image OptionDImage;
    private Button OptionAButton;
    private Button OptionBButton;
    private Button OptionCButton;
    private Button OptionDButton;
    [SerializeField] private Color32 CorrectColor;
    [SerializeField] private Color32 IncorrectColor;
    [SerializeField] private Color32 NormalColor;

    public delegate void QuizAnswerAction(bool result);
    public static event QuizAnswerAction OnquizAnswer;

    QuestionSO currentQuestion;

    private void Awake()
    {
        OptionAImage = OptionA.GetComponent<Image>();
        OptionBImage = OptionB.GetComponent<Image>();
        OptionCImage = OptionC.GetComponent<Image>();
        OptionDImage = OptionD.GetComponent<Image>();
        OptionAButton = OptionA.GetComponent<Button>();
        OptionBButton = OptionB.GetComponent<Button>();
        OptionCButton = OptionC.GetComponent<Button>();
        OptionDButton = OptionD.GetComponent<Button>();

        OptionAButton.onClick.AddListener(() => SelectOptionA());
        OptionBButton.onClick.AddListener(() => SelectOptionB());
        OptionCButton.onClick.AddListener(() => SelectOptionC());
        OptionDButton.onClick.AddListener(() => SelectOptionD());
        LoadQuestion();
    }
    public void LoadQuestion()
    {
        SetButtons(true);
        OptionAImage.color = NormalColor;
        OptionBImage.color = NormalColor;
        OptionCImage.color = NormalColor;
        OptionDImage.color = NormalColor;

        currentQuestion = questionList[Random.Range(0, questionList.Count)];
        QuestionText.text = currentQuestion.Question;
        OptionAText.text = currentQuestion.OptionA;
        OptionBText.text = currentQuestion.OptionB;
        OptionCText.text = currentQuestion.OptionC;
        OptionDText.text = currentQuestion.OptionD;
    }

    private void ShowCorrectAnswers()
    {
        OptionAImage.color = currentQuestion.correctAnswer == "A" ? CorrectColor : IncorrectColor;
        OptionBImage.color = currentQuestion.correctAnswer == "B" ? CorrectColor : IncorrectColor;
        OptionCImage.color = currentQuestion.correctAnswer == "C" ? CorrectColor : IncorrectColor;
        OptionDImage.color = currentQuestion.correctAnswer == "D" ? CorrectColor : IncorrectColor;
    }

    private void SetButtons(bool state)
    {
        OptionAButton.interactable = state;
        OptionBButton.interactable = state;
        OptionCButton.interactable = state;
        OptionDButton.interactable = state;
    }
    public void SelectOptionA()
    {
        SendQuizAnswerEvent(currentQuestion.correctAnswer == "A");
        SetButtons(false);
        ShowCorrectAnswers();
    }
    public void SelectOptionB()
    {
        SendQuizAnswerEvent(currentQuestion.correctAnswer == "B");
        SetButtons(false);
        ShowCorrectAnswers();
    }
    public void SelectOptionC()
    {
        SendQuizAnswerEvent(currentQuestion.correctAnswer == "C");
        SetButtons(false);
        ShowCorrectAnswers();
    }
    public void SelectOptionD()
    {
        SendQuizAnswerEvent(currentQuestion.correctAnswer == "D");
        SetButtons(false);
        ShowCorrectAnswers();
    }

    private static void SendQuizAnswerEvent(bool result)
    {
        if (OnquizAnswer != null)
        {
            OnquizAnswer(result);
        }
    }
}