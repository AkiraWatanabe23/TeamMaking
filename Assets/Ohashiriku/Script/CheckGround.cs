using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private bool _isGround = false;
    private bool _isJump = false;

    [SerializeField, Tooltip("床のエフェクト")]
    private Animator _effectAnim;

    public bool IsJump => _isJump;
    public bool GetCheckGround()
    {
        return _isGround;
    }

    private void Start()
    {
        _effectAnim.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
            _isJump = true;
        }
        if(collision.gameObject.tag == "Invisible")
        {
            _effectAnim.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Invisible")
        {
            _isGround = true;
            _isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Invisible")
        {
            _effectAnim.enabled = true;
        }
    }
}