using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Text snowballLabel;
    private Text scoreLabel;

    private void Awake()
    {
        snowballLabel = transform.Find("Snowball").GetComponent<Text>();
        scoreLabel = transform.Find("Score").GetComponent<Text>();
    }

    private void OnEnable()
    {
        GameManager.onVariablesChanged += UpdateHUD;
    }

    private void OnDisable()
    {
        GameManager.onVariablesChanged -= UpdateHUD;
    }

    private void UpdateHUD()
    {
        snowballLabel.text = "SNOWBALLS: " + GameManager.snowballs;
        while(snowballLabel.text.Length < 13)
            snowballLabel.text = snowballLabel.text.Insert(10, " ");

        scoreLabel.text = "SCORE: " + GameManager.score;
        while(scoreLabel.text.Length < 13)
            scoreLabel.text = scoreLabel.text.Insert(6, " ");
    }
}
