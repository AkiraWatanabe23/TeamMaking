using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// テキスト表示のテスト
/// </summary>
public class IndicateText : MonoBehaviour
{
    [Tooltip("テキスト表示する時間")]
    [SerializeField] private float _indicateTime = 1f;
    [Tooltip("表示させるText")]
    [SerializeField] private Text _text = default;
    [SerializeField] private string _open = default;

    private void Start()
    {
        //DOText...指定した文字列を指定した時間で1文字ずつ表示する
        _text.DOText(_open, _indicateTime).SetEase(Ease.Linear);
    }

    private void Update()
    {
        
    }
}
