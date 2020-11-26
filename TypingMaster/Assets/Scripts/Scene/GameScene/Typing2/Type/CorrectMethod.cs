using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイピング正解時動作メソッドクラス
/// </summary>
public class CorrectMethod : TypingDirector {

    [SerializeField] private UpdateSentenceMethod udSentence;

    /// <summary>
    /// タイピング正解時動作
    /// </summary>
    /// <param name="str">入力文字</param>
    /// <param name="singleN">n 一文字判定</param>
    public void Correct(string str, bool singleN) {

        // 正解タイプ数を増やす
        CorrectTypeNum++;
        // ミスタイプがあった場合に苦手キーに追加
        MisTypeAdd(str);
        isRecMistype = false;
        // 可能な入力パターンのチェック
        bool isIndexCountUp = CheckValidSentence(str, singleN);
        // ローマ字入力候補の表示を更新
        udSentence.UpdateSentence();
        if (isIndexCountUp) {

            index++;
        }
        // 文章入力完了処理
        if (index >= sentenceTyping.Count) {

            CompleteTask();
        }
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
    /// 一文が入力完了した際の処理を行うメソッド
    /// </summary>
    private void CompleteTask() {

        // 完了済み問題数の追加
        CorrectTaskNum++;
        // 完了時間の格納
        double currentTime = Time.realtimeSinceStartup;
        // 各種計測結果の計算
        // キー入力判定の初期化
        keyQueue.Clear();

        // 終了処理
        if(CorrectTaskNum >= Tasks) {

            ///// リザルトに移動などのゲーム終了処理を行う /////
        }
        else {

            ///// 次の文章に移行する処理を行う /////
        }
    }
}