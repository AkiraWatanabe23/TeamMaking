using UnityEngine;

/// <summary>
/// Player(テストなので、移動のみ)
/// </summary>
public class PlayerTest : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody2D _rb = default;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(h * _moveSpeed, v * _moveSpeed);
    }
}
