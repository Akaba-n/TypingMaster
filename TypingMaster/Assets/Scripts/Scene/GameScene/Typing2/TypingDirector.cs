using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイピング部分共通変数管理クラス
/// </summary>
public class TypingDirector : TypingDefine {
    /*----- InitConfig内で初期化 -----*/
    public static GAME_LEVEL gameLevel;     // ゲーム難易度
    public static GAME_MODE gameMode;       // ゲームモード
    public static int Tasks;                // 問題数
    public static string datasetName;       // 問題データセット名

    /*----- InitData内で初期化 -----*/
    public static int CorrectTypeNum;       // 正解タイプ数(結果用)
    public static int CorrectTaskNum;       // 正解問題数
    public static int MisTypeNum;           // ミスタイプ数(結果用)
    public static double TotalTypingTime;   // 総合経過時間(結果用)
    public static double Kpm;               // KPM(結果用)
    public static double Accuracy;          // 正答率(結果用)
    public static bool isRecMistype;        // ミスタイプ判定
    public static Dictionary<string, int> MisTypeDictionary;            // ミスタイプ傾向算出用
    public static Queue<KeyCode> keyQueue = new Queue<KeyCode>();       // キー入力判定格納用のキュー
    public static Queue<double> timeQueue = new Queue<double>();        // キー入力判定日時格納用のキュー

    /*----- InitQuestion内で初期化 -----*/
    public static List<(string jp, string h, List<List<string>> rm)> qSen = new List<(string jp, string h, List<List<string>> rm)>();  // 実際に出題する問題の格納List
    public static List<List<string>> sentenceTyping = new List<List<string>>();    // ローマ字入力候補のみ抽出

    /*----- InitSentence内で初期化 -----*/
    //// 問題文表示用
    public static string enteredSentence;   // 入力済み文字列(灰色表示用)
    public static string notEnteredSentence;    // 未入力文字列(通常表示用)
    //// タイピング関連
    public static bool isFirstInput;    // 文章初期入力判定
    public static double firstCharInputTime;    // 文章初期入力時間
    public static bool isInputValid;    // 入力可能判定(ポーズ画面等)
    public static double lastJudgeTime; // 最後に入力した時間
    public static int index;    // ひらがなで何文字目(ローマ字入力候補の何枠目)か
    public static List<List<int>> indexAdd = new List<List<int>>(); // 追加する文字数(1f中に何回もキータイプがあった時用)
    public static List<List<int>> sentenceIndex = new List<List<int>>();  // 各入力候補の文字数
    public static List<List<bool>> sentenceValid;   // 各入力候補の可否判定
    // 例外処理用
    public static bool acceptSingleN;   // "ん"用 単発"n"可否判定
}
