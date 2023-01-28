using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private bool _isGround = false;
    private bool _isJump = false;

    public bool IsJump => _isJump;
    public bool GetCheckGround()
    {
        return _isGround;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
            _isJump = true;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            _isJump = false;
        }
    }
}