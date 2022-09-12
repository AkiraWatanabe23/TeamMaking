using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGimmick : MonoBehaviour
{
    bool isRotate = true;
    [SerializeField] public GameObject _rotateCube_One;
    [SerializeField] public GameObject _rotateCube_Two;
    [SerializeField] public GameObject _rotateCube_Three;
    [SerializeField] public GameObject _rotateCube_Four;

    /// <summary>
    /// �I�u�W�F�N�g��]�M�~�b�N1
    /// </summary>
    public void FirstButtonClick()
    {
        if (isRotate == true)
        {
            isRotate = false;
            StartCoroutine(RotateFirst());
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g��]�M�~�b�N2
    /// </summary>
    public void SecondButtonClick()
    {
        if (isRotate == true)
        {
            isRotate = false;
            StartCoroutine(RotateSecond());
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g��]�M�~�b�N3
    /// </summary>
    public void ThirdButtonClick()
    {
        if (isRotate == true)
        {
            isRotate = false;
            StartCoroutine(RotateThird());
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g��]�M�~�b�N4
    /// </summary>
    public void ForthButtonClick()
    {
        if (isRotate == true)
        {
            isRotate = false;
            StartCoroutine(RotateForth());
        }
    }

    /// <summary>
    /// Cube�������ʒu�ɖ߂�
    /// </summary>
    public void ResetButtonClick()
    {
        _rotateCube_One.transform.rotation = Quaternion.Euler(0, 0, 45);
        _rotateCube_Two.transform.rotation = Quaternion.Euler(0, 0, 45);
        _rotateCube_Three.transform.rotation = Quaternion.Euler(0, 0, 45);
        _rotateCube_Four.transform.rotation = Quaternion.Euler(0, 0, 45);
    }

    IEnumerator RotateFirst()
    {
        int i = 0;
        while (i < 90)
        {
            i++;
            _rotateCube_One.transform.Rotate(0, 0, 1);
            _rotateCube_Two.transform.Rotate(0, 0, 1);
            _rotateCube_Three.transform.Rotate(0, 0, 1);
            yield return null;
        }
        isRotate = true;
    }

    IEnumerator RotateSecond()
    {
        int i = 0;
        while (i < 90)
        {
            i++;
            _rotateCube_Two.transform.Rotate(0, 0, 1);
            _rotateCube_Three.transform.Rotate(0, 0, 1);
            _rotateCube_Four.transform.Rotate(0, 0, 1);
            yield return null;
        }
        isRotate = true;
    }

    IEnumerator RotateThird()
    {
        int i = 0;
        while (i < 90)
        {
            i++;
            _rotateCube_Three.transform.Rotate(0, 0, 1);
            _rotateCube_Four.transform.Rotate(0, 0, 1);
            _rotateCube_One.transform.Rotate(0, 0, 1);
            yield return null;
        }
        isRotate = true;
    }

    IEnumerator RotateForth()
    {
        int i = 0;
        while (i < 90)
        {
            i++;
            _rotateCube_Four.transform.Rotate(0, 0, 1);
            _rotateCube_One.transform.Rotate(0, 0, 1);
            _rotateCube_Two.transform.Rotate(0, 0, 1);
            yield return null;
        }
        isRotate = true;
    }
}
