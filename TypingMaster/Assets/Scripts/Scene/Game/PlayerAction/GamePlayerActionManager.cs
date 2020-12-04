using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

/// <summary>
/// GameScene中のPlayerのアクションに対するレスポンスの管理クラス
/// </summary>
public class GamePlayerActionManager : PlayerActionBase {

    [SerializeField] private GameTypingCheckMethod tc;
    [SerializeField] private PlayerTypingDataManager td;
    [SerializeField] private InitGameMethod ig;
    [SerializeField] private UpdatePlayerRomSentence us;

    // 記録関連(TypingDataとTypingData側で同期させる)
    public int CorrectTypeNum;      // 正解タイピング数
    public int CorrectTaskNum;      // 正解問題数
    public int MisTypeNum;   // ミスタイプ数
    public Dictionary<string, int> MisTypeDictionary;    // 苦手キーDict
    public string enteredSentence;      // 入力済み文字列
    public string notEnteredSentence;   // 未入力文字列

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
    // ゲーム終了判定
    public bool isFinishedGame = false;

    /// <summary>
    /// プレイヤー動作時に作動
    /// </summary>
    protected override void OnGUI() {

        // キー入力時にそのキーをキューに保管する
        base.OnGUI();
    }

    /// <summary>
    /// ゲームシーンでのタイピングチェック
    /// </summary>
    /// <returns>タイピングの有無判定</returns>
    public bool GameSceneTypingCheck() {

        // そのフレーム(前のフレーム？)の入力キーを格納
        keyList = tc.GameTypingCheck();

        // キー入力が無かった時終了
        if (keyList.Count == 0) { return false; }
        // キー入力があった時の処理
        for (var i = 0; i < keyList.Count; i++) {

            // 入力キーの確認(デバッグ用)
            Debug.Log("GameSceneTypingCheck.keyList["+i+"]："+keyList[i]);
            // タイピング成否判定
            tc.MisTypeCheck(keyList[i]);
        }

        return true;
    }
}
