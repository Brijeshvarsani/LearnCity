using UnityEngine;

public class Openanimation : MonoBehaviour
{
    public GameObject transitionAnimation;

    public void openAnimation()
    {
        if (transitionAnimation != null)
        {
            transitionAnimation.SetActive(true);
        }
    }
}
