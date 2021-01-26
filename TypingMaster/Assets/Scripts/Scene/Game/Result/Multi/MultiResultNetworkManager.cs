using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using UnityEngine.Networking;

public class MultiResultNetworkManager : MonoBehaviour {

    [SerializeField] private MultiResultManager rm;
    [SerializeField] private DownloadEnemyTypingData dletd;

    /// <summary>
    /// MultiシーンでのResult画面でのネットワーク処理
    /// </summary>
    public void ResultNetwork() {

        if (rm.rState == MultiResultManager.RESUTL_STATE.SELECT_WAIT || rm.rState == MultiResultManager.RESUTL_STATE.RETRY_SELECT || rm.rState == MultiResultManager.RESUTL_STATE.ENEMY_WAIT) {

            // 対戦相手のデータ取得
            StartCoroutine(DownloadEnemyData());
        }
    }

    /// <summary>
    /// 対戦相手のデータ取得(リトライ判定用)
    /// </summary>
    public IEnumerator DownloadEnemyData() {

        // 対戦相手のデータ取得
        yield return StartCoroutine(dletd.DownloadETD(PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 1), PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000")));


    }

    /// <summary>
    /// 連戦時サーバにおいてあるゲームデータの初期化処理
    /// </summary>
    /// <returns></returns>
    public IEnumerator UploadInitData() {

        var roomId = PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000");
        var playerNum = PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 0);
        var playerId = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000");
        var playerName = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "none");
        // 接続先URL
        var url = ServerUrl.PLAYERDATA_INIT_URL + "?roomId=" + roomId + "&playerNum=" + playerNum + "&playerId=" + playerId + "&playerName=" + playerName;
        // URLをPOSTで用意
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        // URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        // エラーチェック
        if (webRequest.isNetworkError || webRequest.isHttpError) {

            // 通信失敗時処理
            Debug.Log(webRequest.error);
        }
        else {

            // 通信成功時処理
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
}
