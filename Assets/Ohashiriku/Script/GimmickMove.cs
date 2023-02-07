using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GimmickMove : MonoBehaviour
{
    [SerializeField]
    private float _seconds = 5;

    private Transform _transform;
    private bool _isMoveYLoop = false;
    private bool _isMoveY = false;
    private bool _isDiagonalMove = false;
    private bool _isTest = false;
    private bool _isTest2 = false;

    private void Start()
    {
        _transform = transform;
    }

    public void MoveYLoop(float y)
    {
        if (!_isMoveYLoop)
        {
            _isMoveYLoop = true;
            _transform.DOLocalMoveY(y, _seconds)
            .SetLoops(2, LoopType.Yoyo)
            .OnKill(() => _isMoveYLoop = false);
        }
    }
    public void MoveY(float y)
    {
        if (!_isMoveY)
        {
            _isMoveY = true;
            _transform.DOLocalMoveY(y, _seconds);
        }
    }

    public void DiagonalMove(float diagonal)
    {
        if (!_isDiagonalMove)
        {
            _isDiagonalMove = true;
            _transform.DOLocalMove(new Vector2(diagonal, diagonal), _seconds)
            .SetLoops(2, LoopType.Yoyo)
            .OnKill(() => _isDiagonalMove = false);
        }
    }

    public void MoveXMoveYLoop()
    {
        if (!_isTest)
        {
            _isTest = true;
            _transform.DOLocalMoveX(-5, _seconds)
                .OnComplete(() => _transform.DOLocalMoveY(-5, _seconds)
                .OnComplete(() => _transform.DOLocalMoveY(0, _seconds)
                .OnComplete(() => _transform.DOLocalMoveX(0, _seconds)
                .OnComplete(() => _isTest = false))));
                
        }
    }

    public void MoveYMoveXLoop()
    {
        if (!_isTest2)
        {
            _isTest2 = true;
            _transform.DOLocalMoveY(-6, _seconds)
                .OnComplete(() => _transform.DOLocalMoveX(-6, _seconds)
                .OnComplete(() => _transform.DOLocalMoveX(0, _seconds)
                .OnComplete(() => _transform.DOLocalMoveY(0, _seconds)
                .OnComplete(() => _isTest2 = false))));
        }
    }
}
