using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

public class PlayerConnectJudge : MonoBehaviour {
    
    /// <summary>
    /// 自身のサーバ接続状況(時間)を更新する処理
    /// </summary>
    /// <param name="userNum">PlayerのPlayerNum(1 or 2)</param>
    /// <param name="roomId">Room番号</param>
    /// <returns></returns>
    public IEnumerator ServerPlayerConnectJudge(int userNum, string roomId, string userId) {

        // 接続先URL
        var url = ServerUrl.PLAYER_CONNECT_JUDGE_URL + "?userNum=" + userNum.ToString() + "&roomId=" + roomId + "&userId=" + userId;
        // URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        // URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        // エラーチェック
        if (webRequest.isNetworkError || webRequest.isHttpError) {

            // 通信失敗時処理
            Debug.Log(webRequest.error);
        }
        else {

            // 通信成功時処理
            //Debug.Log(webRequest.downloadHandler.text);
        }
    }
}
