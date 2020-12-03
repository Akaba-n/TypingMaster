using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameTypingCheckMethod : MonoBehaviour {

    /*---------- オブジェクトのインスタンス作成 ----------*/
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private CorrectMethod cr;

    /// <summary>
    /// keyQueueにKeyCodeが格納されているかでタイピングチェックするメソッド(全シーン共通)
    /// </summary>
    public List<KeyCode> GameTypingCheck() {

        // 返す値の初期化
        var ret = new List<KeyCode>();

        // keyQueueに情報が入っている時
        while (pa.keyQueue.Count > 0) {

            // keyQueueに入っているKeyCodeの取得(Queue.Peek()で取得、Dequeue()で取り出し)
            KeyCode kc = pa.keyQueue.Peek();
            pa.keyQueue.Dequeue();
            // キー入力時刻の取得
            double keyDownTime = pa.timeQueue.Peek();
            pa.timeQueue.Dequeue();

            // timeQueueに入っている時刻が最後に判定があった時刻より早かったら整合性が無いのでスキップ
            if (keyDownTime <= pa.lastJudgeTime) { continue; }
            // 入力キーの確認(デバッグ用)
            Debug.Log(kc);

            ret.Add(kc);
        }
        return ret;
    }


    /// <summary>
    /// escキーが押された場合に目―ニュー画面を開くメソッド
    /// </summary>
    /// <param name="kc"></param>
    public void OpenMenu(KeyCode kc) {

        // EscKeyの場合メニュー画面を開く(中身は後で実装)
        if (kc == KeyCode.Escape) {

            ///// メニュー画面を開くメソッドを作る /////
            // SOLOモードの時開く
            return;
            // MULTIモードの時開かない
            return;
        }
    }

    /// <summary>
    /// ミスタイプかどうかを判定するメソッド
    /// </summary>
    /// <param name="kc">入力されたキーのキーコード</param>
    public void MisTypeCheck(KeyCode kc) {

        bool isMistype = true;
        string str = "";

        // 全てのvalid(有効)なセンテンスに対してチェックする
        for (var i = 0; i < pa.sentenceTyping[pa.index].Count; ++i) {

            // validの場合
            if (pa.sentenceValid[pa.index][i]) {

                int j = pa.sentenceIndex[pa.index][i];
                KeyCode nextKC = GetKeyCode(pa.sentenceTyping[pa.index][i][j]);
            
                // "ん"の処理処理(n1個でもokの時に2個目のnが来た時の例外処理)
                if(pa.acceptSingleN && KeyCode.N == kc) {

                    isMistype = false;
                    pa.indexAdd[pa.index][i] = 0;
                    str = "n";
                }
                // 正解タイピング時
                else if(kc == nextKC) {

                    isMistype = false;
                    pa.indexAdd[pa.index][i] = 1;
                    str = pa.sentenceTyping[pa.index][i][j].ToString();
                }
                // 不正解タイピング時
                else {

                    pa.indexAdd[pa.index][i] = 0;
                }
            }

            if (!isMistype) {

                ///// 正解タイプ時処理 /////
                cr.Correct(str, pa.acceptSingleN);
            }
            else {

                ///// 不正解タイプ時処理 /////
            }
        }
    }

    /// <summary>
    /// 文字をキーコードに変換するメソッド
    /// </summary>
    /// <param name="c">文字</param>
    /// <returns>キーコード</returns>
    private KeyCode GetKeyCode(char c)  {

        if ('.' == c) {

            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Period");
        }
        else if (',' == c) {

            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Comma");
        }
        else if ('-' == c) {

            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Minus");
        }
        else if ('0' - '0' <= c - '0' && c - '0' <= '9' - '0') {

            return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + c.ToString());
        }
        else if ('a' - 'a' <= c - 'a' && c - 'a' <= 'z' - 'a') {

            return (KeyCode)System.Enum.Parse(typeof(KeyCode), c.ToString().ToUpper());
        }
        return KeyCode.None;
    }
}
