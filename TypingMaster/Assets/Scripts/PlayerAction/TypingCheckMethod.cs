using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class TypingCheckMethod : PlayerTyping {
    
    /// <summary>
    /// keyQueueにKeyCodeが格納されているかでタイピングチェックするメソッド
    /// </summary>
    public void TypingCheck() {

        // keyQueueに情報が入っている時
        while(keyQueue.Count > 0) {

            // keyQueueに入っているKeyCodeの取得(Queue.Peek()で取得、Dequeue()で取り出し)
            KeyCode kc = keyQueue.Peek();
            keyQueue.Dequeue();
            // キー入力時刻の取得
            double keyDownTime = timeQueue.Peek();
            timeQueue.Dequeue();

            // timeQueueに入っている時刻が最後に判定があった時刻より早かったら整合性が無いのでスキップ
            if (keyDownTime <= lastJudgeTime) { continue; }

            // EscKeyの場合メニュー画面を開く(中身は後で実装)
            if (kc == KeyCode.Escape) {

                ///// メニュー画面を開くメソッドを作る /////
                return;
            }
        }

        
    }

    private void MisTypeCheck(KeyCode kc) {

        bool isMistype = true;
        string str = "";

        // 全てのvalid(有効)なセンテンスに対してチェックする
        for (var i = 0; i < sentenceTyping[index].Count; ++i) {

            // validの場合
            if (sentenceValid[index][i]) {

                int j = sentenceIndex[index][i];
            }

            
        
        }
    }
}
