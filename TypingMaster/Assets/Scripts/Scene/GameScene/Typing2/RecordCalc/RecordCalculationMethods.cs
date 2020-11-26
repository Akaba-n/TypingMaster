using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 各記録計算用メソッドクラス
/// </summary>
public class RecordCalculationMethods : MonoBehaviour {

    /// <summary>
    /// 正解率計算メソッド
    /// </summary>
    /// <param name="CorrectTypeNum">正解数</param>
    /// <param name="MisTypeNum">ミスタイプ数</param>
    /// <returns>正解率</returns>
    public double CorrectAnswerRate(int CorrectTypeNum, int MisTypeNum) {

        return 100F * CorrectTypeNum / (CorrectTypeNum + MisTypeNum);
    }

    /*
    /// <summary>
    /// 文章入力時間導出処理
    /// </summary>
    /// <param name="currentTime">文章入力完了時間</param>
    /// <returns>文章入力時間</returns>
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
