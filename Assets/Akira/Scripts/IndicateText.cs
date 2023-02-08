using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// テキスト表示のテスト
/// </summary>
public class IndicateText : MonoBehaviour
{
    [Tooltip("何秒かけて表示させるか")]
    [SerializeField] private float _indicateTime = 1f;
    [Tooltip("表示させるText")]
    [SerializeField] private Text _viewText = default;
    [SerializeField] private Text _open = default;
    [TextArea(1, 3)]
    [SerializeField] private string[] _testText = default;

    private int _index = 0;

    private void Start()
    {
        TextPlay();
    }

    public void TextPlay()
    {
        _viewText.text = "";
        //DOText...指定した文字列を指定した時間で1文字ずつ表示する
        _viewText.DOText(_testText[_index], _indicateTime).SetEase(Ease.Linear);
        if (_index == _testText.Length - 1)
            _index = 0;
        else
            _index++;
    }
}
