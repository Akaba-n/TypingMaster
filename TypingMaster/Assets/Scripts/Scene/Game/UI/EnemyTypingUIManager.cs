using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵のタイピングUI管理クラス
/// </summary>
public class EnemyTypingUIManager : TypingUIBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private EnemyTypingDataManager etd;

    /// <summary>
    /// 問題文UI表示処理
    /// </summary>
    public void DisplayEnemyText() {

        DisplayJpText(etd.td.jpSentence);
        DisplayHrText(etd.td.hrSentence);
        DisplayRmText(etd.td.enteredSentence, etd.td.notEnteredSentence);
    }
}
