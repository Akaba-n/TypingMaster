using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerRomSentence : MonoBehaviour {
    
    [SerializeField] private GamePlayerActionManager pa;

    /// <summary>
    /// プレイヤー用のローマ字入力候補更新メソッド
    /// </summary>
    public void UpdatePlayerSentence() {

        for (int i = 0; i < pa.sentenceTyping.Count; ++i) {

            // 入力済みの文字について
            if(i < pa.index) {

                for(var j = 0; j < pa.sentenceTyping[i].Count; ++j) {

                    if (!pa.sentenceValid[i][j]) {

                        continue;
                    }
                    else {

                        for(var k = 0; k < pa.sentenceTyping[i][j].Length; ++k) {

                            // 入力済み文字の格納
                            pa.enteredSentence += pa.sentenceTyping[i][j][k].ToString();
                        }
                    }
                }
                continue;
            }
            // 入力中の文字について
            else if (pa.index == i) {

                for (var j = 0; j < pa.sentenceTyping[i].Count; ++j) {

                    if (!pa.sentenceValid[pa.index][j]) {

                        continue;
                    }
                    else {

                        for (var k = 0; k < pa.sentenceTyping[pa.index][j].Length; ++k) {

                            // 入力済み文字
                            if(k < pa.sentenceIndex[pa.index][j]) {

                                pa.enteredSentence += pa.sentenceTyping[i][j][k].ToString();
                                continue;
                            }
                            // 未入力文字
                            else {

                                pa.notEnteredSentence += pa.sentenceTyping[i][j][k].ToString();
                                continue;
                            }
                        }
                    }
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
