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
    [Header(" ˆÃ‚¢ŠÔ")] float _interval = 1f;
    [SerializeField]
    [Header("–¾‚é‚¢ŠÔ")] float _moonInterval = 3f;


    void Start()
    {
        _light = GetComponent<Light2D>();
    }

    void Update()
    {
        if (_light.intensity > _minus)//ˆÃ‚­‚·‚éˆ—
        {
            _light.intensity -= Time.deltaTime;
        }
        _time += Time.deltaTime;

        if (_time > _interval)//–¾‚é‚­‚·‚éˆ—
        {
            _intensityTime += Time.deltaTime;
            _light.intensity = _intensityTime;
            if (_intensityTime > _stop)//–¾‚é‚³‚ğˆÛ‚·‚éˆ—
            {
                _light.intensity = _intensity;
                StartCoroutine("Interval");
            }
        }
    }

    /// <summary>
    /// –¾‚é‚¢‚Ü‚ÜA‘Ò‚Âˆ—
    /// </summary>
    /// <returns></returns>
    private IEnumerator Interval()
    {
        yield return new WaitForSeconds(_moonInterval);
        _intensityTime = 0.2f;
        _time = 0f;
    }
}
