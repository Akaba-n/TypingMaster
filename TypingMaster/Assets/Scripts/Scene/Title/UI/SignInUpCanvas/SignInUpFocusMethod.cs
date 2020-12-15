using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SignIn/Up画面の操作関連クラス
/// </summary>
public class SignInUpFocusMethod : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private InputField signInNameField;
    [SerializeField] private InputField signInMailField;
    [SerializeField] private InputField signUpNameField;
    [SerializeField] private InputField signUpMailField;
    /*----- クラスのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private SignInUpCanvasManager sc;

    /// <summary>
    /// InputFieldのフォーカス処理
    /// </summary>
    public void FocusInputField() {

        // Tabキーを押した時にフォーカス
        if (Input.GetKeyDown(KeyCode.Tab)) {

            // フォーカスの初期化
            DeactiveSignInOut();

            switch (sc.actField) {

                case SignInUpCanvasManager.ACTIVE_FIELD.NONE:
                    // ユーザー名の入力フィールドをフォーカス
                    if (sc.sState == SignInUpCanvasManager.SIGN_STATE.SIGN_IN) {

                        signInNameField.ActivateInputField();
                    }
                    else {

                        signUpNameField.ActivateInputField();
                    }
                    sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NAME_FIELD;
                    break;

                case SignInUpCanvasManager.ACTIVE_FIELD.NAME_FIELD:
                    // メールアドレスの入力フィールドをフォーカス
                    if (sc.sState == SignInUpCanvasManager.SIGN_STATE.SIGN_IN) {

                        signInMailField.ActivateInputField();
                    }
                    else {

                        signUpMailField.ActivateInputField();
                    }
                    sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                    break;

                case SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD:
                    ///// ボタンの見た目を選択時の物にする処理 /////
                    // ボタンのフォーカスは出来ないけどそれっぽい事しておく

                    sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON;
                    break;

                case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                    // SignInとSignOut切り替えボタン(文字列？)
                    sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP;
                    break;

                case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                    sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NONE;
                    break;
            }
        }
    }
    /// <summary>
    /// 全てのinputFieldのフォーカスを外す処理
    /// </summary>
    private void DeactiveSignInOut() {

        signInNameField.DeactivateInputField();
        signInMailField.DeactivateInputField();
        signUpNameField.DeactivateInputField();
        signUpMailField.DeactivateInputField();
    }
}
