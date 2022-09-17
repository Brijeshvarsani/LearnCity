using UnityEngine;

[CreateAssetMenu()]
public class CropSO : ScriptableObject
{
    public string Name;
    public Sprite CropSprite;
    public GameObject Prefab;
    public bool unlocked;
    public int unlockCost;
    public int sellValue;
}