using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム設定初期化用メソッドクラス
/// </summary>
public class InitTypingMethod : TypingDirector {

    /*---------- スクリプトの読み込み(Inspectorで設定) ----------*/
    [SerializeField] private CsvImport csvImport;   // 問題文取得用
    [SerializeField] private HtoRClass htoRClass;   // 問題文生成用(ローマ字入力候補生成)


    /// <summary>
    /// 設定関連初期化メソッド
    /// </summary>
    public void InitConfig() {

        // 後で設定ファイルを参照して格納するようにする
        gameLevel = GAME_LEVEL.EASY;
        gameMode = GAME_MODE.SOLO;
        Tasks = 3;
        datasetName = "sample";
    }

    /// <summary>
    /// 各データ関連初期化メソッド
    /// </summary>
    public void InitData() {

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
    /// 問題文初期化メソッド(マルチの時はサーバ上で行う)
    /// </summary>
    public void InitQuestion() {

        // 問題データセットの取得
        var qJP = csvImport.datasetImport(datasetName);
        // 選択済み判定(問題順並び替え用)
        var pickList = new bool[qJP.Count];

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
}
