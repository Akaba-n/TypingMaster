using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

/// <summary>
/// TitleSceneでのサーバ通信処理管理クラス
/// </summary>
public class TitleNetworkManager : MonoBehaviour {

    [SerializeField] private TitleOnlineJudge toj;
    [SerializeField] private TitleSignIn tsi;
    [SerializeField] private TitleSignUp tsu;
    [SerializeField] private TitleMain tm;

    /// <summary>
    /// サーバ接続確認コルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator OnlineJudge() {

        // 通信開始時処理(TItle画面で通信中動かさないで良い)
        var temp = tm.tState;
        tm.tState = TitleMain.TITLE_STATE.CONNECTING;
        // サーバ接続確認
        yield return toj.OnlineJudge();
        // オンライン時
        if (toj.isOnline) {

            tm.tState = TitleMain.TITLE_STATE.ONLINE_SECTION;
        }
        // オフライン時
        else {

            tm.tState = TitleMain.TITLE_STATE.OFFLINE_SECTION;
        }
    }

    /// <summary>
    /// SignIn処理コルーチン
    /// </summary>
    /// <param name="userId">userId</param>
    /// <param name="userName">userName</param>
    /// <param name="email">email</param>
    /// <param name="pass">pass</param>
    /// <returns></returns>
    public IEnumerator SignIn(string userId, string userName, string email, string pass) {

        // 通信開始時処理(TItle画面で通信中動かさないで良い)
        var temp = tm.tState;
        tm.tState = TitleMain.TITLE_STATE.CONNECTING;
        // SignIn処理
        yield return StartCoroutine(tsi.SignIn(userId, userName, email, pass));
    }

    public IEnumerator SignUp(string userName, string email, string pass) {

        // 通信開始時処理(TItle画面で通信中動かさないで良い)
        var temp = tm.tState;
        tm.tState = TitleMain.TITLE_STATE.CONNECTING;
        // SignIn処理
        yield return StartCoroutine(tsu.SignUp(userName, email, pass));
    }
}
