using System;
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

    private const double INTERVAL = 2.0f;

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
    // 正解済み問題数
    private int tasksCompleted;

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

    //// 時間計測関連 
    private bool isFirstInput;      // 初期入力判定
    private double firstCharInputTime;  // 初期入力時間
    private double lastUpdateTime;      // 最後に更新された時間
    private double lastJudgeTime;       // 最後に入力した時間
    private bool acceptSingleN;     // "ん" 単発"n"判定

    // タイピング内容判別用(index関連)
    private List<List<string>> sentenceTyping;    // ローマ字入力候補
    private int index;  // ローマ字入力候補の何枠目か
    private List<List<int>> indexAdd = new List<List<int>>();
    private List<List<int>> sentenceIndex = new List<List<int>>();  // 各入力候補の文字数
    private List<List<bool>> sentenceValid = new List<List<bool>>();  // 各入力候補の何文字目か
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

    private void Update() {

        if(keyQueue.Count > 0 && timeQueue.Count > 0) {

            if(keyQueue.Count != timeQueue.Count) {

                // 謎(前提が間違えているエラー時？？)
            }
            TypingCheck();
        }
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
        tasksCompleted = 0;
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
            var tempNum = UnityEngine.Random.Range(0, qJP.Count);
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

        // 正解した文字列の初期化
        correctString = "";

        // 変数の初期化
        isFirstInput = true;
        acceptSingleN = false;
        index = 0;
        sectionLength = 0;

        // 問題文の表示
        ChangeSentence();
        // 時刻の取得
        lastUpdateTime = Time.realtimeSinceStartup;
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
        InitSentenceData();
        // 確認用
        Debug.Log(JpText.text);
        Debug.Log(HrText.text);
        Debug.Log(RmText.text);
    }
    /// <summary>
    /// 次の問題文に関する諸々の変数の初期化
    /// </summary>
    private void InitSentenceData() {

        sentenceTyping = qSen[CorrectTaskNum].rm;   // ローマ字入力候補の格納
        var sLength = sentenceTyping.Count;         // 問題文の文字数

        // 各項目初期化
        sentenceIndex.Clear();
        sentenceValid.Clear();
        indexAdd.Clear();
        sentenceIndex = new List<List<int>>();
        sentenceValid = new List<List<bool>>();
        indexAdd = new List<List<int>>();
        for(int i = 0; i < sLength; ++i) {

            var typeNum = sentenceTyping[i].Count;  // その文字の入力候補数
            // 枠の追加
            sentenceIndex.Add(new List<int>());
            sentenceValid.Add(new List<bool>());
            indexAdd.Add(new List<int>());
            for(int j = 0; j < typeNum; ++j) {

                // 判定追加
                sentenceIndex[i].Add(0);    // 初期状態なので0文字目
                sentenceValid[i].Add(true);    // 入力有効判定：true
                indexAdd[i].Add(0);
            }
        }
    }

    /*---------- タイピング関連 ----------*/
    /// <summary>
    /// キーが入力される度に発生するメソッド
    /// </summary>
    private void OnGUI() {

        Event e = Event.current;
        if(isInputValid && e.type == EventType.KeyDown && e.type != EventType.KeyUp && e.keyCode != KeyCode.None
        && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2)) {

            var kc = e.keyCode; // 入力されたキーコード
            if (isFirstInput) {

                firstCharInputTime = Time.realtimeSinceStartup;
                isFirstInput = false;
            }
            keyQueue.Enqueue(e.keyCode);
            timeQueue.Enqueue(Time.realtimeSinceStartup);
        }
    }

    private KeyCode GetKeycode(char c) {

        if('.' == c) {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Period");
        }
        else if(',' == c) {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Comma");
        }
        else if('-' == c) {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Minus");
        }
        else if('0' - '0' <= c - '0' && c - '0' <= '9' - '0') {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + c.ToString());
        }
        else if('a' - 'a' <= c - 'a' && c - 'a' <= 'z' - 'a') {
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), c.ToString().ToUpper());
        }
        return KeyCode.None;
    }

    /// <summary>
    /// queueによるタイピングチェック
    /// </summary>
    private void TypingCheck() {

        while(keyQueue.Count > 0) {

            // keyQueueに入っているkeycodeの取得(Queue.Peek()は読み込み、Dequeue()は取り出し)
            KeyCode kc = keyQueue.Peek();
            keyQueue.Dequeue();
            double keyDownTime = timeQueue.Peek();
            timeQueue.Dequeue();

            if(keyDownTime <= lastJudgeTime) {
                continue;
            }

            // まだ可能性のあるセンテンス全てに対してミスタイプかチェックする
            bool isMistype = true;
            string str = "";
            // EscKeyの場合メニュー画面を開く(中身は後で実装)
            if(kc == KeyCode.Escape) {

                OpenMenu();
                break;
            }
            // 全てのvalidなセンテンスに対してチェックする
            for(var i = 0; i < sentenceTyping[index].Count; ++i) {

                // invalidならパス
                if(!sentenceValid[index][i]) {

                    continue;
                }

                // validの場合
                int j = sentenceIndex[index][i];
                KeyCode nextKC = GetKeycode(sentenceTyping[index][i][j]);   // 次にタイピングする文字を取得
                // "ん"の処理(n1個でもokの時に2個目のnが来た時の例外処理)
                if(acceptSingleN && KeyCode.N == kc) {

                    isMistype = false;
                    indexAdd[index][i] = 0;
                    str = "n";
                }
                // 正解タイプ時
                else if(kc == nextKC) {

                    isMistype = false;
                    indexAdd[index][i] = 1;
                    str = sentenceTyping[index][i][j].ToString();
                }
                else {

                    indexAdd[index][i] = 0;
                }
            }

            
            if (!isMistype) {

                // 正解タイプ時処理
                Correct(str, acceptSingleN);
            }
            else {

                // ミスタイプ時処理
                Mistype();
            }
        }
    }

    /*---------- タイピング正解関連 ----------*/
    /// <summary>
    /// タイピング正解時の処理
    /// </summary>
    /// <param name="str">入力文字</param>
    /// <param name="singleN">n 一文字判定</param>
    private void Correct(string str, bool singleN) {

        // 正解タイプ数を増やす
        CorrectTypeNum++;
        // 正解率の計算
        CorrectAnswerRate();
        // ミスタイプがあった場合苦手キーに追加
        MisTypeAdd(str);
        isRecMistype = false;
        // 可能な入力パターンのチェック
        bool isIndexCountUp = CheckValidSentence(str, singleN);
        // ローマ字入力候補の表示を更新
        UpdateSentence();
        if (isIndexCountUp) {

            index++;
        }
        // 文章入力完了処理
        if(index >= sentenceTyping.Count) {

            CompleteTask();
        }
    }

    /// <summary>
    /// 文章入力完了処理
    /// </summary>
    private void CompleteTask() {

        // 完了済み問題数の追加
        tasksCompleted++;
        double currentTime = Time.realtimeSinceStartup; // 完了時間の保存
        // KPMの計算
        KeyPerMinute(currentTime);
        keyQueue.Clear();

        // 終了処理
        if(tasksCompleted >= Tasks) {

            finished();
        }
    }

    private void finished() {

        // リザルト表示
    }

    /// <summary>
    /// 可能な入力パターンのチェック処理
    /// </summary>
    /// <param name="str">入力文字</param>
    /// <param name="singleN">n 一文字判定</param>
    /// <returns>入力可能判定</returns>
    private bool CheckValidSentence(string str, bool singleN) {

        // 返す値の格納
        bool ret = false;
        // 例外処理フラグをfalseにする
        acceptSingleN = false;
        // 可能な入力パターンを残す
        for (int i = 0; i < sentenceTyping[index].Count; ++i) {

            Debug.Log(qSen[CorrectTaskNum]);

            // "ん"の例外処理
            if (singleN && str.Equals("n")) {

                continue;
            }
            else if (indexAdd[index][i] == 0 && !singleN) {

                sentenceValid[index][i] = false;
            }
            // "っ"の例外処理
            else if (qSen[CorrectTaskNum].h[index].Equals("っ") && index + 1 < sentenceTyping.Count && sentenceTyping[index][i].Length == 1 && str.Equals(sentenceTyping[index][i][0].ToString())) {

                for (int j = 0; j < sentenceTyping[index + 1].Count; ++j) {

                    if (!str.Equals(sentenceTyping[index + 1][j][0].ToString())) {

                        sentenceValid[index + 1][j] = false;
                    }
                }
            }
            // strと一致しないものを無効化処理
            else if (!str.Equals(sentenceTyping[index][i][sentenceIndex[index][i]].ToString())) {

                sentenceValid[index][i] = false;
            }

            // 次のキーへ
            sentenceIndex[index][i] += indexAdd[index][i];
            // 次の文字へ
            if (sentenceIndex[index][i] >= sentenceTyping[index][i].Length) {

                if (string.Equals("n", sentenceTyping[index][i])) {

                    acceptSingleN = true;
                }
                ret = true;
            }
        }
        return ret;
    }

    /// <summary>
    /// ローマ字文の更新処理(入力済みの文字を薄く)
    /// </summary>
    /// <param name="str">入力文字</param>
    private void UpdateSentence() {

        // 入力済み文字をグレーにする
        RmText.text = "<color=#cccccc>";
        var correctEnd = false;
        for(int i = 0; i < sentenceTyping.Count; ++i) {

            // 入力済み文字の判定
            if(i < index) {

                for (var j = 0; j < sentenceTyping[i].Count; ++j) {

                    if (!sentenceValid[i][j]) {

                        continue;
                    }
                    else {

                        for(var k = 0; k < sentenceTyping[i][j].Length; ++k) {

                            // 入力済み文字の表示
                            RmText.text += sentenceTyping[i][j][k].ToString();
                        }
                    }
                }
                continue;
            }
            for(var j = 0; j < sentenceTyping[i].Count; ++j) {

                if(index == i && !sentenceValid[index][j]) {

                    continue;
                }
                else if(index == i && sentenceValid[index][j]) {

                    for(var k = 0; k < sentenceTyping[index][j].Length; ++k) {

                        if(k >= sentenceIndex[index][j]) {

                            // 打ち込み終了時htmlタグを閉じる
                            if (!correctEnd) {

                                RmText.text += "</color>";
                                correctEnd = true;
                            }

                            // ミスタイプ時打つべき文字を強調表示
                            if (isRecMistype) {

                                RmText.text += "<color=#ff0000ff>" + sentenceTyping[index][j][k].ToString() + "</color>";
                                continue;
                            }
                            RmText.text += sentenceTyping[index][j][k].ToString();
                            continue;
                        }
                        RmText.text += sentenceTyping[index][j][k].ToString();
                    }
                    break;
                }
                else if(index != i && sentenceValid[i][j]) {

                    // 打ち込み終了時htmlタグを閉じる
                    if (!correctEnd) {

                        RmText.text += "</color>";
                        correctEnd = true;
                    }

                    RmText.text += sentenceTyping[i][j];
                    break;
                }
            }
        }
    }
    /*---------- ミスタイプ関連 ----------*/
    /// <summary>
    /// ミスタイプ時の処理
    /// </summary>
    private void Mistype() {

        // ミスタイプ数を増やす
        MisTypeNum += Input.inputString.Length;

        // 正解率の計算
        CorrectAnswerRate();

        // 打つべき文字を赤く表示(ローマ字入力候補の更新)
        UpdateSentence();
    }

    /// <summary>
    /// 苦手キーに追加する処理
    /// </summary>
    /// <param name="str">入力文字</param>
    private void MisTypeAdd(string str) {

        if (isRecMistype) {

            if (MisTypeDictionary.ContainsKey(str)) {

                MisTypeDictionary[str]++;
            }
            else {

                MisTypeDictionary.Add(str, 1);
            }
        }
    }

    /// <summary>
    /// Menu画面を開くメソッド
    /// </summary>
    private void OpenMenu() {

        // ポーズ画面でもあるのでkey入力禁止
        isInputValid = false;
        // 時間の停止
        // Menu画面を開く
    }

    /*---------- 記録計算関連 ----------*/
    /// <summary>
    /// 正解率計算処理
    /// </summary>
    private void CorrectAnswerRate() {

        Accuracy = 100f * CorrectTypeNum / (CorrectTypeNum + MisTypeNum);
    }

    /// <summary>
    /// KPM計算処理
    /// </summary>
    /// <param name="currentTime">文章入力完了時間</param>
    private void KeyPerMinute(double currentTime) {

        double sentenceTypeTime = GetSentenceTypeTime(currentTime);
    }
    /// <summary>
    /// 文章入力時間導出処理
    /// </summary>
    /// <param name="currentTime">文章入力完了時間</param>
    /// <returns>文章入力時間</returns>
    double GetSentenceTypeTime(double currentTime) {

        double ret;
        if (Math.Abs(firstCharInputTime - lastUpdateTime) <= INTERVAL) {

            Debug.Log(tasksCompleted.ToString() + " -> time:" + (currentTime - firstCharInputTime).ToString());
            ret = currentTime - firstCharInputTime;
        }
        else {

            Debug.Log(tasksCompleted.ToString() + " -> time(late):" + (currentTime - (lastUpdateTime + INTERVAL)).ToString());
            ret = currentTime - (lastUpdateTime + INTERVAL);
        }
        return ret;
    }
}
