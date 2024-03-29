using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoonLight : MonoBehaviour
{
    private Light2D _light = default;
    private float _time = 0f;
    private float _intensityTime = 0.2f;
    private float _intensity = 0.7f;
    private float _stop = 0.5f;
    private float _minus = 0.2f;

    [SerializeField]
    [Header(" 暗い時間")] float _interval = 1f;
    [SerializeField]
    [Header("明るい時間")] float _moonInterval = 3f;


    void Start()
    {
        _light = GetComponent<Light2D>();
    }

    void Update()
    {
        if (_light.intensity > _minus)//暗くする処理
        {
            _light.intensity -= Time.deltaTime;
        }
        _time += Time.deltaTime;

        if (_time > _interval)//明るくする処理
        {
            _intensityTime += Time.deltaTime;
            _light.intensity = _intensityTime;
            if (_intensityTime > _stop)//明るさを維持する処理
            {
                _light.intensity = _intensity;
                StartCoroutine("Interval");
            }
        }
    }

    /// <summary>
    /// 明るいまま、待つ処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator Interval()
    {
        yield return new WaitForSeconds(_moonInterval);
        _intensityTime = 0.2f;
        _time = 0f;
    }
}
