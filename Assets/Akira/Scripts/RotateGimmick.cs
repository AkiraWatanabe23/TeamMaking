using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 石像の回転ギミック
/// </summary>
public class RotateGimmick : MonoBehaviour
{
    [SerializeField] private KeyCode _rotateKey = KeyCode.Tab;
    [SerializeField] private GameObject _target = default;
    [SerializeField] private GameObject[] _cubes = new GameObject[4];
    [Range(0f, 5f)]
    [SerializeField] private float _rotateSpeed = 1f;
    [SerializeField] private LayerMask _layer = default;
    [SerializeField] private UnityEvent _rotateEvent = default;

    private GameObject[] _muzzle = new GameObject[4];
    private GameObject[] _muzzleEnd = new GameObject[4];
    private bool _isFinRot = false;
    private int _clearCount = 0;
    private readonly float[] _startRot = new float[4];

    private void Start()
    {
        for (var i = 0; i < _startRot.Length; i++)
        {
            _muzzle[i] = _cubes[i].transform.GetChild(2).gameObject;
            _muzzleEnd[i] = _cubes[i].transform.GetChild(3).gameObject;
            _startRot[i] = _cubes[i].transform.localEulerAngles.z;
        }

        //for (var i = 0; i < 4; i++)
        //{
        //    _cubes[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        //    _cubes[i].transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.red;
        //}
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
        for (int i = 0; i < 4; i++)
        {
            Debug.DrawLine(_muzzle[i].transform.position, _muzzleEnd[i].transform.position, Color.blue, 5);
            if (Physics2D.Linecast(_muzzle[i].transform.position, _muzzleEnd[i].transform.position, _layer))
            {
                _clearCount++;
                _cubes[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                _cubes[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if (_clearCount == 4)
        {
            Debug.Log("soroimasita!!");
            ThirdSceneManager.IsClear = true;

            //for (var i = 0; i < 4; i++)
            //{
            //    _cubes[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
            //    _cubes[i].transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.green;
            //}
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
                StartCoroutine(Rotate(num));
                break;
        }
    }

    public void RotateReset()
    {
        if (!ThirdSceneManager.IsClear)
        {
            for (var i = 0; i < _cubes.Length; i++)
            {
                var n = _cubes[i].transform.localEulerAngles;
                n.z = _startRot[i];
                _cubes[i].transform.localEulerAngles = n;
            }
            Debug.Log("reset");
        }
        else
        {
            Debug.Log("既に揃っています");
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
        _isFinRot = true;
    }
}
