using UnityEngine;

[CreateAssetMenu()]
public class QuestionSO : ScriptableObject
{
    public string Question;
    public string OptionA;
    public string OptionB;
    public string OptionC;
    public string OptionD;
    public string correctAnswer; 
}