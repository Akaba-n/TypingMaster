using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInUpFocusMethod : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private InputField signInNameField;
    [SerializeField] private InputField signInMailField;
    [SerializeField] private Button signInSubmitButton;
    [SerializeField] private InputField signUpNameField;
    [SerializeField] private InputField signUpMailField;
    /*----- クラスのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private SignInCanvasManager sc;

    /// <summary>
    /// InputFieldのフォーカス処理
    /// </summary>
    public void FocusInputField() {

        // Tabキーを押した時にフォーカス
        if (Input.GetKeyDown(KeyCode.Tab)) {
            
            switch (sc.actField) {

                case SignInCanvasManager.ACTIVE_FIELD.NONE:
                    // ユーザー名の入力フィールドをフォーカス
                    if (sc.sState == SignInCanvasManager.SIGN_STATE.SIGN_IN) {

                        signInNameField.ActivateInputField();
                    }
                    else {

                        signUpNameField.ActivateInputField();
                    }
                    sc.actField = SignInCanvasManager.ACTIVE_FIELD.NAME_FIELD;
                    break;

                case SignInCanvasManager.ACTIVE_FIELD.NAME_FIELD:
                    // メールアドレスの入力フィールドをフォーカス
                    if (sc.sState == SignInCanvasManager.SIGN_STATE.SIGN_IN) {

                        signInMailField.ActivateInputField();
                    }
                    else {

                        signUpMailField.ActivateInputField();
                    }
                    sc.actField = SignInCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                    break;

                case SignInCanvasManager.ACTIVE_FIELD.MAIL_FIELD:
                    // ボタンのフォーカスは出来ないけどそれっぽい事しておく
                    ///// ボタンの見た目を選択時の物にする処理 /////
                    sc.actField = SignInCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON;
                    break;

                case SignInCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                    // SignInとSignOut切り替えボタン(文字列？)
                    sc.actField = SignInCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP;
                    break;
            }
        }
    }
}
