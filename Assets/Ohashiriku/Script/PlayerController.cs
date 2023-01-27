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
    private Transform _firstTransform;


    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _checkGround = GetComponent<CheckGround>();
        _firstTransform = transform;
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
                if (_horizontal >= 0)
                {
                    _anim.SetBool("IsJumpRight", true);
                }
                else
                {
                    _anim.SetBool("IsJumpLeft", true);
                }
                _rb2D.velocity = new Vector2(0f, _jumpForce);
                
            }
        }
    }
    public void Isjump()
    {
        _anim.SetBool("IsJumpRight", false);
        _anim.SetBool("IsJumpLeft", false);
    }
    private void PlayerReset()
    {
        transform.position = _firstTransform.position;
        _anim.Play("PlayerUp");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "���Z�b�g�p�̃^�O")
        {
            PlayerReset();
        }
    }
}
