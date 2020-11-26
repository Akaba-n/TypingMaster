using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイピングチェックメソッドクラス
/// </summary>
public class TypingCheckMethod : TypingDirector {

    /*---------- オブジェクトの読み込み(Inspectorで設定) ----------*/
    [SerializeField] private GetKeyCodeMethod getKeyCode;   // キーコードへの変換
    [SerializeField] private RecordCalculationMethods recCalc;  // 記録計測関連
    [SerializeField] private CorrectMethod cr;

    /// <summary>
    /// タイピングチェックメソッド
    /// </summary>
    private void TypingCheck() {

        while (keyQueue.Count > 0) {

            // keyQueueに入っているkeycodeの取得(Queue.Peek()は読み込み、Dequeue()は取り出し)
            KeyCode kc = keyQueue.Peek();
            keyQueue.Dequeue();
            double keyDownTime = timeQueue.Peek();
            timeQueue.Dequeue();

            if (keyDownTime <= lastJudgeTime) {

                continue;
            }

            // まだ可能性のあるセンテンス全てに対してミスタイプかチェックする
            bool isMistype = true;
            string str = "";
            // EscKeyの場合メニュー画面を開く(中身は後で実装)
            if (kc == KeyCode.Escape) {

                ///// オプション開くメソッド作る /////
                break;
            }
            // 全てのvalidなセンテンスに対してチェックする
            for (var i = 0; i < sentenceTyping[index].Count; ++i) {

                // invalidならパス
                if (!sentenceValid[index][i]) {

                    continue;
                }

                // validの場合
                int j = sentenceIndex[index][i];
                KeyCode nextKC = getKeyCode.GetKeycode(sentenceTyping[index][i][j]);   // 次にタイピングする文字を取得
                // "ん"の処理(n1個でもokの時に2個目のnが来た時の例外処理)
                if (acceptSingleN && KeyCode.N == kc) {

                    isMistype = false;
                    indexAdd[index][i] = 0;
                    str = "n";
                }
                // 正解タイプ時
                else if (kc == nextKC) {

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
                cr.Correct(str, acceptSingleN);
            }
            else {

                // ミスタイプ時処理
                Mistype();
            }

            // 正解率の計算
            recCalc.CorrectAnswerRate(CorrectTypeNum, MisTypeNum);
        }
    }


}
