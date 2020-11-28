using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameState _currentState;

    [SerializeField] private int _currentLevel;
    [SerializeField] private int _lastLevel;
    [SerializeField] private int _blocks;


    // Start is called before the first frame update
    void Start()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _lastLevel = SceneManager.sceneCountInBuildSettings - 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLevel();
        CheckBlock();

        StartGame();
        LoadNextLevel();
        LoadRestartLevel();
    }

    public enum GameState
    {
        menu,
        level,
        gameOver
    }

    private void StartGame()
    {
        if (_currentState == GameState.menu)
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextLevel();
                _currentState = GameState.level;
            }
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
        _currentState = GameState.menu;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(_lastLevel);
        _currentState = GameState.gameOver;
    }

    private void LoadNextLevel()
    {
        if (_currentState == GameState.level)
        {
            if (_blocks <= 0)
            {
                NextLevel();
            }
        }
    }

    private void NextLevel()
    {
        if (_currentState != GameState.menu ||
            _currentState != GameState.gameOver)
        {
            if (_currentLevel != _lastLevel)
            {
                SceneManager.LoadScene(_currentLevel + 1);
            }
        }
    }

    private void LoadRestartLevel()
    {
        if (_currentState == GameState.gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                LoadMenu();
            }
        }
    }

    private void CheckLevel()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void CheckBlock()
    {
        _blocks = GameObject.FindGameObjectsWithTag("Block (Destructible)").Length;
    }

    public GameState CheckState()
    {
        return _currentState;
    }
}
