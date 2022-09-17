using UnityEngine;

[CreateAssetMenu()]
public class ResourceDepositSO : ScriptableObject
{
    public Sprite sprite;
    public string Name;
    [TextArea(3, 10)]
    public string description;
    public ResourceTypeSO resourceType;
    public int resourceAmount;
}