﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("フェードさせるUI")]
    [SerializeField] private Image _fadePanel;
    [Tooltip("実行時間")]
    [SerializeField] private float _fadeTime = 1f;

    private void Start()
    {
        StartFadeIn();
    }

    public void StartFadeIn(Action action = null)
    {
        StartCoroutine(FadeIn(action));
    }

    public void StartFadeOut(Action action = null)
    {
        StartCoroutine(FadeOut(action));
    }

    private IEnumerator FadeIn(Action action = null)
    {
        _fadePanel.gameObject.SetActive(true);

        //α値(透明度)を 1 -> 0 にする(少しずつ明るくする)
        float alpha = 1f;
        Color color = _fadePanel.color;

        do
        {
            alpha -= Time.deltaTime * (1f / _fadeTime);
            if (alpha <= 0f)
            {
                alpha = 0f;
            }
            color.a = alpha;
            _fadePanel.color = color;
            yield return null;
        }
        while (alpha > 0f);

        _fadePanel.gameObject.SetActive(false);
        //フェード後に実行する関数
        action?.Invoke();
    }

    private IEnumerator FadeOut(Action action = null)
    {
        _fadePanel.gameObject.SetActive(true);

        //α値(透明度)を 0 -> 1 にする(少しずつ暗くする)
        float alpha = 0f;
        Color color = _fadePanel.color;

        do
        {
            alpha += Time.deltaTime * (1f / _fadeTime);
            if (alpha >= 1f)
            {
                alpha = 1f;
            }
            color.a = alpha;
            _fadePanel.color = color;
            yield return null;
        }
        while (alpha < 1f);

        //フェード後に実行する関数
        action?.Invoke();
    }
}