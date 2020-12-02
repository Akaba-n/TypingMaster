using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameSceneの初期化クラス
/// </summary>
public class InitGameMethod : MonoBehaviour {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GameActionManager ga;
    [SerializeField] private GameConfig gc;
    [SerializeField] private InitTypingDataMethod pid;  // PlayerのTypingData
    
    /// <summary>
    /// GameSceneの初期化メソッド(SOLOモード用)
    /// </summary>
    public void InitSoloGame() {

        InitConfig();
        pid.InitTypingData();
        InitQuestion();
    }
    /// <summary>
    /// GameSceneの初期化メソッド(MULTIモード用)
    /// </summary>
    public void InitMultiGame() {

        InitConfig();
        pid.InitTypingData();
        ///// サーバから問題データを取得する処理 /////
    }

    /// <summary>
    /// GameConfig関連初期化メソッド
    /// </summary>
    private void InitConfig() {
        /* PlayerPrefsでやるかファイルにぶち込むかは悩み
        gc.DatasetName = PlayerPrefs.GetString(~~, "sample");
        gc.Tasks = PlayerPrefs.GetInt(~~, 0);*/
    }
    /// <summary>
    /// GameAction関連の初期化処理
    /// </summary>
    public void InitGameAction() {

        ga.keyQueue.Clear();        // キー格納キュー初期化
        ga.timeQueue.Clear();       // 時間格納キュー初期化
        ga.isRecMistype = false;    // ミスタイプ判定
        ga.index = 0;
        ga.acceptSingleN = false;
    }
    /// <summary>
    /// Typing開始時の初期化処理
    /// </summary>
    public void InitTypingStart() {

        InitGameAction();
        ga.isInputValid = true;
    }
    /// <summary>
    /// 問題文初期化メソッド(マルチの時はサーバ上で行う)
    /// </summary>
    private void InitQuestion() {

        // スクリプトのインスタンス化(これ重いのでシーン切り替え時以外禁止)
        var csvImport = new CsvImport();
        var hToRClass = new HiraToRom();
        // 問題データセットの取得
        var qJP = csvImport.datasetImport(gc.DatasetName);
        // 選択済み判定(問題順並び替え用)
        var pickList = new bool[qJP.Count];

        for(var i = 0; i < gc.Tasks; i++) {

            // 問題文の順序入れ替え + ローマ字入力候補追加
            var tempNum = UnityEngine.Random.Range(0, qJP.Count);
            // 被ってなかったら追加
            if (!pickList[tempNum]) {

                ga.qSen.Add((qJP[tempNum].jp, qJP[tempNum].h, hToRClass.HiraToRomSentence(qJP[tempNum].h)));
                pickList[tempNum] = true;
            }
            else {

                i -= 1;
            }
        }
        ga.sentenceTyping = ga.qSen[0].rm;
    }
}
