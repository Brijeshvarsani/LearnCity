using System.Collections.Generic;
using UnityEngine;

public class StarTracker : MonoBehaviour
{
    public List<HouseQuiz> buildingQuizList;

    private QuizResult quizResult;
    private UIManager uIManager;


    private void Start()
    {
        quizResult = FindObjectOfType<QuizResult>();
        uIManager = FindObjectOfType<UIManager>();
        buildingQuizList[0].BuildingUnlocked = true;
        for (int i = 0; i < buildingQuizList.Count; i++)
        {
            quizResult.quizCompeletionList.Add(false);
        }
    }

    private void Update()
    {
        for (int i = 1; i < buildingQuizList.Count; i++)
        {
            buildingQuizList[i].BuildingUnlocked = quizResult.quizCompeletionList[i - 1];
        }
        for (int i = 0; i < buildingQuizList.Count; i++)
        {
            buildingQuizList[i].BuildingCompelete = quizResult.quizCompeletionList[i];
        }
        int starCount = 0;
        for (int i = 0; i < buildingQuizList.Count; i++)
        {
            starCount += (buildingQuizList[i].BuildingCompelete ? 1 : 0);
        }
        uIManager.Star.amount = starCount;
    }
}
