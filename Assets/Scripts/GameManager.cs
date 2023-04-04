using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] Player player;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] TextMeshProUGUI scoreText;

    public int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player.OnDie += ShowEndGameScreen;
        SetScore();
    }

    public void AddScore()
    {
        score++;
        SetScore();
    }

    private void SetScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void ShowEndGameScreen()
    {
        endGamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
