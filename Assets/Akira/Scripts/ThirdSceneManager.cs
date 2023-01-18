using UnityEngine;
using UnityEngine.UI;

public class ThirdSceneManager : MonoBehaviour
{
    [SerializeField] private Transform[] _rotates = new Transform[4];
    [SerializeField] private Image _clear = default;
    [SerializeField] private GameObject _startImage = default;
    [SerializeField] private Sprite _switchSprite = default;

    private int _clearCount = 0;
    private bool _isCurRot = false; //isCurrentRotate

    private void Start()
    {
        _clear.gameObject.SetActive(false);
        _clearCount = 0;
    }

    private void Update()
    {
        if (RotateGimmick.IsRotate != _isCurRot)
        {
            Check();
        }
    }

    private void Clear()
    {
        _clear.gameObject.SetActive(true);
    }

    private void Check()
    {
        //全てのオブジェクトが内側を向いたらクリア...Clear()を実行

        for (int i = 0; i < _rotates.Length; i++)
        {
            if (_rotates[i].localEulerAngles.z == RotateGimmick.StartRot[i])
            {
                _clearCount++;
                //Debug.Log($"{_clearCount}, {_rotates[i].gameObject.name}");
            }
        }

        if (_clearCount == 4)
        {
            Clear();
            SwitchColor();
        }
        else
        {
            _clearCount = 0;
        }
    }

    private void SwitchColor()
    {
        _startImage.GetComponent<SpriteRenderer>().sprite = _switchSprite;
    }
}
