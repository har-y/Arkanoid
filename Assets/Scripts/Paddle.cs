using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 screenHalfSize;

    private float _mouseWorldPosition;
    private float _mousePosition;
    private float _paddleWidth;

    // Start is called before the first frame update
    void Start()
    {
        _paddleWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize - _paddleWidth, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        _mousePosition = Mathf.Clamp(_mouseWorldPosition, -screenHalfSize.x, screenHalfSize.x);
        transform.position = new Vector3(_mousePosition, transform.position.y, 0);
    }
}
