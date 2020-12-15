using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInUpCanvasManager : MonoBehaviour {

    [SerializeField] private SignInUpFocusMethod sf;
    [SerializeField] private OpenSignInUpMethod os;
    
    // SignInとSignUpのどちらの処理中かの判定
    public enum SIGN_STATE {

        SIGN_IN,
        SIGN_UP
    };
    public SIGN_STATE sState = SIGN_STATE.SIGN_IN;
    // 現在アクティブなフィールドの判定
    public enum ACTIVE_FIELD {

        MAIL_FIELD,
        NAME_FIELD,
        SUBMIT_BUTTON,
        CHANGE_IN_UP,
        NONE
    }
    public ACTIVE_FIELD actField = ACTIVE_FIELD.NONE;

    /// <summary>
    /// SignIn or SignUp時のフォームのフォーカス処理
    /// </summary>
    public void SignInUpFocus() {

        sf.FocusInputField();
    }
    /// <summary>
    /// SignIn/Up画面を開く処理
    /// </summary>
    public void OpenSignInUp() {

        if(sState == SIGN_STATE.SIGN_IN) {

            os.OpenSignIn();
        }
        else {

            os.OpenSignUp();
        }
    }
    /// <summary>
    /// SignIn/Up画面を開く処理
    /// </summary>
    /// <param name="inup">SignIn/Up表示判定(trueでSignIn)</param>
    public void OpenSignInUp(bool inup) {

        if(inup) {

            os.OpenSignIn();
        }
        else {

            os.OpenSignUp();
        }
    }
    /// <summary>
    /// SignIn/Up画面を閉じる処理
    /// </summary>
    public void CloseSignInUp() {

        os.CloseSignInUp();
    }
}
