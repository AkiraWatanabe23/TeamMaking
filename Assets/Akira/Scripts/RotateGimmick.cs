using System.Collections;
using UnityEngine;

/// <summary>
/// 石像の回転ギミック
/// </summary>
public class RotateGimmick : MonoBehaviour
{
    [SerializeField] private GameObject[] _cubes = new GameObject[4];
    [SerializeField] private ThirdSceneManager _manager = default;

    private bool _isRotate = true;
    private readonly int[] _startRot = new int[4];

    private void Start()
    {
        for (var i = 0; i < _startRot.Length; i++)
        {
            _startRot[i] = (int)_cubes[i].transform.localEulerAngles.z;
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
                if (_isRotate)
                {
                    _isRotate = false;
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

        while (i < 90f / _manager.RotateSpeed)
        {
            i++;
            for (int n = 0; n < _cubes.Length; n++)
            {
                if (n != exclude)
                    _cubes[n].transform.Rotate(0f, 0f, _manager.RotateSpeed);
            }
            yield return null;
        }
        _isRotate = true;
    }
}
