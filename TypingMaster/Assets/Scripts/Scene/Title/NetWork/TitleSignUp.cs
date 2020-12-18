using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

public class TitleSignUp : MonoBehaviour {

    [SerializeField] private PlayerData pd;
    [SerializeField] private SignInUpCanvasManager sc;
    [SerializeField] private TitleMain tm;

    /// <summary>
    /// SignUp処理のコルーチン
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="email"></param>
    /// <param name="pass"></param>
    /// <returns></returns>
    public IEnumerator SignUp(string userName, string email, string pass) {
            
        // 接続先URL
        var url = ServerUrl.SIGNUP_URL + "?userName=" + userName + "&email=" + email + "&pass=" + pass;

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
            // 既に登録済みのメールアドレスだった場合の処理
            if (webRequest.downloadHandler.text == "") {

                // SignIn画面に文字表示
                Debug.Log("このメールアドレスは既に登録済みです");
                tm.tState = TitleMain.TITLE_STATE.SIGNIN_UP;
            }
            // SignIn成功時
            else {

                // ユーザー情報再格納
                var jsonstr = webRequest.downloadHandler.text;
                pd.pd = JsonUtility.FromJson<PlayerData.PlayerDataTemp>(jsonstr);
                PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_ID, pd.pd.playerId);
                PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_NAME, pd.pd.playerName);
                PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_MAIL, pd.pd.email);
                PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_PASS, pd.pd.pass);
                Debug.Log("SignUp成功");

                //tm.tState = TitleMain.TITLE_STATE.ONLINE_SECTION;
                tm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
            }
        }
    }
}
