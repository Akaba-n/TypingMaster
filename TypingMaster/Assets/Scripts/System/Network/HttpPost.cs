using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// POSTリクエストを行うコルーチンのクラス
/// </summary>
public class HttpPost : MonoBehaviour {

    [SerializeField] private ServerTimeOut serverTimeOut;

    /// <summary>
    /// HTTPにPOST接続するコルーチン
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <param name="data">送信するデータ</param>
    /// <returns>POST通信処理</returns>
    public IEnumerator PostRequest(string url, Dictionary<string, string> data) {

        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in data) {

            form.AddField(post_arg.Key, post_arg.Value);
        }

        WWW www = new WWW(url, form);

        // CheckTimeOut()の終了を待つ。5秒を過ぎたらタイムアウト
        yield return StartCoroutine(serverTimeOut.CheckTimeOut(www));

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
}
