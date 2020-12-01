using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内タイピング正解時実行メソッドクラス
/// </summary>
public class CorrectMethod : MonoBehaviour {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private TypingData ptd;    // PlayerTypingData
    [SerializeField] private GameActionManager ga;

    /// <summary>
    /// タイピング正解時の処理
    /// </summary>
    /// <param name="str">正解した文字</param>
    public void Correct(string str, bool singleN) {

        // 正解タイプ数を増やす
        ptd.CorrectTypeNum++;
        // 正解率の計算
        ptd.CorrectAnswerRate();
        // ミスタイプがあった場合に苦手キーに追加
        MisTypeAdd(str);
        ga.isRecMistype = false;
        // 可能な入力パターンのチェック
        bool isIndexCountUp = CheckValidSentence(str, singleN);
        // ローマ字入力候補の更新
        //UpdateSentence();
        // 可能な入力パターンがある場合
        if (isIndexCountUp) {

            // 入力文字位置を移動
            ga.index++;
        }
        // 文章入力完了処理
        if (ga.index >= ga.sentenceTyping.Count) {

            ///// 文章入力完了処理(次の文章へorリザルト画面へ) /////
        }
    }

    /// <summary>
    /// ミスタイプがあった時に苦手キーDictに追加する
    /// </summary>
    /// <param name="str">苦手文字</param>
    private void MisTypeAdd(string str) {

        if (ga.isRecMistype) {

            // 苦手キーDictに追加済みの時
            if (ptd.MisTypeDictionary.ContainsKey(str)) {

                ptd.MisTypeDictionary[str]++;
            }
            // 苦手キーDictに未追加の時
            else {

                ptd.MisTypeDictionary.Add(str, 1);
            }
        }
    }

    /// <summary>
    /// 可能な入力パターンのチェック処理
    /// </summary>
    /// <param name="str">入力文字</param>
    /// <param name="singleN">n 1文字判定</param>
    /// <returns>入力可能判定</returns>
    private bool CheckValidSentence(string str, bool singleN) {

        // 返す値の格納
        bool ret = false;
        // 例外処理フラグをfalseにする
        ga.acceptSingleN = false;
        // 可能な入力パターンを残す
        for(int i = 0; i < ga.sentenceTyping[ga.index].Count; i++) {

            // "ん"の例外処理
            if(singleN && str.Equals("n")) {

                continue;
            }
            else if(ga.indexAdd[ga.index][i] == 0 && !singleN) {

                ga.sentenceValid[ga.index][i] = false;
            }
            // "っ"の例外処理
            else if (ga.qSen[ptd.CorrectTaskNum].h[ga.index].Equals("っ")         // "っ"の時
                && ga.index + 1 < ga.sentenceTyping.Count                        // 次の文字がある時
                && ga.sentenceTyping[ga.index][i].Length == 1                    // 次の文字が母音の時
                && str.Equals(ga.sentenceTyping[ga.index][i][0].ToString())) {   // 次の文字の頭文字と同じ時

                for(int j = 0; j < ga.sentenceTyping[ga.index + 1].Count; ++j) {

                    if(!str.Equals(ga.sentenceTyping[ga.index + 1][j][0].ToString())) {

                        ga.sentenceValid[ga.index + 1][j] = false;
                    }
                }
            }
            // strと一致しないものを無効化処理
            else if (!str.Equals(ga.sentenceTyping[ga.index][i][ga.sentenceIndex[ga.index][i]].ToString())) {

                ga.sentenceValid[ga.index + 1][i] = false;
            }

            // 次のキーへ
            ga.sentenceIndex[ga.index][i] += ga.indexAdd[ga.index][i];
            // 次の文字へ
            if(ga.sentenceIndex[ga.index][i] >= ga.sentenceTyping[ga.index][i].Length) {

                if(string.Equals("n", ga.sentenceTyping[ga.index][i])) {

                    ga.acceptSingleN = true;
                }
                ret = true;
            }
        }
        return ret;
    }
}
