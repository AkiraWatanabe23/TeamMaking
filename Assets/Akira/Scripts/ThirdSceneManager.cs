using UnityEngine;

public class ThirdSceneManager : MonoBehaviour
{
    [SerializeField] private Transform[] _rotates = new Transform[4];
    [SerializeField] private GameObject _startImage = default;
    [SerializeField] private Sprite _switchSprite = default;

    private int _clearCount = 0;

    private void Start()
    {
        _clearCount = 0;
    }

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
        for (int i = 0; i < _rotates.Length; i++)
        {
            if (_rotates[i].localEulerAngles.z + 180 == RotateGimmick.StartRot[i] ||
                _rotates[i].localEulerAngles.z - 180 == RotateGimmick.StartRot[i])
            {
                _clearCount++;
            }
        }

        if (_clearCount == 4)
        {
            SwitchColor();
        }
        else
        {
            Debug.Log($"{_clearCount}, sorottenaiyo...");
            _clearCount = 0;
        }
    }

    private void SwitchColor()
    {
        Debug.Log("clear!!");
        _startImage.GetComponent<SpriteRenderer>().sprite = _switchSprite;
    }
}
