using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float thrustSpeed = 1.0f;
    [SerializeField] float turnSpeed = 1.0f;

    float turnDirection;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTurnDirection();
    }

    private void FixedUpdate()
    {
        if (IsThrusting())
        {
            rb.AddForce(transform.up * thrustSpeed);
        }
    }

    bool IsThrusting()
    {
        return Input.GetAxisRaw("Vertical") > 0;
    }

    void SetTurnDirection()
    {
        turnDirection = Input.GetAxisRaw("Horizontal") * turnSpeed;
    }
}
