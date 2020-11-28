using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private int _blockPoints;
    [SerializeField] private int _blockHitPoints;

    // Start is called before the first frame update
    void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
        _scoreManager = GameObject.FindGameObjectWithTag("Score Manager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (tag == "Block (Indestructible)")
            {
                _audioManager.PlaySound(_audioManager.brickIndestructibleHitSound);
            }
            else if (tag == "Block (Destructible)")
            {
                _audioManager.PlaySound(_audioManager.brickHitSound);
                _blockHitPoints--;

                if (_blockHitPoints == 0)
                {
                    _scoreManager.AddScore(_blockPoints);
                    Destroy(gameObject);
                }
            }
        }
    }
}
