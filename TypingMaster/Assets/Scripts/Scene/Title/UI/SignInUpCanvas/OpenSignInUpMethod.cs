using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSignInUpMethod : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private GameObject signInPanel;
    [SerializeField] private GameObject signUpPanel;

    /// <summary>
    /// サインインメニューを開く処理
    /// </summary>
    public void OpenSignIn() {

        signInPanel.SetActive(true);
        signUpPanel.SetActive(false);
    }
    /// <summary>
    /// サインアップメニューを開く処理
    /// </summary>
    public void OpenSignUp() {

        signInPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }
}
