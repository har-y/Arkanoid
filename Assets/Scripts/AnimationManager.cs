using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;
    private Block _block;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _block = GetComponent<Block>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (_block.GetIndestructible())
            {
                _animator.SetTrigger("gold_block");
            }
            else
            {
                _animator.SetTrigger("silver_block");
            }
        }
    }
}
