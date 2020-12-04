using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerRomSentence : MonoBehaviour {
    
    [SerializeField] private GamePlayerActionManager pa;

    /// <summary>
    /// タイピング正解時にenteredSentenceとnotEnteredSentenceの更新を行う処理
    /// </summary>
    /// <param name="str">正解文字</param>
    public void UpdateRom(string str) {

        pa.enteredSentence += str;
        UpdateNotEnteredSentence();
    }
    /// <summary>
    /// 新しい問題文に移行する時にenteredSentenceとnotEnteredSentenceの更新を行う処理
    /// </summary>
    public void UpdateRomAtNewSentence() {

        pa.enteredSentence = "";
        UpdateNotEnteredSentence();
    }

    /// <summary>
    /// プレイヤー用の未入力ローマ字入力候補(notEnteredSentence)更新メソッド
    /// </summary>
    private void UpdateNotEnteredSentence() {
        
        pa.notEnteredSentence = "";

        for (int i = 0; i < pa.sentenceTyping.Count; ++i) {     // (ひらがな)何文字目

            // 入力済みの文字について
            if(i < pa.index) {
                
                continue;
            }
            // 入力中の文字について
            else if (pa.index == i) {

                for (var j = 0; j < pa.sentenceTyping[i].Count; ++j) {      // (候補)何枠目

                    // 入力した文字に対して無効な候補
                    if (!pa.sentenceValid[pa.index][j]) {

                        continue;
                    }
                    // 有効な候補の一つ目のみを参照
                    else {

                        for(var k = 0; k < pa.sentenceTyping[pa.index][j].Length; ++k) {

                            if(k >= pa.sentenceIndex[pa.index][j]) {

                                pa.notEnteredSentence += pa.sentenceTyping[i][j][k].ToString();
                            }
                        }
                    }
                    break;
                }
            }
            // 未入力の文字について
            else {

                for(var j = 0; j < pa.sentenceTyping[i][0].Length; ++j) {

                    pa.notEnteredSentence += pa.sentenceTyping[i][0][j].ToString();
                }
            }
        }
    }
}
