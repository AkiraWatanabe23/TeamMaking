using System.Data;
using UnityEngine;

/// <summary>
/// Player(テストなので、移動のみ)
/// </summary>
public class PlayerTest : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody2D _rb = default;
    private Animator _anim = default;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        //移動の入力があれば
        if (h != 0 || v != 0)
        {
            _anim.SetBool("IsIdle", false);
            _anim.SetBool("IsWalk", true);

            if (h > 0)
            {
                var n = transform.localEulerAngles;
                n.z = 0f;
                transform.localEulerAngles = n;
            }
            else
            {
                var n = transform.localEulerAngles;
                n.z = 180f;
                transform.localEulerAngles = n;
            }

            if (v > 0)
            {
                var n = transform.localEulerAngles;
                n.z = -90f;
                transform.localEulerAngles = n;
            }
            else
            {
                var n = transform.localEulerAngles;
                n.z = 90f;
                transform.localEulerAngles = n;
            }
        }
        else
        {
            _anim.SetBool("IsIdle", true);
            _anim.SetBool("IsWalk", false);
        }

        _rb.velocity = new Vector2(h * _moveSpeed, v * _moveSpeed);
    }
}
