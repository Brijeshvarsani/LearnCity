using UnityEngine;

public class House : MonoBehaviour
{
    public int houseSize;
    public delegate void HouseBuiltAction(int houseSize);
    public static event HouseBuiltAction OnHouseBuilt;


    private void Awake()
    {
        OnHouseBuilt(houseSize);
    }
}
