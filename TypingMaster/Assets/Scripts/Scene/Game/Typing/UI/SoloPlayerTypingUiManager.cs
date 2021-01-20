using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoloPlayerTypingUiManager : TypingUIBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private SoloPlayerActionManager pa;
    [SerializeField] private SoloPlayerTypingDataManager ptd;

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
