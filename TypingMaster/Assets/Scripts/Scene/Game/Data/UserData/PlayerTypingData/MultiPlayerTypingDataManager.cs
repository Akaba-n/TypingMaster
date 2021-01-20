using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class MultiPlayerTypingDataManager : TypingDataBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private MultiPlayerActionManager pa;
    [SerializeField] private MultiRecordCalculator rc;
    [SerializeField] private UploadPlayerTypingData uploadPTD;

    /*---------- Playerのみの変数 ----------*/
    public Dictionary<string, int> MisTypeDictionary;    // 苦手キーDict
    public double[] SectionTypingTime;  // 各文経過時間
    public int[] SectionCorrectNum;     // 各文正解タイプ数
    public double[] SectionKpm;         // 各文KPM

    private void Awake() {
        
        ///// 本来はマッチング時に設定する /////
        roomId = PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000");
        td.UserId = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000");
        td.UserName = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "");
        UserNum = PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 1);
        td.isReady = false;
        //UploadPlayerTypingData(playerUserId, roomId);
    }

    /*----- GamePlayerActionManagerとの同期 -----*/
    /// <summary>
    /// GamePlayerActionManagerとの同期処理
    /// </summary>
    public void SyncAllGamePlayerActionManager() {

        td.CorrectTaskNum = pa.CorrectTaskNum;
        td.CorrectTypeNum = pa.CorrectTypeNum;
        td.MisTypeNum = pa.MisTypeNum;
        td.enteredSentence = pa.enteredSentence;
        td.notEnteredSentence = pa.notEnteredSentence;
        td.jpSentence = pa.qSen[pa.CorrectTaskNum].jp.ToString();
        td.hrSentence = pa.qSen[pa.CorrectTaskNum].h.ToString();
        td.isFinishedGame = pa.isFinishedGame;
        // ↓これはPlayerTypingDataで管理する必要無さそう？
        MisTypeDictionary = pa.MisTypeDictionary;
    }
    /// <summary>
    /// GamePlayerActionManagerとの同期処理(記録関連のみ)
    /// </summary>
    public void SyncRecGamePlayerActionManager() {

        td.CorrectTaskNum = pa.CorrectTaskNum;
        td.CorrectTypeNum = pa.CorrectTypeNum;
        td.MisTypeNum = pa.MisTypeNum;
        td.enteredSentence = pa.enteredSentence;
        td.notEnteredSentence = pa.notEnteredSentence;
        SectionCorrectNum = pa.SectionCorrectNum;
        td.isFinishedGame = pa.isFinishedGame;
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


    /*----- サーバー通信関連 -----*/
    public void UploadPlayerTypingData(int userNum, string roomId) {

        StartCoroutine(uploadPTD.UploadPTD(userNum, roomId));
    }
}
