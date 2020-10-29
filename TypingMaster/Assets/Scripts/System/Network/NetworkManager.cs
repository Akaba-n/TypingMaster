using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// サーバ通信管理クラス
/// </summary>
public class NetworkManager : AppDefine {

    // 接続先のURL
    private const string URL = "http://ec2-18-181-251-215.ap-northeast-1.compute.amazonaws.com/test/test.php";
    //private const string URL = "http://zipcloud.ibsnet.co.jp/api/search?zipcode=7830060";
    // サーバへリクエストするデータ
    string userId = "0";
    string userName = "waka";
    string userData = "abc";

    // タイムアウト時間
    float timeoutsec = 5f;

    private void Start() {

        // サーバ送信データこねこね
        // POST
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("id", userId);
        dic.Add("name", userName);
        dic.Add("data", userData);
        StartCoroutine(POSTSend(URL, dic));     // POST送信

        // GET
        string get_param = "?id=" + userId + "&name=" + userName + "&data=" + userData;
        StartCoroutine(GETSend(URL + get_param));
    }

    /// <summary>
    /// HTTPにGET接続するコルーチン
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <returns>GET通信処理</returns>
    IEnumerator GETSend(string url) {

        WWW www = new WWW(url);

        // CheckTimeOut()の終了を待つ。5秒過ぎたらタイムアウト
        yield return StartCoroutine(CheckTimeOut(www, timeoutsec));

        if (www.error != null) {

            Debug.Log("GETError : " + www.error);
        }
        else if (www.isDone) {

            // サーバからのレスポンスを表示
            Debug.Log("GETSuccess : " + www.text);
        }
    }

    /// <summary>
    /// HTTPにPOST接続するコルーチン
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <returns>POST通信処理</returns>
    IEnumerator POSTSend(string url, Dictionary<string, string> post) {

        WWWForm form = new WWWForm();
        foreach(KeyValuePair<string, string> post_arg in post) {

            form.AddField(post_arg.Key, post_arg.Value);
        }

        WWW www = new WWW(url, form);

        // CheckTimeOut()の終了を待つ。5秒を過ぎたらタイムアウト
        yield return StartCoroutine(CheckTimeOut(www, timeoutsec));

        // エラーが出ていないかチェック
        if (www.error != null) {

            // 通信失敗時処理
            Debug.Log("POSTError : " + www.error);
        }
        else if (www.isDone) {

            // 通信成功時処理
            Debug.Log("POSTSuccess : " + www.text);
        }
    }

    IEnumerator CheckTimeOut(WWW www, float timeout) {

        // 要求時の時間の取得
        float requestTime = Time.time;

        while (!www.isDone) {   // 通信完了まで

            if (Time.time - requestTime < timeout) {    // 時間計測

                yield return null;
            }
            else {

                Debug.Log("TimeOut");   // タイムアウト
                break;
            }
        }

        yield return null;
    }
}
