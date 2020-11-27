using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

/// <summary>
/// Game中情報クラス
/// </summary>
public class TypingData : PlayerData {

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

    /*----- 記録計算関連 -----*/
    /// <summary>
    /// 正解率計算メソッド
    /// </summary>
    public void CorrectAnswerRate() {

        Accuracy = 100f * CorrectTaskNum / (CorrectTaskNum + MisTypeNum);
    }
    /*
    /// <summary>
    /// 実際の経過時間の算出メソッド
    /// </summary>
    /// <param name="currentTime"></param>
    /// <returns></returns>
    public double GetSentenceTypeTime(double currentTime) {

        // 返す値の初期化
        double ret;
        if (Math.Abs(firstCharInputTime - lastUpdateTime) <= INTERVAL) {

            Debug.Log(CorrectTaskNum.ToString() + " -> time:" + (currentTime - firstCharInputTime).ToString());
            ret = currentTime - firstCharInputTime;
        }
        else {

            Debug.Log(CorrectTaskNum.ToString() + " -> time:" + (currentTime - firstCharInputTime).ToString());
            ret = currentTime - (lastUpdateTime + INTERVAL);
        }
        return ret;
    }
    */
}
