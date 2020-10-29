using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サーバ接続時タイムアウトコルーチンクラス
/// </summary>
public class ServerTimeOut : MonoBehaviour {

    // タイムアウト時間
    [SerializeField] private const float timeoutsec = 5f;

    public IEnumerator CheckTimeOut(WWW www) {

        // 要求時の時間の取得
        float requestTime = Time.time;

        while (!www.isDone) {   // 通信完了まで

            if (Time.time - requestTime < timeoutsec) {    // 時間計測

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
