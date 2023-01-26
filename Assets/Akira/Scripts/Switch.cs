using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEvent = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _onEvent?.Invoke();
    }
}
