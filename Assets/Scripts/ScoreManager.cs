using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private static int _score;

    private Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
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

    public void ResetScore()
    {
        _score = 0;
    }

    private void ScoreUpdate()
    {
        _scoreText.text = TextScore(_score, 10);
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


}
