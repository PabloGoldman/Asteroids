using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 100.0f;

    float lifeTime = 5.0f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.AddForce(transform.up * speed);

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
