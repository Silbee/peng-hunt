using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public float secondsPerFrame;
    public Sprite[] sprites;

    private SpriteRenderer renderer;

    private float timer;
    private int index;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[0];
    }

    private void Update()
    {
        if(timer >= secondsPerFrame)
        {
            timer -= secondsPerFrame;
            index = index < sprites.Length - 1 ? index += 1 : 0;
            renderer.sprite = sprites[index];
        }

        timer += Time.deltaTime;
    }
}
