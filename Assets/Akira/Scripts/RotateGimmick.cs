using System.Collections;
using UnityEngine;

/// <summary>
/// êŒëúÇÃâÒì]ÉMÉ~ÉbÉN
/// </summary>
public class RotateGimmick : MonoBehaviour
{
    [SerializeField] private GameObject[] _cubes = new GameObject[4];
    [SerializeField] private ThirdSceneManager _manager = default;

    private bool _isRotate = true;

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
        foreach (var rot in _cubes)
        {
            rot.transform.rotation = Quaternion.Euler(0, 0, 45);
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
