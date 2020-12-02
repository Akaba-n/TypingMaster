using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイピング動作関連基底クラス(Playerにしか関係ない)
/// </summary>
public class GameActionDirector : PlayerActionBase {

    // 問題文データセット格納List
    public List<(string jp, string h, List<List<string>> rm)> qSen = new List<(string jp, string h, List<List<string>> rm)>();  // 実際に出題する問題の格納List
    public List<List<string>> sentenceTyping = new List<List<string>>();    // ローマ字入力候補
    // 現在の問題文に対する情報関連
    public int index;                                                // ひらがなで何文字目(ローマ字入力候補の何枠目)か
    public List<List<int>> indexAdd = new List<List<int>>();         // 追加する文字数(1f中に何回もキータイプがあった時用)
    public List<List<int>> sentenceIndex = new List<List<int>>();    // 各入力候補の文字数
    public List<List<bool>> sentenceValid = new List<List<bool>>();                           // 各入力候補の可否判定
    // 例外処理判定関連
    public bool acceptSingleN;      // "ん"のn1回可否判定
    // ミスタイプ判定関連
    public bool isRecMistype;       // ミスタイプ中か判定
}


