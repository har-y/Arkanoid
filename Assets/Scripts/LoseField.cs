using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseField : MonoBehaviour
{
    private LevelManager _levelManager;
    private ScoreManager _scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        _levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        _scoreManager = GameObject.FindGameObjectWithTag("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _levelManager.GameOver();
        _scoreManager.ResetScore();
        Debug.Log("game over");
    }
}
