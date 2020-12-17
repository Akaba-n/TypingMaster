﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TitleSceneのUI管理クラス
/// </summary>
public class TitleUIManager : MonoBehaviour {

    [SerializeField] private SignInUpCanvasManager sc;

    /*---------- SignIn/Up画面関連処理 ----------*/
    /// <summary>
    /// SignIn or SignUp画面でのフォームのフォーカス処理
    /// </summary>
    public void SignInUpFocus() {

        sc.SignInUpFocus();
    }
    public void OpenSignInUp() {

        sc.OpenSignInUp();
    }
    /// <summary>
    /// SignIn/Up画面のクローズ処理
    /// </summary>
    public void CloseSignInUp() {

        sc.CloseSignInUp();
    }
}
