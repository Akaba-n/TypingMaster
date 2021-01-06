using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 記録計算クラス
/// </summary>
public class RecordCalculator : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Insprctorで設定) -----*/
    [SerializeField] private PlayerTypingDataManager ptd;
    [SerializeField] private GameConfigClass gc;

    /// <summary>
    /// 正解率計算メソッド
    /// </summary>
    public void CorrectAnswerRate() {

        if(ptd.td.CorrectTypeNum != 0) {

            ptd.td.Accuracy = 100.0f * (ptd.td.CorrectTypeNum * 1.0f) / ((ptd.td.CorrectTypeNum + ptd.td.MisTypeNum) * 1.0f);
        }
        else {

            ptd.td.Accuracy = 0f;
        }
    }

    /// <summary>
    /// 経過時間計測処理
    /// </summary>
    public void TotalTime() {

        ptd.td.TotalTypingTime += Time.deltaTime;   // 経過時間の算出
        ptd.SectionTypingTime[ptd.td.CorrectTaskNum] += Time.deltaTime;    // 現在の問題文の経過時間を算出
    }
    /// <summary>
    /// KPM計算メソッド(毎フレーム計算)
    /// </summary>
    public void KeyPerMinute() {

        ptd.td.Kpm = ((1.0f * ptd.td.CorrectTypeNum) / (1.0f * ptd.td.TotalTypingTime)) * 60.0f;        
    }

    /// <summary>
    /// 文章当たりのKPM計算メソッド(タイピング終了時計算)
    /// </summary>
    public void SectionKeyPerMinute() {
        
        for(var i = 0; i < gc.gc.Tasks; i++) {

            ptd.SectionKpm[i] = (ptd.SectionCorrectNum[i] * 1.0f) / (ptd.SectionTypingTime[i] * 1.0f) * 60f;
        }
    }
}
