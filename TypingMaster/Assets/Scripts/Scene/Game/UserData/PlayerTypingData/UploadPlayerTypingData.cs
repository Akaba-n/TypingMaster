using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// プレイヤーのタイピングデータを送信格納するクラス
/// </summary>
public class UploadPlayerTypingData : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private PlayerTypingDataManager ptd;
    /*----- オブジェクトのインスタンス化 -----*/
    //private ServerUrl sUrl = new ServerUrl();

    /* putが更新らしいけどよく分からんのでpostでやる
    /// <summary>
    /// UnityWebRequestでサーバにPlayerのデータをHttp/Putで送信格納
    /// </summary>
    /// <param name="userId">PlayerのuserId</param>
    /// <param name="roomId">所属しているroomId</param>
    /// <returns></returns>
    public IEnumerator UploadPTD(string userId, string roomId) {
        
        // 送信データの作成
        var sendJson = ptd.TypingDataToJson();
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(sendJson); // byte型配列に変換

        // 接続先URL
        var url = ServerUrl.PLAYER_TYPINGDATA_URL + roomId + "/" + userId;
        // URLをPOSTで用意
        using(UnityWebRequest webRequest = UnityWebRequest.Put(url, postData)) {
            // URLに接続して結果が戻ってくるまで待機
            yield return webRequest.SendWebRequest();

            // エラーチェック
            if (webRequest.isNetworkError || webRequest.isHttpError) {

                // 通信失敗時処理
                Debug.Log(webRequest.error);
            }
            else {

                // 通信成功時処理
                Debug.Log("UploadComplete!!");
            }
        }
    }*/

    /// <summary>
    /// UnityWebRequestでサーバにPlayerのデータをHttp/Postで送信格納
    /// </summary>
    /// <param name="userId">PlayerのuserId</param>
    /// <param name="roomId">所属しているroomId</param>
    /// <returns></returns>
    public IEnumerator UploadPTD(string userId, string roomId) {
        
        // 送信データの作成
        var sendJson = ptd.TypingDataToJson();
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(sendJson); // byte型配列に変換

        // 接続先URL
        var url = ServerUrl.PLAYER_TYPINGDATA_URL + "?userId=" + userId + "&roomId=" + roomId;
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
