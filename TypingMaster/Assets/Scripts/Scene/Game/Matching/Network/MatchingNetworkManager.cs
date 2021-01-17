using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

/// <summary>
/// Matching画面での通信関連管理クラス
/// </summary>
public class MatchingNetworkManager : MonoBehaviour {

    [SerializeField] EnemyConnectJudge ecj;
    [SerializeField] PlayerConnectJudge pcj;
    
    /// <summary>
    /// Matching画面での通信関連管理処理
    /// </summary>
    public void MatchingNetwork() {

        var playerNum = PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 1);
        var roomId = PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000");
        var userId = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000");
        // 対戦相手の通信判定
        StartCoroutine(ecj.ServerEnemyConnectJudge(playerNum, roomId));
        // プレイヤーのサーバ接続時間更新
        StartCoroutine(pcj.ServerPlayerConnectJudge(playerNum, roomId, userId));
    }
}
