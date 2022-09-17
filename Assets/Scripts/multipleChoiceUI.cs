using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class multipleChoiceUI : MonoBehaviour
{
    [SerializeField] private multipleChoiceManager quizManager;
    [SerializeField] private Text questionText;
    [SerializeField] private Image questionImage;
    [SerializeField] private List<Button> options;
    [SerializeField] public GameObject Panel;

    
    private bool answered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick(Button btn)
    {

    }
    public void submitAnswer()
    {
        bool val = quizManager.answer("qwe");

        if (val)
        {
            Debug.Log("good job");
            if (Panel != null)
            {
                Panel.SetActive(true);
            }

        }
        else
        {
            Debug.Log("wrong answer");
        }
    }
}
