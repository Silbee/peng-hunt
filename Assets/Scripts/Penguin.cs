using UnityEngine;

public class Penguin : MonoBehaviour
{
    new private Rigidbody2D rigidbody;
    new private SpriteRenderer renderer;

    private bool hit;
    private byte streak;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(transform.position.y < 0.5f && !GameManager.gameOver)
            SetRandomPosition();

        if(!hit)
            transform.rotation = Quaternion.Euler(0, 0, (rigidbody.velocity.x < 0 ? Vector2.Angle(Vector2.up, rigidbody.velocity) : -Vector2.Angle(Vector2.up, rigidbody.velocity)) + 90);
    }

    private void SetRandomPosition()
    {
        hit = false;
        streak = 0;

        transform.position = new Vector3(Random.Range(1, 8), 0.5f, transform.position.z);
        if(Random.value > 0.5f)
            transform.position += Vector3.right * 8;

        var randomXVelocity = Random.Range(1f, 3f);
        if(transform.position.x > 8)
            randomXVelocity *= -1;
        rigidbody.velocity = new Vector2(randomXVelocity, Random.Range(8f, 14f));

        renderer.flipY = rigidbody.velocity.x < 0;
    }

    public void KnockOut()
    {
        hit = true;
        streak++;
        GameManager.score += 1 * streak;
        rigidbody.angularVelocity = 720;
        var randomXVelocity = Random.Range(1f, 2f);
        if(Random.value > 0.5f)
            randomXVelocity *= -1;
        rigidbody.velocity = new Vector2(randomXVelocity, Random.Range(6f, 8f));

        PlayerPrefs.SetInt("highScore", GameManager.score);
        PlayerPrefs.Save();
    }
}
