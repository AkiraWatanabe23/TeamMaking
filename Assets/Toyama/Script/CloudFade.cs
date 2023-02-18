using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFade : MonoBehaviour
{
    private bool _cloudCheck = false;
    public bool CloudCheck { get => _cloudCheck; }
    [SerializeField] Animator _anim = null;
    [SerializeField] string _animeName = "";

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            _anim.Play(_animeName);
        }
    }
}
