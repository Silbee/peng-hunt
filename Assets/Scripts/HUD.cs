using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Text snowballLabel;
    private Text scoreLabel;
    private Text highScoreLabel;

    private GameObject gameOverContainer;

    private void Awake()
    {
        snowballLabel = transform.Find("Snowballs").GetComponent<Text>();
        scoreLabel = transform.Find("Score").GetComponent<Text>();
        highScoreLabel = transform.Find("HighScore").GetComponent<Text>();

        gameOverContainer = transform.Find("GameOverContainer").gameObject;

        highScoreLabel.text = "HI-SCORE: " + PlayerPrefs.GetInt("highScore", 0);
        if(PlayerPrefs.GetInt("highScore", 0) != 0)
            highScoreLabel.text += "00";
        while(highScoreLabel.text.Length < 16)
            highScoreLabel.text = highScoreLabel.text.Insert(9, " ");
    }

    private void OnEnable()
    {
        GameManager.onSnowballsChanged += UpdateSnowballs;
        GameManager.onScoreChanged += UpdateScore;
        GameManager.onGameOver += DisplayGameOverInvoke;
    }

    private void OnDisable()
    {
        GameManager.onSnowballsChanged -= UpdateSnowballs;
        GameManager.onScoreChanged -= UpdateScore;
        GameManager.onGameOver -= DisplayGameOverInvoke;
    }

    private void UpdateSnowballs()
    {
        snowballLabel.text = "SNOWBALLS: " + GameManager.snowballs;
        while(snowballLabel.text.Length < 13)
            snowballLabel.text = snowballLabel.text.Insert(10, " ");
    }

    private void UpdateScore()
    {
        scoreLabel.text = "SCORE: " + GameManager.score + "00";
        while(scoreLabel.text.Length < 13)
            scoreLabel.text = scoreLabel.text.Insert(6, " ");
    }

    private void DisplayGameOverInvoke()
    {
        Invoke("DisplayGameOver", 1.2f);
    }

    private void DisplayGameOver()
    {
        gameOverContainer.SetActive(true);

        if(GameManager.score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", GameManager.score);
            PlayerPrefs.Save();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
        GameManager.gameOver = false;
        GameManager.snowballs = 50;
    }
}
