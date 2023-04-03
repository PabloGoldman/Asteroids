using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float thrustSpeed = 1.0f;
    [SerializeField] float turnSpeed = 1.0f;

    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;

    public Action OnDie;

    float turnDirection;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetTurnDirection();

        if (Input.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (IsThrusting())
        {
            rb.AddForce(transform.up * thrustSpeed);
        }

        if (turnDirection != 0)
        {
            rb.AddTorque(turnDirection * turnSpeed * -1);
        }
    }

    private bool IsThrusting()
    {
        return Input.GetAxisRaw("Vertical") > 0;
    }

    private void SetTurnDirection()
    {
        turnDirection = Input.GetAxisRaw("Horizontal") * turnSpeed;
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
    }

    private void Die()
    {
        OnDie?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Die();
        }
    }
}
