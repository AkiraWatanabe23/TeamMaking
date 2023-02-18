using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloudMove : MonoBehaviour
{

    [SerializeField] float _origin = 0f;
    [SerializeField] float _goal = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.DOMoveX(_origin, _goal).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
