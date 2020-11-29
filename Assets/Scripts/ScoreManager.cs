using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private static int _score;
    [SerializeField] private static int _highScore;

    private string _highScoreKey = "HighScore";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreToHighScore();
    }

    public void AddScore(int _blockPoints)
    {
        _score = _score + _blockPoints;
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void ScoreUpdate(Text score)
    {
        score.text = TextScore(_score, 10);
    }

    public void HighScoreUpdate(Text highScore)
    {
        _highScore = PlayerPrefs.GetInt(_highScoreKey, 0);
        highScore.text = TextScore(_highScore, 10);
    }

    private string TextScore(int n, int fill)
    {
        string score = n.ToString();

        while (score.Length < fill)
        {
            score = "0" + score;
        }

        return score;
    }

    private void ScoreToHighScore()
    {
        if (_score > _highScore)
        {
            int tmpValue = _score;
            PlayerPrefs.SetInt(_highScoreKey, tmpValue);
        }
    }
}
