using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimator : MonoBehaviour
{
    public float framesPerSecond;
    public Sprite[] sprites;

    new private SpriteRenderer renderer;

    private float timer;
    private int index;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(timer >= framesPerSecond)
        {
            timer -= framesPerSecond;

            if(index < sprites.Length - 1)
                index++;
            else
                index = 0;

            renderer.sprite = sprites[index];
        }

        timer += Time.deltaTime; 
    }
}
