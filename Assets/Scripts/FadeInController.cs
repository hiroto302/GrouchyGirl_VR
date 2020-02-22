﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeInController : MonoBehaviour
{
    float fadeSpeed = 0.0025f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeIn = false;  //フェードアウト処理の開始、完了を管理するフラグ

    Image fadeImage;                //透明度を変更するパネルのイメージ

    void Start () {
        fadeImage = GetComponent<Image> ();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        isFadeIn = true;
    }

    void Update ()
    {
        if (isFadeIn)
        {
            StartFadeIn ();
        }
    }

    void StartFadeIn()
    {
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alfa -= fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha ();               // c)変更した透明度をパネルに反映する
        if(alfa <= 0)              // d)完全に不透明になったら処理を抜ける
        {
            isFadeIn = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

}
