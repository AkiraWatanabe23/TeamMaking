using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 石像の回転ギミック
/// </summary>
public class RotateGimmick : MonoBehaviour
{
    [SerializeField] private KeyCode _rotateKey = KeyCode.Tab;
    [SerializeField] private GameObject[] _cubes = new GameObject[4];
    [Range(0f, 5f)]
    [SerializeField] private float _rotateSpeed = 1f;
    [SerializeField] private UnityEvent _rotateEvent = default;

    private bool _isRotate = false;
    private bool _isFinRot = false;
    private int _clearCount = 0;
    private readonly float[] _startRot = new float[4];

    public GameObject[] Cubes => _cubes;
    public bool IsRotate => _isRotate;
    public bool IsFinRot { get => _isFinRot; set => _isFinRot = value; }
    public float[] StartRot => _startRot;

    private void Start()
    {
        for (var i = 0; i < _startRot.Length; i++)
        {
            _startRot[i] = _cubes[i].transform.localEulerAngles.z;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_rotateKey))
        {
            _rotateEvent?.Invoke();
        }

        if (_isFinRot)
        {
            Debug.Log("check中...");
            Check();
            _isFinRot = false;
        }
    }

    private void Check()
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            //2つの浮動小数点数が「ほとんど」等しかったら
            if (Mathf.Approximately(_cubes[i].transform.localEulerAngles.z + 180, _startRot[i]) ||
                Mathf.Approximately(_cubes[i].transform.localEulerAngles.z - 180, _startRot[i]))
            {
                _clearCount++;
                _cubes[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                _cubes[i].transform.GetChild(0).gameObject.SetActive(true);
            }

            //比較したい2数の差の絶対値がごく小さかったら
            //if (Mathf.Abs(_cubes[i].localEulerAngles.z + 180 - _startRot[i]) < 0.1f ||
            //    Mathf.Abs(_cubes[i].localEulerAngles.z - 180 - _startRot[i]) < 0.1f)
            //{
            //    Debug.Log(_rotates[i].gameObject.name);
            //    _clearCount++;
            //}
        }

        if (_clearCount == 4)
        {
            Debug.Log("soroimasita!!");
            ThirdSceneManager.IsClear = true;
        }
        else
        {
            Debug.Log($"{_clearCount}, sorottenaiyo...");
            _clearCount = 0;
        }
    }

    public void ButtonClick(int num)
    {
        switch (num)
        {
            case 0:
                RotateReset();
                break;
            case 1:
            case 2:
            case 3:
            case 4:
                if (!_isRotate)
                {
                    _isRotate = true;
                    StartCoroutine(Rotate(num));
                }
                break;
        }
    }

    private void RotateReset()
    {
        for (var i = 0; i < _cubes.Length; i++)
        {
            var n = _cubes[i].transform.localEulerAngles;
            n.z = _startRot[i];
            _cubes[i].transform.localEulerAngles = n;
        }
    }

    private IEnumerator Rotate(int num)
    {
        int i = 0;
        int exclude = 0;
        switch (num)
        {
            case 1:
                exclude = 3;
                break;
            case 2:
                exclude = 0;
                break;
            case 3:
                exclude = 1;
                break;
            case 4:
                exclude = 2;
                break;
        }

        foreach (var n in _cubes)
        {
            n.transform.GetChild(0).gameObject.SetActive(false);
            n.transform.GetChild(1).gameObject.SetActive(false);
        }

        while (i < 90f / _rotateSpeed)
        {
            i++;
            for (int n = 0; n < _cubes.Length; n++)
            {
                if (n != exclude)
                    _cubes[n].transform.Rotate(0f, 0f, _rotateSpeed);
            }
            yield return null;
        }
        _isRotate = false;
        _isFinRot = true;
    }
}
