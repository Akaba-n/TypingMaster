using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

/// <summary>
/// Matching画面での通信関連管理クラス
/// </summary>
public class MatchingNetworkManager : MonoBehaviour {

    /*----- Scriptの取得(Inspectorで設定) -----*/
    [SerializeField] private EnemyConnectJudge ecj;
    [SerializeField] private PlayerConnectJudge pcj;
    [SerializeField] private DownloadEnemyTypingData dletd;
    [SerializeField] private UploadPlayerTypingData ulptd;

    // コルーチンの動作数カウント(全コルーチン終了判定用)
    public int strCnt;  // 開始済み
    public int endCnt;  // 終了済み
    
    /// <summary>
    /// Matching画面での通信関連管理処理
    /// </summary>
    public void MatchingNetwork() {

        var playerNum = PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 1);
        var roomId = PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000");
        var userId = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000");
        // 対戦相手の通信判定
        StartCoroutine(ecj.ServerEnemyConnectJudge(playerNum, roomId));
        // 対戦相手のデータダウンロード
        StartCoroutine(dletd.DownloadETD(playerNum, roomId));
        // プレイヤーのサーバ接続時間更新
        StartCoroutine(pcj.ServerPlayerConnectJudge(playerNum, roomId, userId));
        // プレイヤーのデータアップロード
        StartCoroutine(ulptd.UploadPTD(playerNum, roomId));
    }
}
