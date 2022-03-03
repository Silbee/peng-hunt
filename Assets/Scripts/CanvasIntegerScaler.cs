using UnityEngine;

[ExecuteInEditMode]
public class CanvasIntegerScaler : MonoBehaviour
{
    public Vector2 resolutionStep = new Vector2(320, 240);

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
        currentResolution = new Vector2(Screen.width, Screen.height);
        canvas.scaleFactor = Mathf.Max((int)Mathf.Min(currentResolution.x / resolutionStep.x, currentResolution.y / resolutionStep.y), 1);
    }
}
