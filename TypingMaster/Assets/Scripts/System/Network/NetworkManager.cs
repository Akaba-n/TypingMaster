using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

/// <summary>
/// サーバ通信管理クラス
/// </summary>
public class NetworkManager : AppDefine {

    // 子クラスのインスタンス(Inspectorで設定)
    [SerializeField] private HttpGet httpGet;
    [SerializeField] private HttpPost httpPost;

    // 接続状況管理変数
    public bool ConnectionStatus = false;

    private void Start() {
    }
    
    /// <summary>
    /// HTTPにPOST接続を行うメソッド
    /// </summary>
    /// <param name="URL">接続先URL</param>
    /// <param name="dic">送信するデータ</param>
    public void PostRequest(string URL, Dictionary<string, string> dic) {

        StartCoroutine(httpPost.PostRequest(URL, dic));
    }

    /// <summary>
    /// HTTPにGET接続を行うメソッド(データあり)
    /// </summary>
    /// <param name="URL">接続先URL</param>
    /// <param name="dic">送信するデータ</param>
    public void GetRequest(string URL, Dictionary<string, string> dic) {

        StartCoroutine(httpGet.GetRequest(URL, dic));
    }

    /// <summary>
    /// HTTPにGET接続を行うメソッド(データなし)
    /// </summary>
    /// <param name="URL">接続先URL</param>
    public void GetRequest(string URL) {

        StartCoroutine(httpGet.GetRequest(URL));
    }

    /// <summary>
    /// サーバ接続状況確認(同一フレーム内で行うので接続に時間がかかる場合もあるかも)
    /// </summary>
    public bool judgeConnecting() {

        // 接続先URL
        var url = ServerUrl.ENEMY_SYNC_URL;
        // URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        // URLに接続して結果が戻ってくるまで待機
        webRequest.SendWebRequest();

        // エラーチェック
        if (webRequest.isNetworkError) {

            // 通信失敗時処理
            Debug.Log(webRequest.error);
            ConnectionStatus = false;
            return false;
        }
        else {

            // 通信成功時処理
            Debug.Log("ServerConnection：Success!!");
            ConnectionStatus = true;
            return true;
        }
    }
}
