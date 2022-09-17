using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L9GameMAnager : MonoBehaviour
{
    public int buildingNumber;
    public GameObject ratio, car, grapes, dog, sheep, ratioBlack, carBlack, grapesBlack, dogBlack, sheepBlack, blockPanel, failPanel;


    Vector3 initialCarrotPosition, initialCarPosition, initialGrapesPosition, initialDogPosition, initialSheepPosition;

    bool ratioBool, carBool, grapesBool, dogBool, sheepBool = false;




    public GameObject PausePanel;
    public static bool gameIsPaused;

    void Start()
    {
        initialCarrotPosition = ratio.transform.position;
        initialCarPosition = car.transform.position;
        initialGrapesPosition = grapes.transform.position;
        initialDogPosition = dog.transform.position;
        initialSheepPosition = sheep.transform.position;

    }





    public void DragCarrot()
    {


        ratio.transform.position = Input.mousePosition;

    }


    public void DragCar()
    {


        car.transform.position = Input.mousePosition;

    }

    public void DragGrapes()
    {


        grapes.transform.position = Input.mousePosition;

    }

    public void DragDog()
    {


        dog.transform.position = Input.mousePosition;

    }

    public void DragSheep()
    {

        sheep.transform.position = Input.mousePosition;

    }








    public void DropCarrot()
    {

        float distance = Vector3.Distance(ratio.transform.position, ratioBlack.transform.position);
        if (distance < 50)
        {
            ratio.transform.position = ratioBlack.transform.position;
            if (ratioBlack.GetComponent<Image>().color != new Color32(96, 222, 41, 255))
            {
                Score.scoreNumber += 1;
            }
            ratioBool = true;
            ratioBlack.GetComponent<Image>().color = new Color32(96, 222, 41, 255);


        }
        else

        {
            ratio.transform.position = initialCarrotPosition;

        }




    }

    public void DropCar()
    {

        float distance = Vector3.Distance(car.transform.position, carBlack.transform.position);
        if (distance < 50)
        {
            car.transform.position = carBlack.transform.position;
            if (carBlack.GetComponent<Image>().color != new Color32(96, 222, 41, 255))
            {
                Score.scoreNumber += 1;
            }
            carBool = true;
            carBlack.GetComponent<Image>().color = new Color32(96, 222, 41, 255);

        }
        else
        {
            car.transform.position = initialCarPosition;

        }

    }

    public void DropGrapes()
    {

        float distance = Vector3.Distance(grapes.transform.position, grapesBlack.transform.position);
        if (distance < 50)
        {
            grapes.transform.position = grapesBlack.transform.position;
            if (grapesBlack.GetComponent<Image>().color != new Color32(96, 222, 41, 255))
            {
                Score.scoreNumber += 1;
            }
            grapesBool = true;
            grapesBlack.GetComponent<Image>().color = new Color32(96, 222, 41, 255);
        }
        else
        {
            grapes.transform.position = initialGrapesPosition;

        }

    }


    public void DropDog()
    {

        float distance = Vector3.Distance(dog.transform.position, dogBlack.transform.position);
        if (distance < 50)
        {
            dog.transform.position = dogBlack.transform.position;
            dog.transform.localScale = dogBlack.transform.localScale;
            if (dogBlack.GetComponent<Image>().color != new Color32(96, 222, 41, 255))
            {
                Score.scoreNumber += 1;
            }
            dogBool = true;
            dogBlack.GetComponent<Image>().color = new Color32(96, 222, 41, 255);
        }
        else
        {
            dog.transform.position = initialDogPosition;

        }



    }
    public void DropSheep()
    {

        float distance = Vector3.Distance(sheep.transform.position, sheepBlack.transform.position);
        if (distance < 50)
        {
            sheep.transform.position = sheepBlack.transform.position;
            if (sheepBlack.GetComponent<Image>().color != new Color32(96, 222, 41, 255))
            {
                Score.scoreNumber += 1;
            }
            sheepBool = true;
            sheepBlack.GetComponent<Image>().color = new Color32(96, 222, 41, 255);
        }
        else
        {
            sheep.transform.position = initialSheepPosition;

        }



    }


    void Update()
    {
        if (ratioBool && carBool && grapesBool && dogBool && sheepBool || Timer.time <= 0)
        {

            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        QuizResult quizResult = FindObjectOfType<QuizResult>();
        bool passed;
        if (Score.scoreNumber < 5)
        {
            failPanel.SetActive(true);
            passed = false;
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            blockPanel.SetActive(true);
            passed = true;
        }

        if (quizResult != null)
        {
            quizResult.quizCompeletionList[buildingNumber - 1] = passed;
        }
        yield return new WaitForSeconds(4f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("level2");
    }


    public void Setting()
    {

    }

    public void Resume()
    {

    }
    public void Pause()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
