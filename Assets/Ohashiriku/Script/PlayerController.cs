using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ��X�s�[�h")]
    private float _moveSpeed = 5f;
    [SerializeField, Tooltip("�W�����v�p���[")]
    private float _jumpForce = 5f;

    private StateMachine _stateMachine;

    public StateMachine StateMachine => _stateMachine;

    private Rigidbody2D _rb2D;

    public Rigidbody2D Rb2D => _rb2D;

    private Animator _anim;

    public Animator Anim => _anim;

    private CheckGround _checkGround;

    public CheckGround CheckGround => _checkGround;

    private float _horizontal;

    private Transform _firstTransform;

    private SpriteRenderer _sr;

    private void Awake()
    {
       // _stateMachine = new StateMachine(this);
    }
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _checkGround = GetComponent<CheckGround>();
        _firstTransform = transform;
       // _stateMachine.Init(_stateMachine.Idle);
       //anim.SetBool("IsRight", true);
    }

    private void Update()
    {
        Jump();
        Move();
    }

    public void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        if (_checkGround.GetCheckGround())
        {
            _rb2D.velocity = new Vector2(_horizontal * _moveSpeed, _rb2D.velocity.y);
            if (_horizontal > 0)
            {
                _sr.flipX = false;
                _anim.SetBool("IsMove", true);
            }
            else if (_horizontal < 0)
            {
                _sr.flipX = true;
                _anim.SetBool("IsMove", true);
            }
            else
            {
                _anim.SetBool("IsMove", false);
            }
        }
    }

    /// <summary>
    /// �W�����v
    /// </summary>
    public void Jump()
    {
        bool jumpKey = Input.GetButtonDown("Jump");
        if (jumpKey)
        {
            if (_checkGround.GetCheckGround())
            {
                _rb2D.velocity = new Vector2(0f, _jumpForce);
            }
        }

        if (!_checkGround.GetCheckGround())
        {
            _anim.SetBool("IsJump", true);
        }
        else
        {
            _anim.SetBool("IsJump", false);
        }
    }

    /// <summary>
    /// �X�^�[�g�n�_�����蒼��
    /// </summary>
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
