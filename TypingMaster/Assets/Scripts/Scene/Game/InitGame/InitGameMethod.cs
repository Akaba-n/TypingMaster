using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameSceneの初期化クラス
/// </summary>
public class InitGameMethod : MonoBehaviour {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private GameConfig gc;
    [SerializeField] private PlayerTypingDataManager ptd;
    [SerializeField] private NextSentenceMethod ns;

    /// <summary>
    /// GameSceneの初期化メソッド(SOLOモード用)
    /// </summary>
    public void InitSoloGame() {

        InitConfig();
        InitPlayerTypingData();
        InitGamePlayerAction();
        InitQuestion();
        ///// 最初の文章のenteredSentenceの格納 /////
        ns.NewSentence();
    }

    /// <summary>
    /// GameSceneの初期化メソッド(MULTIモード用)
    /// </summary>
    public void InitMultiGame() {

        InitConfig();
        InitPlayerTypingData();
        InitGamePlayerAction();
        ///// サーバから問題データを取得する処理 /////
    }

    /// <summary>
    /// Typing開始時の初期化処理
    /// </summary>
    public void InitTypingStart() {

        pa.isInputValid = true;
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
    private void InitGamePlayerAction() {

        // 記録関連(他でも行っているから必要ないと言えば必要ない)
        pa.CorrectTypeNum = 0;
        pa.CorrectTaskNum = 0;
        pa.MisTypeNum = 0;
        pa.MisTypeDictionary = new Dictionary<string, int>();
        pa.enteredSentence = "";
        pa.notEnteredSentence = "";
        pa.SectionCorrectNum = new int[gc.Tasks];
        // タイピング関連
        pa.keyQueue.Clear();        // キー格納キュー初期化
        pa.timeQueue.Clear();       // 時間格納キュー初期化
        pa.isRecMistype = false;    // ミスタイプ判定
        pa.index = 0;
        pa.acceptSingleN = false;
    }
    /// <summary>
    /// TypingData関連初期化メソッド
    /// </summary>
    private void InitPlayerTypingData() {

        ptd.td.CorrectTypeNum = 0;
        ptd.td.CorrectTaskNum = 0;
        ptd.td.MisTypeNum = 0;
        ptd.td.TotalTypingTime = 0f;
        ptd.td.Kpm = 0f;
        ptd.td.Accuracy = 0f;
        ptd.MisTypeDictionary = new Dictionary<string, int>();
        ptd.SectionTypingTime = new double[gc.Tasks];
        ptd.SectionCorrectNum = new int[gc.Tasks];
        ptd.SectionKpm = new double[gc.Tasks];
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

                pa.qSen.Add((qJP[tempNum].jp, qJP[tempNum].h, hToRClass.HiraToRomSentence(qJP[tempNum].h)));
                pickList[tempNum] = true;
            }
            else {

                i -= 1;
            }
        }
    }
}
