using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 15;
    private float _leftBound = -10; 

    private PlayerController _playerControllerScript;

    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(_playerControllerScript._gameOver == false)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if(transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }

    }

}//class
