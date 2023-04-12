using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MovieFade : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 1f;

    private Image _image = default;
    private bool _isFade = false;

    public bool IsFade { get => _isFade; protected set => _isFade = value; }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        
    }

    public void FadeOut()
    {
        _isFade = true;
        _image.DOFade(0, _fadeTime).OnComplete(() =>
        {
            _isFade = false;

        });
    }
}
