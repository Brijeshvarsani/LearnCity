using UnityEngine;

[CreateAssetMenu()]
public class BuildingTypeSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public ResourceTypeSO RequiredResourceType;
    public int RequiredResourceAmount;
}
