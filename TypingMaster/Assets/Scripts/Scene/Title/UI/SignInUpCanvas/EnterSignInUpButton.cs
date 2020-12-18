using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

/// <summary>
/// ボタンのクリック時動作クラス
/// </summary>
public class EnterSignInUpButton : MonoBehaviour {

    // 各種スクリプト/オブジェクトの取得(Inspectorで設定)
    [SerializeField] private TitleMain tm;
    [SerializeField] private TitleNetworkManager tNM;
    [SerializeField] private SignInUpCanvasManager sc;
    [SerializeField] private InputField signInUserMail;
    [SerializeField] private InputField signInUserPass;
    [SerializeField] private InputField signUpUserName;
    [SerializeField] private InputField signUpUserMail;
    [SerializeField] private InputField signUpUserPass;

    /// <summary>
    /// Enterキー押下時の処理
    /// </summary>
    public void PushButtonByEnter() {

        if (Input.GetKeyDown(KeyCode.Return)) {

            if (sc.sState == SignInUpCanvasManager.SIGN_STATE.SIGN_IN) {

                switch (sc.actField) {

                    case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                        ///// SignIn処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NONE;
                        StartCoroutine(EnterSignInButton());
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                        ///// SignIn/Up切り替え処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NONE;
                        sc.OpenSignInUp();
                        break;

                    default:
                        break;
                }
            }
            // SignUp画面時
            else {

                switch (sc.actField) {

                    case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                        ///// SignUp処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NONE;
                        StartCoroutine(EnterSignUpButton());
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                        ///// SignIn/Up切り替え処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NONE;
                        sc.OpenSignInUp();
                        break;

                    default:
                        break;
                }
            }
        }
    }
    
    /// <summary>
    /// SignInボタン押下時の処理
    /// </summary>
    public IEnumerator EnterSignInButton() {
        
        // 通信中処理へ飛ばす
        tm.tState = TitleMain.TITLE_STATE.CONNECTING;
        // SignIn処理
        yield return StartCoroutine(tNM.SignIn("00000000", "GUEST", signInUserMail.text, signInUserPass.text));
    }
    /// <summary>
    /// SignUpボタン押下時の処理
    /// </summary>
    public IEnumerator EnterSignUpButton() {

        // 通信中処理へ飛ばす
        tm.tState = TitleMain.TITLE_STATE.CONNECTING;
        // SignIn処理
        yield return StartCoroutine(tNM.SignUp(signUpUserName.text, signUpUserMail.text, signUpUserPass.text));
    }
}
