using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player情報クラス
/// </summary>
public class PlayerTypingDataManager : TypingDataBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private RecordCalculator rc;

    /*---------- Playerのみの変数 ----------*/
    public Dictionary<string, int> MisTypeDictionary;    // 苦手キーDict
    public double[] SectionTypingTime;  // 各文経過時間
    public int[] SectionCorrectNum;  // 各文正解タイプ数
    public double[] SectionKpm;         // 各文KPM

    /*----- GamePlayerActionManagerとの同期 -----*/
    /// <summary>
    /// GamePlayerActionManagerとの同期処理
    /// </summary>
    public void SyncAllGamePlayerActionManager() {

        CorrectTaskNum = pa.CorrectTaskNum;
        CorrectTypeNum = pa.CorrectTypeNum;
        MisTypeNum = pa.MisTypeNum;
        enteredSentence = pa.enteredSentence;
        notEnteredSentence = pa.notEnteredSentence;
        jpSentence = pa.qSen[pa.CorrectTaskNum].jp.ToString();
        hrSentence = pa.qSen[pa.CorrectTaskNum].h.ToString();
        isFinishedGame = pa.isFinishedGame;
        // ↓これはPlayerTypingDataで管理する必要無さそう？
        MisTypeDictionary = pa.MisTypeDictionary;
    }
    /// <summary>
    /// GamePlayerActionManagerとの同期処理(記録関連のみ)
    /// </summary>
    public void SyncRecGamePlayerActionManager() {

        CorrectTaskNum = pa.CorrectTaskNum;
        CorrectTypeNum = pa.CorrectTypeNum;
        MisTypeNum = pa.MisTypeNum;
        enteredSentence = pa.enteredSentence;
        notEnteredSentence = pa.notEnteredSentence;
        SectionCorrectNum = pa.SectionCorrectNum;
    }

    /*----- 記録計算関連 -----*/
    /// <summary>
    /// 各種記録の計算を纏めて行うメソッド
    /// </summary>
    public void RecCalc() {

        rc.CorrectAnswerRate();
        rc.TotalTime();
        rc.KeyPerMinute();
    }
    /// <summary>
    /// タイピング終了時の各記録の計算を纏めて行うメソッド
    /// </summary>
    public void FinishRecCalc() {

        rc.SectionKeyPerMinute();
    }
}
