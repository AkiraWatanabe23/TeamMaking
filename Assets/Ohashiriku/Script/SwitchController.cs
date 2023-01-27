using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEvent = default;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�^�O�w��͉��A���ƂŃC���^�[�t�F�[�X�Ŏ�������
        if(collision.gameObject.tag == "Player")
        {
            _onEvent?.Invoke();
        }
    }
}
