using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerRomSentence : MonoBehaviour {

    [SerializeField] private TypingDataManager td;
    [SerializeField] private GameActionManager ga;

    /// <summary>
    /// プレイヤー用のローマ字入力候補更新メソッド
    /// </summary>
    public void UpdatePlayerSentence() {

        for (int i = 0; i < ga.sentenceTyping.Count; ++i) {

            // 入力済みの文字の判定
            if(i < ga.index) {

                for(var j = 0; j < ga.sentenceTyping[i].Count; ++j) {

                    if (!ga.sentenceValid[i][j]) {

                        continue;
                    }
                    else {

                        for(var k = 0; k < ga.sentenceTyping[i][j].Length; ++k) {

                            // 入力済み文字の格納
                            td.enteredSentence += ga.sentenceTyping[i][j][k].ToString();
                        }
                    }
                }
                continue;
            }
            for(var j = 0; j < ga.sentenceTyping[i].Count; ++j) {

                // 入力中の文字の無効な文字列は飛ばす
                if (ga.index == i && !ga.sentenceValid[ga.index][j]) {

                    continue;
                }
                // 入力中の有効な文字列について
                else if(ga.index == i && ga.sentenceValid[ga.index][j]) {

                    for(var k = 0; k < ga.sentenceTyping[ga.index][j].Length; ++k) {

                        // 入力済み文字
                        if(k < ga.sentenceIndex[ga.index][j]) {

                            td.enteredSentence += ga.sentenceTyping[i][j][k].ToString();
                            continue;
                        }
                        // 未入力文字
                        else {

                            td.notEnteredSentence += ga.sentenceTyping[i][j][k].ToString();
                            continue;
                        }
                    }
                }
                // 残り
                else {

                    for(var k = 0; k < ga.sentenceTyping[i][j].Length; ++k) {

                        td.notEnteredSentence += ga.sentenceTyping[i][j][k];
                    }
                }
            }
        }
    }
}
