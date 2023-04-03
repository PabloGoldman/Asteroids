using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraparoundBehaviour : MonoBehaviour
{
    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        screenWidth = Camera.main.orthographicSize * 2f * Screen.width / Screen.height;
        screenHeight = Camera.main.orthographicSize * 2f;
    }

    void Update()
    {
        if (transform.position.x < -screenWidth / 2f)
        {
            transform.position = new Vector2(transform.position.x + screenWidth, transform.position.y);
        }
        else if (transform.position.x > screenWidth / 2f)
        {
            transform.position = new Vector2(transform.position.x - screenWidth, transform.position.y);
        }

        if (transform.position.y < -screenHeight / 2f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + screenHeight);
        }
        else if (transform.position.y > screenHeight / 2f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - screenHeight);
        }
    }
}
