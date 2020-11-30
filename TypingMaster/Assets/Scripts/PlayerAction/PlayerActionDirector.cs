using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイピング動作関連基底クラス(Playerにしか関係ない)
/// </summary>
public class PlayerActionDirector : TypingData {

    // 入力可否判定
    public bool isInputValid;
    // 入力されたキーの情報格納キュー
    public Queue<KeyCode> keyQueue = new Queue<KeyCode>();   // キーコードの格納   
    public Queue<double> timeQueue = new Queue<double>();    // 入力タイミングの格納
    // 入力された際に発生する情報
    public static double lastJudgeTime;     // 最後に判定が起こった時刻
    // 問題文データセット格納List
    public List<(string jp, string h, List<List<string>> rm)> qSen = new List<(string jp, string h, List<List<string>> rm)>();  // 実際に出題する問題の格納List
    public List<List<string>> sentenceTyping = new List<List<string>>();    // ローマ字入力候補
    // 現在の問題文に対する情報関連
    public int index;                                                // ひらがなで何文字目(ローマ字入力候補の何枠目)か
    public List<List<int>> indexAdd = new List<List<int>>();         // 追加する文字数(1f中に何回もキータイプがあった時用)
    public List<List<int>> sentenceIndex = new List<List<int>>();    // 各入力候補の文字数
    public List<List<bool>> sentenceValid;                           // 各入力候補の可否判定
}


