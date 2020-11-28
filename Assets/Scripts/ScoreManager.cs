using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private static int _score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
