using UnityEngine;

public class ThirdSceneManager : MonoBehaviour
{
    [SerializeField] private Transform[] _rotates = new Transform[4];
    [SerializeField] private GameObject _startImage = default;
    [SerializeField] private Sprite _switchSprite = default;

    private int _clearCount = 0;

    private void Update()
    {
        if (RotateGimmick.IsFinRot)
        {
            Debug.Log("check中...");
            Check();
            RotateGimmick.IsFinRot = false;
        }
    }

    private void Check()
    {
        //現在のz軸のrotationの値が最初から180°回転したか
        for (int i = 0; i < _rotates.Length; i++)
        {
            //2つの浮動小数点数が「ほとんど」等しかったら
            if (Mathf.Approximately(_rotates[i].localEulerAngles.z + 180, RotateGimmick.StartRot[i]) ||
                Mathf.Approximately(_rotates[i].localEulerAngles.z - 180, RotateGimmick.StartRot[i]))
            {
                Debug.Log(_rotates[i].gameObject.name);
                _clearCount++;
            }
            //比較したい2数の差の絶対値がごく小さかったら
            //if (Mathf.Abs(_rotates[i].localEulerAngles.z + 180 - RotateGimmick.StartRot[i]) < 0.1f ||
            //    Mathf.Abs(_rotates[i].localEulerAngles.z - 180 - RotateGimmick.StartRot[i]) < 0.1f)
            //{
            //    Debug.Log(_rotates[i].gameObject.name);
            //    _clearCount++;
            //}
        }

        if (_clearCount == 4)
        {
            Debug.Log("soroimasita!!");
            _startImage.GetComponent<SpriteRenderer>().sprite = _switchSprite;
        }
        else
        {
            Debug.Log($"{_clearCount}, sorottenaiyo...");
            _clearCount = 0;
        }
    }
}
