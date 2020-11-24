using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 問題文管理クラス
/// </summary>
public class TypingManager : GameDefine {

    //// スクリプトの読み込み(Inspectorで設定)
    [SerializeField] private CsvImport csvImport;
    [SerializeField] private HtoRClass htoRClass;
    [SerializeField] private Text JpText;
    [SerializeField] private Text HrText;
    [SerializeField] private Text RmText;

    //// ゲーム設定関連
    private string datasetName;    // 問題データセット名
    private int qNum;              // 問題数
    private GAME_MODE gameMode;    // ゲームモード
    private GAME_LEVEL gameLevel;  // ゲーム難易度

    //// ゲーム記録関連
    // ゲームモード
    public static int GameMode {

        private set;
        get;
    }
    // 正解タイプ数
    public static int CorrectTypeNum {

        private set;
        get;
    }
    // KPM
    public static double Kpm {

        private set;
        get;
    }
    // ミスタイプ数
    public static int MisTypeNum {
        
        private set;
        get;
    }
    // 正解率
    public static double Accuracy {

        private set;
        get; 
    }
    // ミスタイプの記録(どのキーを何回ミスったか)
    public static Dictionary<string, int> MisTypeDictionary {

        private set;
        get;
    }
    // 経過時間
    public static double TotalTypingTime;

    //// ゲーム内使用変数
    // 問題数
    public static int Tasks;
    // 正解問題数
    public static int CorrectTaskNum;

    // 入力された文字の queue
    private Queue<KeyCode> keyQueue = new Queue<KeyCode>();
    // 時刻の queue
    private Queue<double> timeQueue = new Queue<double>();

    // 問題文格納用リスト
    private List<(string jp, string h)> qJP = new List<(string jp, string h)>();
    private List<(string jp, string h, List<List<string>> rm)> qSen = new List<(string jp, string h, List<List<string>> rm)>(); // jp:日本語文, h:ひらがな文, rm:ローマ字入力候補
    // これまで打った文字列
    private string correctString;
    // ミスタイプした文字の記録
    private bool isRecMistype;
    private string misTypeLetter;

    private bool isInputValid = true;  // 文字入力可能判定

    /* DisplaySentence送り変数候補 */
    //private string correctString;   // 正解済み文字列
    private bool isFirstInput;      // 初期入力判定
    private bool acceptSingleN;     // "ん" 単発"n"判定
    private int index;
    private int sectionLength;


    /// <summary>
    /// ゲーム初期化処理
    /// </summary>
    private void Awake() {

        InitConfig();
        InitData();
        InitQuestion();

        NextSentence();
    }

    /// <summary>
    /// 設定関連初期化
    /// </summary>
    private void InitConfig() {

        gameLevel = GAME_LEVEL.EASY;    // ゲーム難易度(後で設定ファイルを参照するようにする)
        gameMode  = GAME_MODE.SOLO;     // ゲームモード(後で設定ファイルを参照するようにする)
        Tasks = 2;                      // 問題数(後で設定ファイルを参照するようにする)
        datasetName = "sample";         // 問題データセット名(後で設定ファイルを参照するようにする)
    }

    /// <summary>
    /// 記録関連初期化
    /// </summary>
    private void InitData() {

        // 問題データセットの読み込み(csvファイルの読み込み)
        qJP = csvImport.datasetImport(datasetName);
        // データ関連の初期化
        CorrectTypeNum = 0;
        CorrectTaskNum = 0;
        MisTypeNum = 0;
        TotalTypingTime = 0f;
        Kpm = 0f;
        Accuracy = 0f;
        isRecMistype = false;
        MisTypeDictionary = new Dictionary<string, int>();
        keyQueue.Clear();
    }

    /// <summary>
    /// 問題文初期化メソッド
    /// </summary>
    private void InitQuestion() {

        var pickList = new bool[qJP.Count]; // 選択済み判定

        for (var i = 0; i < Tasks; i++) {

            // 問題文の順番入れ替え + ローマ字入力候補追加
            var tempNum = Random.Range(0, qJP.Count);
            // 被ってなかったら追加
            if (!pickList[tempNum]) {

                qSen.Add((qJP[tempNum].jp, qJP[tempNum].h, htoRClass.HtoRSentence(qJP[tempNum].h)));
                pickList[tempNum] = true;
            }
            else {

                i -= 1;
            }
        }
    }

    /// <summary>
    /// 新しい問題を表示するメソッド
    /// </summary>
    private void NextSentence() {

        // テキストUIを初期化する
        JpText.text = "";
        HrText.text = "";
        RmText.text = "";

        // 問題文の表示
        ChangeSentence();

        // 正解した文字列の初期化
        correctString = "";

        // 変数の初期化
        isFirstInput = true;
        acceptSingleN = false;
        index = 0;
        sectionLength = 0;
        
    }
    /// <summary>
    /// テキストUIに表示する問題文を変更するメソッド
    /// </summary>
    private void ChangeSentence() {

        // テキストUIに表示する問題文の変更
        JpText.text = qSen[CorrectTaskNum].jp;  // 日本語文
        HrText.text = qSen[CorrectTaskNum].h;   // ひらがな文
        for (var i = 0; i < qSen[CorrectTaskNum].rm.Count; i++) {

            RmText.text += qSen[CorrectTaskNum].rm[i][0];   // ローマ字文(入力候補トップ)
        }
        // 確認用
        Debug.Log(JpText.text);
        Debug.Log(HrText.text);
        Debug.Log(RmText.text);
    }

    /// <summary>
    /// キーが入力される度に発生するメソッド
    /// </summary>
    private void OnGUI() {

        Event e = Event.current;
        if(isInputValid && e.type == EventType.KeyDown && e.type != EventType.KeyUp && e.keyCode != KeyCode.None
        && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2)) {


        }
    }
}
