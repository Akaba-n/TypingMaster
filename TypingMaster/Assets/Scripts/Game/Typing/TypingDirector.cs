using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイピング動作関連基底クラス
/// </summary>
public class TypingDirector : MonoBehaviour {

    // 入力可否判定
    public static bool isInputValid;
    // 入力されたキーの情報格納キュー
    public static Queue<KeyCode> keyQueue = new Queue<KeyCode>();   // キーコードの格納   
    public static Queue<double> timeQueue = new Queue<double>();    // 入力タイミングの格納
    // 入力された際に発生する情報
    public static double lastJudgeTime;     // 最後に判定が起こった時刻
}

