using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Rigidbody2D[] particles;

    private bool thrown;

    new private Rigidbody2D rigidbody;
    new private Collider2D collider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && GameManager.snowballs > 0 && !thrown)
            Throw();

        if(thrown)
            if(transform.localScale.x < 0.75f)
                Break();
        else
            transform.localScale -= 1.875f * Time.deltaTime * Vector3.one;
            

        collider.enabled = transform.localScale.x < 1.25f && transform.localScale.x > 0.75f && thrown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Penguin penguin))
        {
            penguin.KnockOut();
            Break();
        }
    }

    private void Break()
    {
        thrown = false;

        foreach(var particle in particles)
        {
            particle.transform.position = transform.position;
            particle.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f));
            particle.angularVelocity = Random.Range(-90f, 90f);
        }

        transform.position = new Vector3(-1, -1, 1);
    }

    private void Throw()
    {
        thrown = true;
        GameManager.snowballs--;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
        transform.rotation = Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f));
        transform.localScale = Vector3.one * 3;

        rigidbody.velocity = Vector2.up * 6;
        rigidbody.angularVelocity = Random.Range(45f, 90f);
        if(Random.value > 0.5f)
            rigidbody.angularVelocity *= -1;
    }
}
