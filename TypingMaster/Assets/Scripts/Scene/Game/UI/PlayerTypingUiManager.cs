using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTypingUiManager : TypingUIBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private PlayerTypingDataManager td;

    /// <summary>
    /// 問題文UI表示処理
    /// </summary>
    public void DisplayPlayerText() {

        DisplayJpText(td.jpSentence);
        DisplayHrText(td.hrSentence);
        DisplayRmText(td.enteredSentence, td.notEnteredSentence, pa.isRecMistype);
    }
}
