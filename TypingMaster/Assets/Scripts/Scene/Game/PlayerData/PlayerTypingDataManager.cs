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
