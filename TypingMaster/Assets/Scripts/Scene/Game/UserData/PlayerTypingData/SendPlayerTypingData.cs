using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendPlayerTypingData : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private PlayerTypingDataManager ptd;
    /*----- オブジェクトのインスタンス化 -----*/
    //private ServerUrl sUrl = new ServerUrl();

    /// <summary>
    /// UnityWebRequestでサーバにPlayerのデータを送信格納
    /// </summary>
    /// <param name="userId">PlayerのuserId</param>
    /// <param name="roomId">所属しているroomId</param>
    /// <returns></returns>
    public IEnumerator SendPTD(string userId, string roomId) {

        // 接続先URL
        var url = ServerUrl.BASE_URL+ServerUrl.PLAYER_SYNC_URL+"?userId="+userId+"&roomId="+roomId;
        // URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        // URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        // エラーチェック
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
