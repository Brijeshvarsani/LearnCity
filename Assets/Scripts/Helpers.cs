using UnityEngine;
using UnityEngine.SceneManagement;

internal static class Helpers
{
    public static void UnloadCurrentScene()
    {
        SceneManager.LoadScene("level2");
    }

    public static Vector3 GetMidpoint()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 3f));
    }
    public static Vector3 GetTouchPosition()
    {
        Touch touch = Input.GetTouch(0);
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0f;
        return touchPosition;
    }

    public static GameObject Raycast()
    {
        Vector3 touchPosWorld;

        //Change me to change the touch phase used.
        TouchPhase touchPhase = TouchPhase.Began;
        GameObject touchedObject = null;
        //We check if we have more than one touch happening.
        //We also check if the first touches phase is Ended (that the finger was lifted)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            //We transform the touch position into word space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //We now raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                touchedObject = hitInformation.transform.gameObject;
                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);
            }
        }
        return touchedObject;
    }
}