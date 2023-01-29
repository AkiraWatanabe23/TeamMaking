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

    private void Start()
    {
        _transform = transform;
    }

    public void MoveYLoop(float y)
    {
        if(!_isMoveYLoop)
        {
            _isMoveYLoop = true;
            _transform.DOMoveY(y, _seconds)
            .SetLoops(2, LoopType.Yoyo)
            .OnKill(() => _isMoveYLoop = false);
        }
    }
    public void MoveY(float y)
    {
        if (!_isMoveY)
        {
            _isMoveY = true;
            _transform.DOMoveY(y, _seconds)
            .OnKill(() => _isMoveY = false);
        }
    }

    public void DiagonalMove(float diagonal)
    {
        if (!_isDiagonalMove)
        {
            _isDiagonalMove = true;
            _transform.DOMove(new Vector2(diagonal, diagonal), _seconds)
            .SetLoops(2, LoopType.Yoyo)
            .OnKill(() => _isDiagonalMove = false);
        }
    }

    public void Test()
    {
        _transform.DOMoveX(5, _seconds);
        _transform.DOMoveY(5, _seconds);
    }


}
