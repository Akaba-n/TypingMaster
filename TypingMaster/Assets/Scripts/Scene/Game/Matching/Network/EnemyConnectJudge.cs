using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

public class EnemyConnectJudge : MonoBehaviour {

    [SerializeField] MultiMain mm;

    /// <summary>
    /// 対戦相手の接続状況を確認する処理(5秒以上接続無しで切断処理)
    /// </summary>
    /// <param name="userNum">PlayerのPlayerNum(1 or 2)</param>
    /// <param name="roomId">Room番号</param>
    /// <returns></returns>
    public IEnumerator ServerEnemyConnectJudge(int userNum, string roomId) {

        // 開始時の状態
        var tmpGState = mm.gState;

        // 接続先URL
        var url = ServerUrl.ENEMY_CONNECT_JUDGE_URL + "?userNum=" + userNum.ToString() + "&roomId=" + roomId;
        // URLをGETで用意
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        // URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        if(mm.gState == tmpGState) {

            // エラーチェック
            if (webRequest.isNetworkError || webRequest.isHttpError) {

                // 通信失敗時処理
                Debug.Log(webRequest.error);
            }
            else {

                // 通信成功時処理
                Debug.Log(webRequest.downloadHandler.text);
                // 対戦相手の最終接続からの時間
                var retStr = webRequest.downloadHandler.text;
                float distanceTime = float.Parse(retStr);
                // 最終通信時間から5秒以上経過している時
                if (distanceTime > 5) {

                    ///// 対戦相手を通信切断扱いにする処理 /////
                    StartCoroutine(ServerEnemyDisconnected(userNum, roomId));
                }
            }
        }
        
    }

    /// <summary>
    /// 対戦相手を通信切断扱いにする処理
    /// </summary>
    /// <param name="userNum">PlayerのPlayerNum</param>
    /// <param name="roomId">部屋番号</param>
    /// <returns></returns>
    public IEnumerator ServerEnemyDisconnected(int userNum, string roomId) {

        // 接続先URL
        var url = ServerUrl.ENEMY_DISCONNECT_URL + "?userNum=" + userNum.ToString() + "&roomId=" + roomId;
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
            Debug.Log("対戦相手通信切断");
        }
    }
}
