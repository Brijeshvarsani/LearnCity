using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject targetIndicator;
    [SerializeField] private float targetIndicatorDuration;

    public void moveTarget()
    {
        if (Input.touchCount > 0)
        {
            transform.position = Helpers.GetTouchPosition();
            GameObject targetIndicatorObject = Instantiate(targetIndicator, transform);
            Destroy(targetIndicatorObject, targetIndicatorDuration);
        }
    }
}
