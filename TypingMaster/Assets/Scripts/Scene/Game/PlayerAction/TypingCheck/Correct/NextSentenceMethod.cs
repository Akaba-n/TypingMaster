using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSentenceMethod : MonoBehaviour {

    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private UpdatePlayerRomSentence ur;
    [SerializeField] private PlayerTypingUiManager tUI;
    
    /// <summary>
    /// 次の問題文に移行する処理
    /// </summary>
    public void NewSentence() {
        
        InitNextSentence();             // 文章毎変数の初期化
        ur.UpdateRomAtNewSentence();    // ローマ字入力候補の格納
    }
    /// <summary>
    /// 次の問題文に移行する際の諸々の変数の初期化
    /// </summary>
    public void InitNextSentence() {

        pa.sentenceTyping = pa.qSen[pa.CorrectTaskNum].rm;  // ローマ字入力候補の格納
        var sLength = pa.sentenceTyping.Count;              // 問題文の文字数

        // 各項目の初期化
        pa.index = 0;
        pa.sentenceIndex.Clear();
        pa.sentenceValid.Clear();
        pa.indexAdd.Clear();
        pa.sentenceIndex = new List<List<int>>();
        pa.sentenceValid = new List<List<bool>>();
        pa.indexAdd = new List<List<int>>();
        for(int i = 0; i < sLength; ++i) {

            var typeNum = pa.sentenceTyping[i].Count;   // その文字の入力候補数
            // 枠の追加
            pa.sentenceIndex.Add(new List<int>());
            pa.sentenceValid.Add(new List<bool>());
            pa.indexAdd.Add(new List<int>());
            for(var j = 0; j < typeNum; ++j) {

                // 判定追加
                pa.sentenceIndex[i].Add(0);     // 初期状態なので0文字目
                pa.sentenceValid[i].Add(true);  // 入力有効判定：true
                pa.indexAdd[i].Add(0);
            }
        }
    }
}
