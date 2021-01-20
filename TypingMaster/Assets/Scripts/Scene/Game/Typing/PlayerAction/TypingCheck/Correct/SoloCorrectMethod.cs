using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム内タイピング正解時実行メソッドクラス
/// </summary>
public class SoloCorrectMethod : MonoBehaviour {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GameConfigClass gc;
    [SerializeField] private SoloPlayerActionManager pa;
    [SerializeField] private SoloNextSentenceMethod ns;
    [SerializeField] private SoloUpdatePlayerRomSentence ur;

    /// <summary>
    /// タイピング正解時の処理
    /// </summary>
    /// <param name="str">正解した文字</param>
    public void Correct(string str, bool singleN) {

        // 正解タイプ数を増やす
        pa.CorrectTypeNum++;
        pa.SectionCorrectNum[pa.CorrectTaskNum]++;
        // ミスタイプがあった場合に苦手キーに追加
        MisTypeAdd(str);
        pa.isRecMistype = false;
        // 可能な入力パターンのチェック
        bool isIndexCountUp = CheckValidSentence(str, singleN);
        // ローマ字入力候補の更新
        ur.UpdateRom(str);
        // 可能な入力パターンがある場合
        if (isIndexCountUp) {

            // 入力文字位置を移動
            pa.index++;
        }
        // 文章入力完了処理
        if (pa.index >= pa.sentenceTyping.Count) {

            ///// 文章入力完了処理(次の文章へorリザルト画面へ) /////
            CompleteTask();
        }
    }

    /// <summary>
    /// 文章入力完了処理
    /// </summary>
    private void CompleteTask() {

        // 完了済み問題数の追加
        pa.CorrectTaskNum++;
        double currentTime = Time.realtimeSinceStartup; // 完了時間の保存
        // KPMの計算
        //KeyPerMinute(currentTime);
        pa.keyQueue.Clear();

        // 終了処理
        if (pa.CorrectTaskNum >= gc.gc.Tasks){

            ///// リザルト画面に飛ぶ処理 /////
            Debug.Log("tState.ING->FINISH");
            pa.isFinishedGame = true;
        }
        else {

            // 次の文章へ移行
            ns.NewSentence();
        }
    }

    /// <summary>
    /// ミスタイプがあった時に苦手キーDictに追加する
    /// </summary>
    /// <param name="str">苦手文字</param>
    private void MisTypeAdd(string str) {

        if (pa.isRecMistype) {

            // 苦手キーDictに追加済みの時
            if (pa.MisTypeDictionary.ContainsKey(str)) {

                pa.MisTypeDictionary[str]++;
            }
            // 苦手キーDictに未追加の時
            else {

                pa.MisTypeDictionary.Add(str, 1);
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
        pa.acceptSingleN = false;
        // 可能な入力パターンを残す
        for(int i = 0; i < pa.sentenceTyping[pa.index].Count; i++) {

            // "ん"の例外処理
            if(singleN && str.Equals("n")) {

                continue;
            }
            else if(pa.indexAdd[pa.index][i] == 0 && !singleN) {

                pa.sentenceValid[pa.index][i] = false;
            }
            // "っ"の例外処理
            else if (pa.qSen[pa.CorrectTaskNum].h[pa.index].Equals("っ")         // "っ"の時
                && pa.index + 1 < pa.sentenceTyping.Count                        // 次の文字がある時
                && pa.sentenceTyping[pa.index][i].Length == 1                    // 次の文字が母音の時
                && str.Equals(pa.sentenceTyping[pa.index][i][0].ToString())) {   // 次の文字の頭文字と同じ時

                for(int j = 0; j < pa.sentenceTyping[pa.index + 1].Count; ++j) {

                    if(!str.Equals(pa.sentenceTyping[pa.index + 1][j][0].ToString())) {

                        pa.sentenceValid[pa.index + 1][j] = false;
                    }
                }
            }
            // strと一致しないものを無効化処理
            else if (!str.Equals(pa.sentenceTyping[pa.index][i][pa.sentenceIndex[pa.index][i]].ToString())) {

                pa.sentenceValid[pa.index + 1][i] = false;
            }

            // 次のキーへ
            pa.sentenceIndex[pa.index][i] += pa.indexAdd[pa.index][i];
            // 次の文字へ
            if(pa.sentenceIndex[pa.index][i] >= pa.sentenceTyping[pa.index][i].Length) {

                if(string.Equals("n", pa.sentenceTyping[pa.index][i])) {

                    pa.acceptSingleN = true;
                }
                ret = true;
            }
        }
        return ret;
    }
}
