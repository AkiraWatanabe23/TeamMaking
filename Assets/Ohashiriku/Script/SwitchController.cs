using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEvent = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //タグ指定は仮、あとでインターフェースで実装する
        if(collision.gameObject.tag == "Player")
        {
            _onEvent?.Invoke();
        }
    }
}
