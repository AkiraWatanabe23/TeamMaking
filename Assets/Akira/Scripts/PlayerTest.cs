using UnityEngine;

/// <summary>
/// Player(テストなので、移動のみ)
/// </summary>
public class PlayerTest : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody2D _rb = default;
    private Animator _anim = default;
    private SpriteRenderer _renderer = default;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
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

            _renderer.flipX = h > 0 ? false : true;
        }
        else
        {
            _anim.SetBool("IsIdle", true);
            _anim.SetBool("IsWalk", false);
        }

        _rb.velocity = new Vector2(h * _moveSpeed, v * _moveSpeed);
    }
}
