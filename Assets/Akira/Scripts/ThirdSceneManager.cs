using UnityEngine;
using UnityEngine.UI;

public class ThirdSceneManager : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1f;
    [SerializeField] private Transform[] _rotates = new Transform[4];
    [SerializeField] private Image _clear = default;

    private int _clearCount = 0;

    public float RotateSpeed => _rotateSpeed;

    private void Start()
    {
        _clear.gameObject.SetActive(false);
        _clearCount = 0;
    }

    private void Update()
    {
        Check();
    }

    private void Clear()
    {
        _clear.gameObject.SetActive(true);
    }

    private void Check()
    {
        //全てのオブジェクトが内側を向いたらクリア...Clear()を実行
        //for (int i = 0; i < 4; i++)
        //{
        //    if (_rotates[i].transform.rotation == Quaternion.Euler(0, 0, -135))
        //    {
        //        _clearCount++;
        //        Debug.Log(_clearCount);
        //    }
        //    else
        //    {
        //        Debug.Log(_clearCount);
        //    }
        //}

        //if (_clearCount >= 4)
        //    Clear();
        //else
        //    _clearCount = 0;
    }
}
