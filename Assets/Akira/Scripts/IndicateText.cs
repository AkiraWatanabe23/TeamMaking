using System.Collections.Generic;
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
    [Tooltip("表示させる内容")]
    [TextArea(1, 3)]
    [SerializeField] private List<string> _testText = new();
    [Tooltip("文字が出てくるときに流れる音")]
    [SerializeField] private AudioSource _wordAudio = default;

    private int _index = 0;
    private bool _isFinish = false;

    private void Start()
    {
        _wordAudio = GetComponent<AudioSource>();
        TextPlay();
    }

    private void Update()
    {
        //EnterKeyをクリックしたらテキストを表示する
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("play");
            if (!_isFinish)
                Skip();
            else
                TextPlay();
        }
    }

    private void TextPlay()
    {
        var before = _testText[_index];
        _viewText.text = "";
        //DOText...指定した文字列を指定した時間で1文字ずつ表示する
        //(文字が出るごとに音を再生)
        _viewText.DOText(_testText[_index], _indicateTime)
            .SetEase(Ease.Linear)
            .OnUpdate(() => { 
                var current = _viewText.text;
                if (before == current) return;
                var newChar = current[current.Length - 1].ToString();
                _wordAudio?.Play();
                before = current;
            });
            
        if (_index == _testText.Count - 1)
            _index = 0;
        else
            _index++;
        _isFinish = false;
    }

    private void Skip()
    {
        //DOComplete...実行中の処理を終了までスキップする
        _viewText.DOComplete();
        _isFinish = true;
    }
}
