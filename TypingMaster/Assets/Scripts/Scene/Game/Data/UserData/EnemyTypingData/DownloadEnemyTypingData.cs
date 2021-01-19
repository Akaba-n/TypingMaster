using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// サーバと通信し、Enemyのデータを取得する為のクラス
/// </summary>
public class DownloadEnemyTypingData : MonoBehaviour {
    
    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private EnemyTypingDataManager etd;
    [SerializeField] private MultiMain mm;

    /// <summary>
    /// UnityWebRequestでサーバから敵のデータを取得
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <returns></returns>
    public IEnumerator DownloadETD(int userNum, string roomId) {

        // 通信開始時画面
        var tmpGState = mm.gState;

        // 接続先URL
        var url = ServerUrl.ENEMY_SYNC_URL + "?userNum=" + userNum.ToString() + "&roomId=" + roomId;
        // URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        // URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        // 通信開始時と通信終了時の画面が同一であれば処理
        if (tmpGState == mm.gState) {

            // エラーチェック
            if (webRequest.isNetworkError) {

                // 通信失敗時処理
                Debug.Log(webRequest.error);
            }
            else {
                
                // 通信成功時処理
                Debug.Log(webRequest.downloadHandler.text);
                var jsonstr = webRequest.downloadHandler.text;
                etd.td = JsonUtility.FromJson<EnemyTypingDataManager.TypingData>(jsonstr);
            }
        }
    }
}
