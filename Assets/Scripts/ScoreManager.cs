using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] private int _score;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate();
    }

    public void AddScore(int _blockPoints)
    {
        _score = _score + _blockPoints;
    }

    private void ScoreUpdate()
    {
        _scoreText.text = _score.ToString();
    }
}
