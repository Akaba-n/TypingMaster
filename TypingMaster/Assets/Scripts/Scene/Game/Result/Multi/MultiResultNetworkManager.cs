using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using UnityEngine.Networking;

public class MultiResultNetworkManager : MonoBehaviour {

    [SerializeField] private MultiResultManager rm;
    [SerializeField] private DownloadEnemyTypingData dletd;
    [SerializeField] private UploadPlayerTypingData ulptd;
    [SerializeField] private MultiPlayerTypingDataManager ptd;
    [SerializeField] private MultiMain mm;

    /// <summary>
    /// MultiシーンでのResult画面でのネットワーク処理
    /// </summary>
    public void ResultNetwork() {

        if (rm.rState == MultiResultManager.RESUTL_STATE.SELECT_WAIT || rm.rState == MultiResultManager.RESUTL_STATE.RETRY_SELECT || rm.rState == MultiResultManager.RESUTL_STATE.ENEMY_WAIT) {

            // 対戦相手のデータ取得
            StartCoroutine(DownloadEnemyData());
        }

        if (rm.rState == MultiResultManager.RESUTL_STATE.ENEMY_WAIT) {

            // 自分のリトライ判定送信
            StartCoroutine(UploadPlayerDate());
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
    /// Playerのデータ送信(リトライ判定用)
    /// </summary>
    /// <returns></returns>
    public IEnumerator UploadPlayerDate() {

        yield return StartCoroutine(ulptd.UploadPTD(PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 0), PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000")));
    }
    /// <summary>
    /// Playerのデータ送信(リトライしない時用)
    /// </summary>
    /// <returns></returns>
    public IEnumerator UploadRetryData() {

        var userNum = PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 0);
        var roomId = PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000");

        // 送信データの作成
        var sendJson = ptd.TypingDataToJson();
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(sendJson); // byte型配列に変換

        // 接続先URL
        var url = ServerUrl.PLAYER_TYPINGDATA_URL + "?userNum=" + userNum.ToString() + "&roomId=" + roomId;
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

            // ModeSceneへ遷移
            mm.nextScene = "MenuScene";
            mm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
        }
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
        var url = ServerUrl.PLAYERDATA_INIT_URL + "?roomId=" + roomId + "&playerNum=" + playerNum.ToString() + "&playerId=" + playerId + "&playerName=" + playerName;
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
        }
        else {

            // 通信成功時処理
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
}
