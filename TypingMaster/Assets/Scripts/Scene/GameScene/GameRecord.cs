using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム記録変数管理クラス
/// </summary>
public class GameRecord : MonoBehaviour {

    public static int CorrectTypeNum;   // 正解タイプ数
    public static int MissTypeNum;      // ミスタイプ数
    public static float TotalTypeTime;  // 合計時間 
    public static double Kpm;           // kpm
    public static double Accuracy;      // 正解率
    public static Dictionary<string, int> MisTypeDic;   // キー毎のミスタイプ数
}
