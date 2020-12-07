using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// サーバと通信し、Enemyのデータを取得する為のクラス
/// </summary>
public class GetEnemyTypingData : MonoBehaviour {
    
    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private EnemyTypingDataManager etd;
    /*----- オブジェクトのインスタンス化 -----*/
    private ServerUrl sUrl = new ServerUrl();

    /// <summary>
    /// UnityWebRequestでサーバから敵のデータを取得
    /// </summary>
    /// <param name="url">接続先URL</param>
    /// <returns></returns>
    public IEnumerator GetETD(string url) {

        url = "http://ec2-18-181-251-215.ap-northeast-1.compute.amazonaws.com/test/userDataTest.php";
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
            var jsonstr = webRequest.downloadHandler.text;
            etd.td = JsonUtility.FromJson<EnemyTypingDataManager.TypingData>(jsonstr);
        }
    }
}
