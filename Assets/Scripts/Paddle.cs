using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private SpriteRenderer _pipe;

    private Vector2 screenHalfSize;

    private float _mouseWorldPosition;
    private float _mousePosition;
    private float _paddleWidth;
    private float _pipeWidth;
    private float _leftClamp;
    private float _rightClamp;

    // Start is called before the first frame update
    void Start()
    {
        _pipeWidth = _pipe.bounds.size.x;
        _paddleWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;

        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize - _paddleWidth, Camera.main.orthographicSize);

        _leftClamp = -(screenHalfSize.x - _pipeWidth);
        _rightClamp = (screenHalfSize.x - _pipeWidth);
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        _mousePosition = Mathf.Clamp(_mouseWorldPosition, _leftClamp, _rightClamp);

        transform.position = new Vector3(_mousePosition, transform.position.y, 0f);
    }

    private float HitFactor(Vector2 ballPosition, Vector2 rocketPosition, float paddleWidth)
    {
        return (ballPosition.x - rocketPosition.x) / paddleWidth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            _audioManager.PlaySound(_audioManager.paddleHitSound);
        }
    }
}
