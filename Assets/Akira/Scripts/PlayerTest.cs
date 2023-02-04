using UnityEngine;

/// <summary>
/// Player(石像ギミックの俯瞰用のもの)
/// </summary>
public class PlayerTest : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField] private float _moveSpeed = 1f;

    private Vector2 _moveDir = default;
    private Rigidbody2D _rb = default;
    private Animator _anim = default;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var ver = Input.GetAxisRaw("Vertical");
        _moveDir = new Vector2(hor, ver);

        //移動の入力があればAnimation再生
        if (hor != 0)
        {
            _anim.SetBool("IsIdle", false);
            _anim.SetBool("IsWalk", true);

            if (hor > 0.2f)
            {
                var n = transform.localEulerAngles;
                n.y = 0f;
                n.z = 0;
                transform.localEulerAngles = n;
            }
            else
            {
                var n = transform.localEulerAngles;
                n.y = 180f;
                n.z = 0;
                transform.localEulerAngles = n;
            }
        }
        else if (ver != 0)
        {
            _anim.SetBool("IsIdle", false);
            _anim.SetBool("IsWalk", true);

            if (ver > 0.2f)
            {
                var n = transform.localEulerAngles;
                n.y = 0;
                n.z = 90f;
                transform.localEulerAngles = n;
            }
            else
            {
                var n = transform.localEulerAngles;
                n.y = 0;
                n.z = -90f;
                transform.localEulerAngles = n;
            }
        }
        else
        {
            _anim.SetBool("IsIdle", true);
            _anim.SetBool("IsWalk", false);
        }
        _rb.velocity = _moveDir * _moveSpeed;
    }
}
