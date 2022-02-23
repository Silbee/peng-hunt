using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;

    public static event Action onSnowballsChanged;
    public static event Action onScoreChanged;
    public static event Action onGameOver;

    private static byte _snowballs = 50;
    public static byte snowballs
    {
        get { return _snowballs; }
        set
        {
            _snowballs = value;
            onSnowballsChanged?.Invoke();

            if(_snowballs == 0)
            {
                gameOver = true;
                onGameOver?.Invoke();
            }
        }
    }

    private static int _score;
    public static int score
    {
        get { return _score; }
        set
        {
            _score = value;
            onScoreChanged?.Invoke();
        }
    }
}
