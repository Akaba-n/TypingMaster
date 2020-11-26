using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSentenceMethod : TypingDirector {

    [SerializeField] private UIManager uiManager;
    
    public void UpdateSentence() {

        // 表示する文字の初期化
        enteredSentence = "";
        notEnteredSentence = "";

        for(int i = 0; i < sentenceTyping.Count; ++i) {

            // 入力済み文章の判定
            if(i < index) {

                for (var j = 0; j < sentenceTyping[i].Count; ++j) {

                    // 入力した文章でなかった時
                    if (!sentenceValid[i][j]) {

                        continue;
                    }
                    // 入力した文章の時
                    else {

                        for (var k = 0; k < sentenceTyping[i][j].Length; ++k) {

                            // 入力済み文字の格納
                            enteredSentence += sentenceTyping[i][j][k].ToString();
                        }
                    }
                }
                continue;
            }
            for(var j = 0; j < sentenceTyping[i].Count; ++j) {
                
                // 入力途中の文章について
                if(index == i) {

                    // 入力しなかった文字候補の時
                    if (!sentenceValid[index][j]) {

                        continue;
                    }
                    // 入力したor今後有効な文字候補の時
                    else if (sentenceValid[index][j]) {

                        for (var k = 0; k < sentenceTyping[index][j].Length; ++k) {

                            // 入力済みの文字まで
                            if (k <= sentenceIndex[index][j]) {

                                enteredSentence += sentenceTyping[index][j][k].ToString();
                            }
                            else if(k == sentenceIndex[index][j] && isRecMistype) {

                                notEnteredSentence += "<color=#ff0000ff>" + sentenceTyping[index][j][k].ToString() + "</color>";
                            }
                            else {

                                notEnteredSentence += sentenceTyping[index][j][k].ToString();
                            }

                        }
                    }
                    break;
                }
                else if(index != i && sentenceValid[i][j]) {

                    notEnteredSentence += sentenceTyping[index][j][k].ToString();
                    break;
                }
            }
        }

        // UIへ表示
        uiManager.DisplayRm(enteredSentence, notEnteredSentence);
    }
}
