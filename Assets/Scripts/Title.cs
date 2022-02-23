using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private GameObject guideOne;
    private GameObject guideTwo;

    private GameObject titleContainer;
    private GameObject guideContainer;
    private GameObject nextButton;

    private void Awake()
    {
        guideOne = transform.Find("GuideContainer/GuideOne").gameObject;
        guideTwo = transform.Find("GuideContainer/GuideTwo").gameObject;

        titleContainer = transform.Find("TitleContainer").gameObject;
        guideContainer = transform.Find("GuideContainer").gameObject;
        nextButton = transform.Find("GuideContainer/NextButton").gameObject;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        titleContainer.SetActive(false);
        guideContainer.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PreviousGuide()
    {
        if(guideOne.activeInHierarchy)
        {
            titleContainer.SetActive(true);
            guideContainer.SetActive(false);
        }
        else
        {
            guideOne.SetActive(true);
            guideTwo.SetActive(false);
            nextButton.SetActive(true);
        }
    }

    public void NextGuide()
    {
        if(guideOne.activeInHierarchy)
        {
            guideOne.SetActive(false);
            guideTwo.SetActive(true);
            nextButton.SetActive(false);
        }
    }
}
