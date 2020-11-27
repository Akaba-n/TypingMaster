using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー情報クラス
/// </summary>
public class PlayerData {

    /*----- Player情報関連 -----*/
    public string playerId;      // PlayerID
    public string playerName;    // PlayerName
    /*----- Game中情報関連 -----*/
    public string enteredSentence;      // 入力済み文字列(灰色表示部分)
    public string notEnteredSentence;   // 未入力文字列(通常表示用)
    /*----- Game中記録関連 -----*/
    public int correctTypeNum;      // 正解タイプ数
    public int misTypeNum;          // ミスタイプ数
    public int correctTaskNum;      // 正解問題数
    public double TotalTypingTime;  // 総合経過時間
    public double Kpm;              // KPM
    public double Accuracy;         // 正答率
}
