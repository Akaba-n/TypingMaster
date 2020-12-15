using System.Collections;
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
    /// <summary>
    /// SignIn/Up画面のオープン処理
    /// </summary>
    /// <param name="inup">In or Up 選択(true：in, false：up)</param>
    public void OpenSignInUp(bool inup = true) {

        sc.OpenSignInUp(inup);
    }
    /// <summary>
    /// SignIn/Up画面のクローズ処理
    /// </summary>
    public void CloseSignInUp() {

        sc.CloseSignInUp();
    }
}
