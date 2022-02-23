using UnityEngine;

[ExecuteInEditMode]
public class CanvasIntegerScaler : MonoBehaviour
{
    public Vector2 resolutionStep = new(320, 240);

    private Vector2 currentResolution;
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if(currentResolution.x != Screen.width || currentResolution.x != Screen.height)
            ScaleUI();
    }

    private void ScaleUI()
    {
        currentResolution.x = Screen.width;
        currentResolution.y = Screen.height;

        canvas.scaleFactor = Mathf.Max(Mathf.FloorToInt(Mathf.Min(currentResolution.x / resolutionStep.x, currentResolution.y / resolutionStep.y)), 1);
    }
}
