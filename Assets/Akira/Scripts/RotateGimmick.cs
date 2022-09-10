using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGimmick : MonoBehaviour
{
    int _clickCount = 0;
    [SerializeField] public GameObject _rotateCube_One;
    [SerializeField] public GameObject _rotateCube_Two;
    [SerializeField] public GameObject _rotateCube_Three;
    [SerializeField] public GameObject _rotateCube_Four;
    Transform _oneTra;
    Transform _twoTra;
    Transform _threeTra;
    Transform _fourTra;

    void Start()
    {
        _oneTra = _rotateCube_One.transform;
        _twoTra = _rotateCube_Two.transform;
        _threeTra = _rotateCube_Three.transform;
        _fourTra = _rotateCube_Four.transform;
    }

    /// <summary>
    /// �I�u�W�F�N�g��]�M�~�b�N1
    /// </summary>
    public void FirstButtonClick()
    {
        _oneTra.Rotate(0, 0, 90, Space.World);
        _twoTra.Rotate(0, 0, 90, Space.World);
        _threeTra.Rotate(0, 0, 90, Space.World);
    }

    /// <summary>
    /// �I�u�W�F�N�g��]�M�~�b�N2
    /// </summary>
    public void SecondButtonClick()
    {
        _twoTra.Rotate(0, 0, 90, Space.World);
        _threeTra.Rotate(0, 0, 90, Space.World);
        _fourTra.Rotate(0, 0, 90, Space.World);
    }

    /// <summary>
    /// �I�u�W�F�N�g��]�M�~�b�N3
    /// </summary>
    public void ThirdButtonClick()
    {
        _threeTra.Rotate(0, 0, 90, Space.World);
        _fourTra.Rotate(0, 0, 90, Space.World);
        _oneTra.Rotate(0, 0, 90, Space.World);
    }

    /// <summary>
    /// �I�u�W�F�N�g��]�M�~�b�N4
    /// </summary>
    public void ForthButtonClick()
    {
        _fourTra.Rotate(0, 0, 90, Space.World);
        _oneTra.Rotate(0, 0, 90, Space.World);
        _twoTra.Rotate(0, 0, 90, Space.World);
    }

    /// <summary>
    /// Cube�������ʒu�ɖ߂�
    /// </summary>
    public void ResetButtonClick()
    {
        _oneTra.transform.rotation = Quaternion.Euler(0, 0, 45);
        _twoTra.transform.rotation = Quaternion.Euler(0, 0, 45);
        _threeTra.transform.rotation = Quaternion.Euler(0, 0, 45);
        _fourTra.transform.rotation = Quaternion.Euler(0, 0, 45);
    }
}
