using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
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

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_currentLevel + 1);
    }

    public bool GetIsMenu()
    {
        return _menu;
    }
}
