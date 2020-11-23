using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private bool _indestructible;
    [SerializeField] private int _blockPoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BlockLoadNextLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (_indestructible)
            {
                _audioManager.PlaySound(_audioManager.brickIndestructibleHitSound);
            }
            else
            {
                _audioManager.PlaySound(_audioManager.brickHitSound);
                _scoreManager.AddScore(_blockPoints);
                Destroy(gameObject);
            }
        }
    }

    private void BlockLoadNextLevel()
    {
        int blocks = GameObject.FindGameObjectsWithTag("Block").Length;

        if (blocks <= 0)
        {
            _levelManager.LoadNextLevel();
        }
    }

    public bool GetIndestructible()
    {
        return _indestructible;
    }
}
