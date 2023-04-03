using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;

    [HideInInspector] public float size = 1.0f;

    [SerializeField] float speed = 20.0f;

    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    float lifeTime = 30.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.localScale = Vector3.one * size;

        rb.mass = size;

        SetRandomRotation();

        Destroy(gameObject, lifeTime);
    }

    private void SetRandomRotation()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
    }

    public void SetVectorDirection(Vector2 trajectory)
    {
        rb.AddForce(trajectory * speed);
    }

    private void CreateSplitAsteroids()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector2 position = transform.position;
            position += Random.insideUnitCircle * 0.5f;

            Asteroid halfAsteroid = Instantiate(this, position, transform.rotation);
            halfAsteroid.size *= 0.5f;
            halfAsteroid.speed *= Random.Range(1.0f, 5.0f);
            halfAsteroid.SetVectorDirection(Random.insideUnitCircle.normalized);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (size * 0.5 >= minSize)
            {
                CreateSplitAsteroids();
            }
        }

        Destroy(gameObject);
    }
}
