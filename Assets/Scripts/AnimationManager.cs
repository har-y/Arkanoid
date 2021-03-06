﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private bool _paddleAnimation;
    [SerializeField] private bool _blockAnimation;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        PaddleAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_blockAnimation)
        {
            if (collision.gameObject.tag == "Ball")
            {
                if (tag == "Block (Indestructible)")
                {
                    _animator.SetTrigger("gold_block");
                }
                else if (tag == "Block (Destructible)")
                {
                    _animator.SetTrigger("silver_block");
                }
            }
        }
    }

    private void PaddleAnimation()
    {
        if (_paddleAnimation)
        {
            _animator.SetTrigger("paddle");
        }
    }
}
