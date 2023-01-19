using UnityEngine;

public class ThirdSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _startImage = default;
    [SerializeField] private Sprite _switchSprite = default;

    private static bool _isClear = false;

    public static bool IsClear { get => _isClear; set => _isClear = value; }

    private void Update()
    {
        if (_isClear)
        {
            _startImage.GetComponent<SpriteRenderer>().sprite = _switchSprite;
        }
    }
}
