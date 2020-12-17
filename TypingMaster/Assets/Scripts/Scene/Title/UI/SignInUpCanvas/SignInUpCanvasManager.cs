using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInUpCanvasManager : MonoBehaviour {

    [SerializeField] private SignInUpFocusMethod sf;
    [SerializeField] private OpenSignInUpMethod os;
    
    // SignInとSignUpのどちらの処理中かの判定
    public enum SIGN_STATE {

        SIGN_UP,
        SIGN_IN
    };
    public SIGN_STATE sState;
    // 現在アクティブなフィールドの判定
    public enum ACTIVE_FIELD {

        NONE,
        MAIL_FIELD,
        NAME_FIELD,
        PASS_FIELD,
        SUBMIT_BUTTON,
        CHANGE_IN_UP
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

        if(sState == SIGN_STATE.SIGN_UP) {

            sState = SIGN_STATE.SIGN_IN;
            os.OpenSignIn();
        }
        else {

            sState = SIGN_STATE.SIGN_UP;
            os.OpenSignUp();
        }
    }
    /// <summary>
    /// SignIn/Up画面を閉じる処理
    /// </summary>
    public void CloseSignInUp() {

        os.CloseSignInUp();
        sState = SIGN_STATE.SIGN_UP;
    }
}
