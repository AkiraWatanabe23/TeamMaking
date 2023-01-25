using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    [SerializeField]
    private float _moveSpeed = 5f;
    Animator _anim;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        _rb2D.velocity = new Vector2(horizontal * _moveSpeed, _rb2D.velocity.y);
        if (horizontal > 0)
        {
            _anim.Play("PlayerRight");
        }
        else if (horizontal < 0)
        {
            _anim.Play("PlayerLeft");
        }
        else
        {
            _anim.Play("TestPlayer");
        }
        bool jumpKey = Input.GetButtonDown("Jump");
        //if (jumpKey)
        //{
        //    if (checkGround.GetCheckGround())
        //    {
        //        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //ƒWƒƒƒ“ƒv‚ÌŒvŽZ
        //        _anim.SetBool("isJump", true);
        //    }

        //}
    }
}
