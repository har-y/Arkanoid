using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private bool _indestructible;

    private Level _blocks;

    // Start is called before the first frame update
    void Start()
    {
        _blocks = FindObjectOfType<Level>();
        _blocks.BlocksCount();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }

        Destroy(gameObject);
    }
}
