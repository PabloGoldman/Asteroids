using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;

    float size = 1.0f;
    [SerializeField] float minSize = 0.5f;
    [SerializeField] float maxSize = 1.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one * size;

        rb.mass = size;

        SetRandomRotation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetRandomRotation()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
    }
}
