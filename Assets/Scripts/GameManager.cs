using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action onVariablesChanged;

    private static byte _snowballs = 5;
    public static byte snowballs { get { return _snowballs; } set { _snowballs = value; onVariablesChanged?.Invoke(); } }

    private static int _score;
    public static int score { get { return _score; } set { _score = value; onVariablesChanged?.Invoke(); } }
}
