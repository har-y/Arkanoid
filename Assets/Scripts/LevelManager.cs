using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool _menu;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _blocks;


    // Start is called before the first frame update
    void Start()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
        BlockLoadNextLevel();
    }

    private void StartGame()
    {
        if (Input.GetMouseButtonDown(0) && _menu)
        {
            LoadNextLevel();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        int lastIndex = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(lastIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_currentLevel + 1);
    }

    private void BlockLoadNextLevel()
    {
        _blocks = GameObject.FindGameObjectsWithTag("Block").Length;

        if (_blocks <= 0 && !_menu)
        {
            LoadNextLevel();
        }
    }
}
