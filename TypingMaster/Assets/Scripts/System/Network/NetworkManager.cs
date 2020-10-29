using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// サーバ通信管理クラス
/// </summary>
public class NetworkManager : AppDefine {

    // 接続先のURL
    private const string URL = "http://ec2-18-181-251-215.ap-northeast-1.compute.amazonaws.com";
    //private const string URL = "http://zipcloud.ibsnet.co.jp/api/search?zipcode=7830060";

    /// <summary>
    /// HTTPにGET接続するコルーチン
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <returns>GET通信処理</returns>
    IEnumerator GETSend(string url) {

        // URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        // URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        // エラーが出ていないかチェック
        if (webRequest.isNetworkError) {

            // 通信失敗時処理
            Debug.Log(webRequest.error);
        }
        else {

            // 通信成功時処理
            Debug.Log(webRequest.downloadHandler.text);
        }
    }

    /// <summary>
    /// HTTPにPOST接続するコルーチン
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <returns>POST通信処理</returns>
    IEnumerator POSTSend(string url) {

        WWWForm form = new WWWForm();
        form.AddField("zipcode", 1000001);

        // URLをPOSTで用意
        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
        // UnityWebRequestにバッファをセット
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        // URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        // エラーが出ていないかチェック
        if (webRequest.isNetworkError) {

            // 通信失敗時処理
            Debug.Log(webRequest.error);
        }
        else {

            // 通信成功時処理
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
}
