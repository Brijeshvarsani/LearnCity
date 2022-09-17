using UnityEngine;

[CreateAssetMenu()]
public class ResourceTypeSO : ScriptableObject
{
    public string Name;
    public Sprite sprite;
    public int amount;
    public int progressionGoal;
}