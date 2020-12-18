using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SignIn/Up画面の操作関連クラス
/// </summary>
public class SignInUpFocusMethod : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private InputField signInMailField;
    [SerializeField] private InputField signInPassField;
    [SerializeField] private InputField signUpNameField;
    [SerializeField] private InputField signUpMailField;
    [SerializeField] private InputField signUpPassField;
    [SerializeField] private InputField dummyField;     // フォーカス回避用ダミー
    /*----- クラスのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private SignInUpCanvasManager sc;

    /// <summary>
    /// InputFieldのフォーカス処理
    /// </summary>
    public void FocusInputField() {

        // キーボードでのフォーカス処理
        FocusByTab();
        FocusByDownArrow();
        FocusByUpArrow();
        // マウスでのフォーカス処理
    }
    /// <summary>
    /// キーボード操作でフォーカスを行う処理
    /// </summary>
    private void FocusByTab() {

        // Tabキーを押した時にフォーカス変更
        if (Input.GetKeyDown(KeyCode.Tab)) {

            // フォーカスを外す処理
            DeactiveSignInOut();

            // SignIn画面時
            if (sc.sState == SignInUpCanvasManager.SIGN_STATE.SIGN_IN) {

                switch (sc.actField) {

                    case SignInUpCanvasManager.ACTIVE_FIELD.NONE:
                        signInMailField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD:
                        signInPassField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD:
                        ///// ボタンの見た目を変更する処理 /////
                        // ボタンのフォーカスは出来ないけどそれっぽくしておく
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                        ///// 文章の見た目を変更する処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                        // メール入力フィールドに戻る
                        signInMailField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                        break;

                    default:
                        break;
                }
            }
            // SignUp画面時
            else {

                switch (sc.actField) {

                    case SignInUpCanvasManager.ACTIVE_FIELD.NONE:
                        signUpNameField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NAME_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.NAME_FIELD:
                        signUpMailField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD:
                        signUpPassField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD:
                        ///// ボタンの見た目を変更する処理 /////
                        // ボタンのフォーカスは出来ないけどそれっぽくしておく
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                        ///// 文章の見た目を変更する処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                        signUpMailField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NAME_FIELD;
                        break;

                    default:
                        break;
                }
            }
        }
    }
    /// <summary>
    /// ↓キーでのフォーカス変更処理
    /// </summary>
    private void FocusByDownArrow() {

        // Tabキーを押した時にフォーカス変更
        if (Input.GetKeyDown(KeyCode.DownArrow)) {

            // フォーカスを外す処理
            DeactiveSignInOut();

            // SignIn画面時
            if (sc.sState == SignInUpCanvasManager.SIGN_STATE.SIGN_IN) {

                switch (sc.actField) {

                    case SignInUpCanvasManager.ACTIVE_FIELD.NONE:
                        signInMailField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD:
                        signInPassField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD:
                        ///// ボタンの見た目を変更する処理 /////
                        // ボタンのフォーカスは出来ないけどそれっぽくしておく
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                        ///// 文章の見た目を変更する処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                        ///// 文章の見た目を変更する処理 /////
                        break;

                    default:
                        break;
                }
            }
            // SignUp画面時
            else {

                switch (sc.actField) {

                    case SignInUpCanvasManager.ACTIVE_FIELD.NONE:
                        signUpNameField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NAME_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.NAME_FIELD:
                        signUpMailField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD:
                        signUpPassField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD:
                        ///// ボタンの見た目を変更する処理 /////
                        // ボタンのフォーカスは出来ないけどそれっぽくしておく
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                        ///// 文章の見た目を変更する処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                        ///// 文章の見た目を変更する処理 /////
                        break;

                    default:
                        break;
                }
            }
        }
    }
    /// <summary>
    /// ↑キーでのフォーカス変更処理
    /// </summary>
    private void FocusByUpArrow() {

        // ↑キーを押した時にフォーカス変更
        if (Input.GetKeyDown(KeyCode.UpArrow)) {

            // フォーカスを外す処理
            DeactiveSignInOut();

            // SignIn画面時
            if (sc.sState == SignInUpCanvasManager.SIGN_STATE.SIGN_IN) {

                switch (sc.actField) {

                    case SignInUpCanvasManager.ACTIVE_FIELD.NONE:
                        ///// 文章の見た目を変更する処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD:
                        signInMailField.ActivateInputField();
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD:
                        signInMailField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                        signInPassField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                        ///// ボタンの見た目変更処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON;
                        break;

                    default:
                        break;
                }
            }
            // SignUp画面時
            else {

                switch (sc.actField) {

                    case SignInUpCanvasManager.ACTIVE_FIELD.NONE:
                        ///// 文章の見た目を変更する処理 /////
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD:
                        signUpNameField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.NAME_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD:
                        signUpMailField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.MAIL_FIELD;
                        ///// ボタンの見た目を変更する処理 /////
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON:
                        signUpPassField.ActivateInputField();
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.PASS_FIELD;
                        break;

                    case SignInUpCanvasManager.ACTIVE_FIELD.CHANGE_IN_UP:
                        // ボタンのフォーカスは出来ないけどそれっぽくしておく
                        sc.actField = SignInUpCanvasManager.ACTIVE_FIELD.SUBMIT_BUTTON;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 全てのinputFieldのフォーカスを外す処理
    /// </summary>
    private void DeactiveSignInOut() {

        signInMailField.DeactivateInputField();
        signInPassField.DeactivateInputField();
        signUpNameField.DeactivateInputField();
        signUpMailField.DeactivateInputField();
        signUpPassField.DeactivateInputField();
        dummyField.ActivateInputField();

        ///// ボタンと文章のフォーカス時の画像差し替えを戻す処理 /////
    }
}
