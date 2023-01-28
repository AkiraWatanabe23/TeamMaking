using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GimmickMove : MonoBehaviour
{
    bool _test = false;
    public void Move(float x)
    {
        if(!_test)
        {
            _test = true;
            transform.DOMove(new Vector2(x, 0), 3)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => _test = false);
        }
    }
}
