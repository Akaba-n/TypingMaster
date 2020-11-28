using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingCheckMethod : TypingDirector {
    
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
        }

        
    }
}
