using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTypingUiManager : TypingUIBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private PlayerTypingDataManager ptd;

    /// <summary>
    /// 問題文UI表示処理
    /// </summary>
    public void DisplayPlayerText() {

        DisplayJpText(ptd.td.jpSentence);
        DisplayHrText(ptd.td.hrSentence);
        DisplayRmText(ptd.td.enteredSentence, ptd.td.notEnteredSentence, pa.isRecMistype);
    }
}
