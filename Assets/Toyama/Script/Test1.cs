using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject Two;
    [SerializeField] GameObject Thre;
    [SerializeField] GameObject Four;

    private float _nowTime;
    [SerializeField] float _Cool;
    [SerializeField] float _Cool1;
    [SerializeField] float _Cool2;
    [SerializeField] float _Cool3;
    [SerializeField] AudioSource _ad;
    [SerializeField] AudioClip _se;

    void Start()
    {
        _ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _nowTime += Time.deltaTime;

        if(_Cool < _nowTime)
        {
            _ad.PlayOneShot(_se);
            one.SetActive(false);
            Two.SetActive(true);
        }
        if(_Cool1 < _nowTime)
        {
            _ad.PlayOneShot(_se);
            Two.SetActive(false);
            Thre.SetActive(true);
        }
        if(_Cool2 < _nowTime)
        {
            _ad.PlayOneShot(_se);
            Thre.SetActive(false);
            Four.SetActive(true);
        }
    }
}
