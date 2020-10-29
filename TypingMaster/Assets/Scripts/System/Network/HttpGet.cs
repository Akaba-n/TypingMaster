using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GETリクエストを行うコルーチンのクラス
/// </summary>
public class HttpGet : MonoBehaviour {

    [SerializeField] private ServerTimeOut serverTimeOut;
    
    /// <summary>
    /// HTTPにGET接続するコルーチン
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <param name="data">送信するデータ</param>
    /// <returns>GET通信処理</returns>
    public IEnumerator GetRequest(string url, Dictionary<string, string> data) {

        string get_param = "?"; // 送信データ
        int dCount = 0;

        // 送信データこねこね
        foreach (KeyValuePair<string, string> d in data) {

            if(dCount > 0) {

                get_param += "&";
            }
            get_param += d.Key + "=" + d.Value;
            dCount++;
        }

        // 接続先確立
        WWW www = new WWW(url + get_param);

        // CheckTimeOut()の終了を待つ。5秒過ぎたらタイムアウト
        yield return StartCoroutine(serverTimeOut.CheckTimeOut(www));

        if (www.error != null) {    // 通信エラー時

            Debug.Log("GETError : " + www.error);
        }
        else if (www.isDone) {      // 通信完了時

            // サーバからのレスポンスを表示
            Debug.Log("GETSuccess : " + www.text);
        }
    }

    /// <summary>
    /// HTTPにGET接続(空)するコルーチン
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <returns>GET通信処理</returns>
    public IEnumerator GetRequest(string url) {

        // 接続先確立
        WWW www = new WWW(url);

        // CheckTimeOut()の終了を待つ。5秒過ぎたらタイムアウト
        yield return StartCoroutine(serverTimeOut.CheckTimeOut(www));

        if (www.error != null) {    // 通信エラー時

            Debug.Log("GETError : " + www.error);
        }
        else if (www.isDone) {      // 通信完了時

            // サーバからのレスポンスを表示
            Debug.Log("GETSuccess : " + www.text);
        }
    }
}
