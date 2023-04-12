using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdSceneManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _startImage = default;
    [SerializeField] private Sprite _switchSprite = default;
    [SerializeField] private Fade _fade = default;

    private static bool _isClear = false;

    public static bool IsClear { get => _isClear; set => _isClear = value; }

    private void Update()
    {
        if (_isClear)
        {
            _startImage.sprite = _switchSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_isClear)
        {
            _fade.StartFadeOut
                (() => SceneManager.LoadScene("ThirdSceneClear"));
        }
        else
        {
            Debug.Log("まだクリアしてない");
        }
    }
}
