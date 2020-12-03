using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game中情報クラス
/// </summary>
public class TypingDataManager : UserData {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private UpdatePlayerRomSentence ur;
    [SerializeField] private NextSentenceMethod ns;

    /*----- Game中情報関連 -----*/
    public string enteredSentence;      // 入力済み文字列(灰色表示部分)
    public string notEnteredSentence;   // 未入力文字列(通常表示用)
    /*----- Game中記録関連 -----*/
    public int CorrectTypeNum;      // 正解タイプ数
    public int MisTypeNum;          // ミスタイプ数
    public int CorrectTaskNum;      // 正解問題数
    public double TotalTypingTime;  // 総合経過時間
    public double Kpm;              // KPM
    public double Accuracy;         // 正答率
    public Dictionary<string, int> MisTypeDictionary;    // 苦手キーDict

    /*----- 文章更新関連 -----*/
    /// <summary>
    /// EnteredSentenceの更新
    /// </summary>
    public void UpdateEnteredSentence() {
        
        ur.UpdatePlayerSentence();
    }
    /// <summary>
    /// 最初の文章を表示する為の更新処理
    /// </summary>
    public void UpdateFirstSentence() {

        ns.InitNextSentence();
        ur.UpdatePlayerSentence();
    }
    /// <summary>
    /// 次の文章に移行する際の更新処理
    /// </summary>
    public void UpdateNextSentence() {

        ns.NextSentence();
        ur.UpdatePlayerSentence();
    }

    /*----- 記録計算関連 -----*/
    /// <summary>
    /// 各種記録の計算を纏めて行うメソッド
    /// </summary>
    public void CalcurateRecords() {

        CorrectAnswerRate();
    }
    /// <summary>
    /// 正解率計算メソッド
    /// </summary>
    public void CorrectAnswerRate() {

        Accuracy = 100f * CorrectTaskNum / (CorrectTaskNum + MisTypeNum);
    }
}
