using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 対戦相手のデータ管理クラス
/// </summary>
public class EnemyTypingDataManager : TypingDataBase {

    private 

    /*----- 取得する値 -----*/
    public string enemyUserId;
    public string enemyName;
    /*---------- ↓TypingDataBaseで設定 ----------*/
    /*----- Game中情報関連 -----*/
    /// public string enteredSentence;      // 入力済み文字列(灰色表示部分)
    /// public string notEnteredSentence;   // 未入力文字列(通常表示用)
    /// public string jpSentence;           // 現在の問題の日本語文
    /// public string hrSentence;           // 現在の問題のひらがな文
    /*----- Game中記録関連 -----*/
    /// public int CorrectTypeNum;      // 正解タイプ数
    /// public int MisTypeNum;          // ミスタイプ数
    /// public int CorrectTaskNum;      // 正解問題数
    /// public double TotalTypingTime;  // 総合経過時間
    /// public double Kpm;              // KPM
    /// public double Accuracy;         // 正答率
    /// public bool isFinishedGame;     // ゲーム終了判定
     
    public void SyncDataWithServer() {


    }
}
