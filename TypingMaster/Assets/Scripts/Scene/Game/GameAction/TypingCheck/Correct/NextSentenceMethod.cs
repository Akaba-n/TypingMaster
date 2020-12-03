using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSentenceMethod : MonoBehaviour {

    [SerializeField] private GameActionManager ga;
    [SerializeField] private TypingDataManager td;
    
    /// <summary>
    /// 次の問題文に移行する処理
    /// </summary>
    public void NextSentence() {

        td.CorrectTaskNum++;        // 正解済み問題数を増やす
        InitNextSentence();         // 文章毎変数の初期化
    }
    /// <summary>
    /// 次の問題文に移行する際の諸々の変数の初期化
    /// </summary>
    public void InitNextSentence() {

        ga.sentenceTyping = ga.qSen[td.CorrectTaskNum].rm;  // ローマ字入力候補の格納
        var sLength = ga.sentenceTyping.Count;              // 問題文の文字数

        // 各項目の初期化
        ga.index = 0;
        ga.sentenceIndex.Clear();
        ga.sentenceValid.Clear();
        ga.indexAdd.Clear();
        ga.sentenceIndex = new List<List<int>>();
        ga.sentenceValid = new List<List<bool>>();
        ga.indexAdd = new List<List<int>>();
        for(int i = 0; i < sLength; ++i) {

            var typeNum = ga.sentenceTyping[i].Count;   // その文字の入力候補数
            // 枠の追加
            ga.sentenceIndex.Add(new List<int>());
            ga.sentenceValid.Add(new List<bool>());
            ga.indexAdd.Add(new List<int>());
            for(var j = 0; j < typeNum; ++j) {

                // 判定追加
                ga.sentenceIndex[i].Add(0);     // 初期状態なので0文字目
                ga.sentenceValid[i].Add(true);  // 入力有効判定：true
                ga.indexAdd[i].Add(0);
            }
        }
    }
}
