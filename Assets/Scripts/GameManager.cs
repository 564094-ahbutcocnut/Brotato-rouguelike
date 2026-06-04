using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    [SerializeField] Button restartButton;

    private bool gameRunning;

    public static GameManager instance;
    public string nextSceneName;
    public string MainMenuScene;

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
        SceneManager.LoadScene(MainMenuScene);
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }

    public void GameOver()
    {
        gameRunning = false;
        SceneManager.LoadScene(nextSceneName);
    }

}
