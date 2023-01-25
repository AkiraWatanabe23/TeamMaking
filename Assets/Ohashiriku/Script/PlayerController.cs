using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _jumpForce = 5f;

    private Rigidbody2D _rb2D;
    private Animator _anim;
    private CheckGround _checkGround;
    private float _horizontal;


    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _checkGround = GetComponent<CheckGround>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    private void Move()
    {
        _rb2D.velocity = new Vector2(_horizontal * _moveSpeed, _rb2D.velocity.y);
        if (_horizontal > 0)
        {
            _anim.SetBool("IsRight", true);
        }
        else if (_horizontal < 0)
        {
            _anim.SetBool("IsLeft", true);
        }
        else
        {
            _anim.SetBool("IsRight", false);
            _anim.SetBool("IsLeft", false);
        }

    }

    private void Jump()
    {
        bool jumpKey = Input.GetButtonDown("Jump");
        if (jumpKey)
        {
            if (_checkGround.GetCheckGround())
            {
                _rb2D.velocity = new Vector2(0f, _jumpForce);
                _anim.SetBool("IsJump", true);
            }
        }
    }
    public void Isjump()
    {
        _anim.SetBool("IsJump", false);
    }
}
