using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private GameObject _gameoverField;
    [SerializeField] private Text _score;


    // Start is called before the first frame update
    void Start()
    {
        _levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        _scoreManager = GameObject.FindGameObjectWithTag("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Score();
        IsGameOver();
    }

    private void IsGameOver()
    {
        if (LevelManager.GameState.gameOver == _levelManager.CheckState())
        {
            _gameoverField.SetActive(true);
        }
        else
        {
            _gameoverField.SetActive(false);
        }
    }

    private void Score()
    {
        _scoreManager.ScoreUpdate(_score);
    }
}
