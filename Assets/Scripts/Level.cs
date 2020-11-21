using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private int _blocks;
    [SerializeField] private bool _menu;

    private int _currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
        LoadNextLevel();
    }

    private void StartGame()
    {
        if (Input.GetMouseButtonDown(0) && _menu)
        {
            LoadFirstLevel();
        }
    }

    public void BlocksCount()
    {
        _blocks++;
    }

    public void BlockDestroyed()
    {
        _blocks--;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(_currentLevel + 1);
    }

    public void LoadNextLevel()
    {
        if (_blocks <= 0 && !_menu)
        {
            SceneManager.LoadScene(_currentLevel + 1);
        }
    }
}
