using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

public class ServerMkFriendRoom : MonoBehaviour {

    [SerializeField] private MenuMain mm;

    /// <summary>
    /// サーバ接続を行い部屋を建てる処理
    /// </summary>
    /// <returns></returns>
    public IEnumerator MkFriendRoom() {

        // キー入力を無効化する
        mm.isInputValid = false;

        // 送信する情報を作成
        var playerId = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000");
        var playerName = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "none");
        Debug.Log("playerId:" + playerId + ", playerName:" + playerName);
        // 接続先URL
        var url = ServerUrl.MAKE_FRIENDROOM_URL + "?playerId=" + playerId + "&playerNeme=" + playerName;
        // URLをPOSTで用意
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();

        // エラーチェック
        if(webRequest.isNetworkError || webRequest.isHttpError) {

            // 通信失敗時処理
            Debug.Log(webRequest.error);
            PlayerPrefs.SetInt(PlayerPrefsKey.ONLINE_JUDGE, 0);
            // キー入力有効化
            mm.isInputValid = true;
        }
        else {

            // 通信成功時処理
            Debug.Log("部屋建て成功");
            // roomIDが返ってくるので格納
            var dlStr = webRequest.downloadHandler.text;
            PlayerPrefs.SetString(PlayerPrefsKey.ROOM_ID, dlStr);
            // ホストなのでUserNumは1にする
            PlayerPrefs.SetInt(PlayerPrefsKey.USER_NUM, 1);
            Debug.Log(PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "none"));
            // キー入力有効化
            mm.isInputValid = true;
            // Scene切り替えに移行
            mm.status = MenuMain.SCENE_STATE.CHANGE_WAIT;
        }
    }
}
