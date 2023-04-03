using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
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

    public void SetTrajectory(Vector2 trajectory)
    {
        rb.AddForce(trajectory * speed);
    }
}
