using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerTypingUiManager : TypingUIBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private MultiPlayerActionManager pa;
    [SerializeField] private MultiPlayerTypingDataManager ptd;

    /// <summary>
    /// 問題文UI表示処理
    /// </summary>
    public void DisplayPlayerText() {

        DisplayAnText("");
        DisplayJpText(ptd.td.jpSentence);
        DisplayHrText(ptd.td.hrSentence);
        DisplayRmText(ptd.td.enteredSentence, ptd.td.notEnteredSentence, pa.isRecMistype);
    }
}
