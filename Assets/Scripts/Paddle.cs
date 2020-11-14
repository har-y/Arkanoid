using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float _mouseWorldPosition;
    private float _mousePosition;

    private float _clampLeft;
    private float _clampRight;


    // Start is called before the first frame update
    void Start()
    {
        _clampLeft = -6.05f;
        _clampRight = 6.05f;
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        _mousePosition = Mathf.Clamp(_mouseWorldPosition, _clampLeft, _clampRight);
        transform.position = new Vector3(_mousePosition, transform.position.y, 0);
    }
}
