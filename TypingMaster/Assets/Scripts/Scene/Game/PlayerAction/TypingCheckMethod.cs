using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingCheckMethod : MonoBehaviour {

    /*---------- オブジェクトのインスタンス作成 ----------*/
    [SerializeField] private PlayerActionManager pa;
    
    /// <summary>
    /// keyQueueにKeyCodeが格納されているかでタイピングチェックするメソッド
    /// </summary>
    public List<KeyCode> TypingCheck() {

        // 返す値の初期化
        var ret = new List<KeyCode>();

        // keyQueueに情報が入っている時
        while(pa.keyQueue.Count > 0) {

            // keyQueueに入っているKeyCodeの取得(Queue.Peek()で取得、Dequeue()で取り出し)
            KeyCode kc = pa.keyQueue.Peek();
            pa.keyQueue.Dequeue();
            // キー入力時刻の取得
            double keyDownTime = pa.timeQueue.Peek();
            pa.timeQueue.Dequeue();

            // timeQueueに入っている時刻が最後に判定があった時刻より早かったら整合性が無いのでスキップ
            if (keyDownTime <= pa.lastJudgeTime) { continue; }

            // EscKeyの場合メニュー画面を開く(中身は後で実装)
            if (kc == KeyCode.Escape) {

                ///// メニュー画面を開くメソッドを作る /////
                return null;
            }

            ret.Add(kc);
        }
        return ret;
    }

    private void MisTypeCheck(KeyCode kc) {

        bool isMistype = true;
        string str = "";

        // 全てのvalid(有効)なセンテンスに対してチェックする
        for (var i = 0; i < pa.sentenceTyping[pa.index].Count; ++i) {

            // validの場合
            if (pa.sentenceValid[pa.index][i]) {

                int j = pa.sentenceIndex[pa.index][i];
            }

            
        
        }
    }
}
