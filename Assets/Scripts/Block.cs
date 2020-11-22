using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private bool _indestructible;

    private LevelManager _level;

    // Start is called before the first frame update
    void Start()
    {
        _level = FindObjectOfType<LevelManager>();
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
                Destroy(gameObject);
            }
        }
    }

    private void BlockLoadNextLevel()
    {
        int blocks = GameObject.FindGameObjectsWithTag("Block").Length;

        if (blocks <= 0 && !_level.GetIsMenu())
        {
            _level.LoadNextLevel();
        }
    }
}
