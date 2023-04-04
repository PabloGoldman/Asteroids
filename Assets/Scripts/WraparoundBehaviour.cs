using UnityEngine;

public class WraparoundBehaviour : MonoBehaviour
{
    private float screenWidth;
    private float screenHeight;

    bool hasEnteredScreen;

    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        screenWidth = mainCamera.orthographicSize * 2f * Screen.width / Screen.height;
        screenHeight = mainCamera.orthographicSize * 2f;
    }

    private void Update()
    {
        if (!hasEnteredScreen)
        {
            CheckIfHasEnteredScreen();
        }
        else
        {
            CheckWraparound();
        }
    }

    private void CheckIfHasEnteredScreen()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
        {
            hasEnteredScreen = true;
        }
    }

    private void CheckWraparound()
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
