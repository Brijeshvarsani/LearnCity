using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class EngQuiz1 : ScriptableObject
{
    public string Question;
    public Image image;
    public string OptionA;
    public string OptionB;
    public string OptionC;
    public string OptionD;
    public string correctAnswer;
}