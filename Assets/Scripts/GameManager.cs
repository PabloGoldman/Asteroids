using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject endGamePanel;

    void Start()
    {
        player.OnDie += ShowEndGameScreen;
    }

    void ShowEndGameScreen()
    {
        endGamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
