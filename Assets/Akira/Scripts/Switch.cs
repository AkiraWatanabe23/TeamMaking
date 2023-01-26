using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEvent = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //登録したイベントを実行する
        _onEvent?.Invoke();
    }
}
