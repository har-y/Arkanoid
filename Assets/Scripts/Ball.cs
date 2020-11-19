using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Paddle _paddle;

    private Rigidbody2D _rb;

    private float _ballDirection;
    private float _ballForce;

    private bool _hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;

        _ballDirection = 1f;
        _ballForce = 12f;

        _hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted)
        {
            BallPaddlePosition();
            BallLaunchMove();
        }
    }

    private void BallPaddlePosition()
    {
        transform.position = new Vector3(_paddle.transform.position.x, transform.position.y, transform.position.z);
    }

    private void BallLaunchMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hasStarted = true;

            _rb.gravityScale = 1;
            _rb.velocity = new Vector2(_ballDirection, _ballForce);

            _audioManager.PlaySound(_audioManager.paddleHitSound);
        }
    }
}
