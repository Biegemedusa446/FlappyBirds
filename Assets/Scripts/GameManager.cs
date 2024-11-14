using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _startGameCanvas;
    [SerializeField] private GameObject _pauseMenuCanvas;
    [SerializeField] private GameObject _pauseButton;

    [Header("Pipe Spawners")]
    [SerializeField] private GameObject _easySpawner;
    [SerializeField] private GameObject _hardSpawner;

    public enum Difficulty { Easy, Hard }
    public Difficulty currentDifficulty = Difficulty.Easy;

    private bool _isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 0f;

        if (_gameOverCanvas != null) _gameOverCanvas.SetActive(false);
        if (_startGameCanvas != null) _startGameCanvas.SetActive(true);
        if (_pauseMenuCanvas != null) _pauseMenuCanvas.SetActive(false);
        if (_pauseButton != null) _pauseButton.SetActive(false);

        if (_easySpawner != null) _easySpawner.SetActive(false);
        if (_hardSpawner != null) _hardSpawner.SetActive(false);
    }

    public void SetEasyDifficulty()
    {
        currentDifficulty = Difficulty.Easy;
        Debug.Log("Difficulty Set to Easy");
    }

    public void SetHardDifficulty()
    {
        currentDifficulty = Difficulty.Hard;
        Debug.Log("Difficulty Set to Hard");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        if (_startGameCanvas != null)
        {
            _startGameCanvas.SetActive(false);
        }

        if (_pauseButton != null)
        {
            _pauseButton.SetActive(true);
        }

        if (currentDifficulty == Difficulty.Easy)
        {
            if (_easySpawner != null) _easySpawner.SetActive(true);
            if (_hardSpawner != null) _hardSpawner.SetActive(false);
            Debug.Log("Easy Spawner Activated");
        }
        else if (currentDifficulty == Difficulty.Hard)
        {
            if (_easySpawner != null) _easySpawner.SetActive(false);
            if (_hardSpawner != null) _hardSpawner.SetActive(true);
            Debug.Log("Hard Spawner Activated");
        }
    }

    public void GameOver()
    {
        if (_gameOverCanvas != null)
        {
            _gameOverCanvas.SetActive(true);
        }

        Time.timeScale = 0f;

        if (_pauseButton != null)
        {
            _pauseButton.SetActive(false);
        }

       
        if (_easySpawner != null) _easySpawner.SetActive(false);
        if (_hardSpawner != null) _hardSpawner.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        if (!_isPaused)
        {
            _isPaused = true;
            Time.timeScale = 0f;
            if (_pauseMenuCanvas != null) _pauseMenuCanvas.SetActive(true);
            if (_pauseButton != null) _pauseButton.SetActive(false);
            Debug.Log("Game Paused");
        }
    }

    public void ResumeGame()
    {
        if (_isPaused)
        {
            _isPaused = false;
            Time.timeScale = 1f;
            if (_pauseMenuCanvas != null) _pauseMenuCanvas.SetActive(false);
            if (_pauseButton != null) _pauseButton.SetActive(true);
            Debug.Log("Game Resumed");
        }
    }
        public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
