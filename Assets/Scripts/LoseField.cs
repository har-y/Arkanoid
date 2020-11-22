using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseField : MonoBehaviour
{
    [SerializeField] LevelManager _level;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _level.LoadMenu();
        Debug.Log("game over");
    }
}
