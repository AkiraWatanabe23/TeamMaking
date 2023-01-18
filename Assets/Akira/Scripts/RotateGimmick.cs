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

    private static bool _isRotate = false;
    private static readonly float[] _startRot = new float[4];

    public static bool IsRotate => _isRotate;
    public static float[] StartRot => _startRot;

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
    }
}
