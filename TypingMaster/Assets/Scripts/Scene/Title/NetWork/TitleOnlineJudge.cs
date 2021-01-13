using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

/// <summary>
/// サーバ接続確認クラス
/// </summary>
public class TitleOnlineJudge : MonoBehaviour {

    public bool isOnline;
    
    /// <summary>
    /// サーバ接続可否確認処理のコルーチン
    /// </summary>
    public IEnumerator OnlineJudge() {

        // 接続先URL
        var url = ServerUrl.JUDGE_CONECTION_URL;
        // URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        // エラーチェック
        if(webRequest.isNetworkError || webRequest.isHttpError) {

            // 通信失敗時処理
            Debug.Log("Server：OFFLINE");
            isOnline = false;
            PlayerPrefs.SetInt(PlayerPrefsKey.ONLINE_JUDGE, 0);
        }
        else {

            // 通信成功時処理
            Debug.Log("Server：ONLINE");
            isOnline = true;
            PlayerPrefs.SetInt(PlayerPrefsKey.ONLINE_JUDGE, 1);
        }
    }
}
