using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityModifier;

    public bool isOnGround = true;

    public bool _gameOver;

    private Rigidbody _rBody;
    private Animator _animator;

    void Start()
    {
        _rBody = GetComponent<Rigidbody>();

        //Physics.gravity = Physics.gravity * gravityModifier;
        Physics.gravity *= gravityModifier;

        _animator = GetComponent<Animator>();     
    }//Start

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            _rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            //Play Jump animation
            _animator.SetTrigger("Jump_trig");
        }
    }//Update

    private void OnCollisionEnter(Collision target)
    {  
        if (target.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (target.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            _gameOver = true;

            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
        }
    }//OnCollisionEnter

}//class
