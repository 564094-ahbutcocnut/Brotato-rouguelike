using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Button restartButton;

    private bool gameRunning;

    public static GameManager instance;
    public string nextSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }

    public void GameOver()
    {
        gameRunning = false;
        gameOverPanel.SetActive(true);
    }

}
