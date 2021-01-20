using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// プレイヤーのタイピングデータを送信格納するクラス
/// </summary>
public class UploadPlayerTypingData : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private MultiPlayerTypingDataManager ptd;
    [SerializeField] private MultiMain mm;

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
    /// <param name="userNum">Playerの番号</param>
    /// <param name="roomId">所属しているroomId</param>
    /// <returns></returns>
    public IEnumerator UploadPTD(int userNum, string roomId) {

        // 通信開始時画面
        var tmpGState = mm.gState;
        
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

        // 通信開始時と通信終了時の画面が同一であれば処理
        if (tmpGState == mm.gState) {

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
}
