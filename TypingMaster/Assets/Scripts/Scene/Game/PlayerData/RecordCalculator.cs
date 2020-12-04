using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 記録計算クラス
/// </summary>
public class RecordCalculator : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Insprctorで設定) -----*/
    [SerializeField] private PlayerTypingDataManager td;
    [SerializeField] private GameConfig gc;

    /// <summary>
    /// 正解率計算メソッド
    /// </summary>
    public void CorrectAnswerRate() {

        if(td.CorrectTypeNum != 0) {

            td.Accuracy = 100.0f * (td.CorrectTypeNum * 1.0f) / ((td.CorrectTypeNum + td.MisTypeNum) * 1.0f);
        }
        else {

            td.Accuracy = 0f;
        }
    }

    /// <summary>
    /// 経過時間計測処理
    /// </summary>
    public void TotalTime() {

        td.TotalTypingTime += Time.deltaTime;   // 経過時間の算出
        td.SectionTypingTime[td.CorrectTaskNum] += Time.deltaTime;    // 現在の問題文の経過時間を算出
    }
    /// <summary>
    /// KPM計算メソッド(毎フレーム計算)
    /// </summary>
    public void KeyPerMinute() {
        
        td.Kpm = ((1.0f * td.CorrectTypeNum) / (1.0f * td.TotalTypingTime)) * 60.0f;        
    }

    /// <summary>
    /// 文章当たりのKPM計算メソッド(タイピング終了時計算)
    /// </summary>
    public void SectionKeyPerMinute() {
        
        for(var i = 0; i < gc.Tasks; i++) {

            td.SectionKpm[i] = (td.SectionCorrectNum[i] * 1.0f) / (td.SectionTypingTime[i] * 1.0f) * 60f;
        }
    }
}
