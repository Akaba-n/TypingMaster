using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

public class TitleSignIn : MonoBehaviour {

    [SerializeField] private PlayerData pd;
    [SerializeField] private SignInUpCanvasManager sc;
    [SerializeField] private TitleMain tm;

    public IEnumerator SignIn(string userId, string userName, string email, string pass) {
        
        // 接続先URL
        var url = ServerUrl.SIGNIN_URL + "?userId=" + userId + "&userName=" + userName + "&email=" + email + "&pass=" + pass;

        // URLをPOSTで用意
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        // URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        // エラーチェック
        if (webRequest.isNetworkError || webRequest.isHttpError) {

            // 通信失敗時処理
            Debug.Log(webRequest.error);
            tm.tState = TitleMain.TITLE_STATE.OFFLINE_SECTION;
        }
        // 通信成功時処理
        else {

            Debug.Log(webRequest.downloadHandler.text);
            // データベース不一致時
            if (webRequest.downloadHandler.text == "") {

                // SignIn画面に文字表示
                if (PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000") == "00000000") {

                    Debug.Log("SignIn失敗");
                }
                // データベース上の情報と整合性が取れなかった場合
                else {

                    Debug.Log("ユーザーデータ整合性無し");
                    // ユーザーデータ初期化
                    PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_ID, "00000000");
                    PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_NAME, "GUEST");
                    PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_MAIL, "");
                    PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_PASS, "");
                    // SignInし直し
                    sc.OpenSignInUp();
                }
                tm.tState = TitleMain.TITLE_STATE.SIGNIN_UP;
            }
            // SignIn成功時
            else {

                // ユーザー情報再格納
                Debug.Log(webRequest.downloadHandler.text);
                var jsonstr = webRequest.downloadHandler.text;
                Debug.Log(jsonstr);

                ///// ここでミスが起きてるので直す必要あり /////
                pd.pd = JsonUtility.FromJson<PlayerData.PlayerDataTemp>(jsonstr);
                PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_ID, pd.pd.userId);
                PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_NAME, pd.pd.userName);
                PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_MAIL, pd.pd.email);
                PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_PASS, pd.pd.pass);
                Debug.Log("SignIn成功");
                Debug.Log("PlayerId:" + PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000") + ", PlayerName:" + PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "none"));

                //tm.tState = TitleMain.TITLE_STATE.ONLINE_SECTION;
                tm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
            }
        }
    }
}
