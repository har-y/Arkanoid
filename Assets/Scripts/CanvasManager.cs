using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private GameObject _gameoverField;


    // Start is called before the first frame update
    void Start()
    {
        _levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
