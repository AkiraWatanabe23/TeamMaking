using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    [SerializeField]
    private float _moveSpeed = 5f;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        _rb2D.velocity = new Vector2(horizontal * _moveSpeed, _rb2D.velocity.y);

    }
}
