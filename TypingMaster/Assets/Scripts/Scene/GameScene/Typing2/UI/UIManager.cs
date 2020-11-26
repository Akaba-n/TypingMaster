using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    /*---------- オブジェクトの読み込み(Inspectorで設定) ----------*/
    [SerializeField] private Text _JpText;   // 日本語文表示領域
    [SerializeField] private Text _HrText;   // ひらがな文表示領域
    [SerializeField] private Text _RmText;   // ローマ字文表示領域

    /// <summary>
    /// 現在の問題の日本語文を表示
    /// </summary>
    public void DisplayJp(string jpSen) {

        _JpText.text = jpSen;
    }
    
    /// <summary>
    /// 現在の問題のひらがな文を表示
    /// </summary>
    public void DisplayHr(string hrSen) {

        _HrText.text = hrSen;
    }

    /// <summary>
    /// 現在の問題のローマ字文を表示(入力済みは灰色)
    /// </summary>
    public void DisplayRm(string enteredSentence, string notEnteredSentence) {

        _RmText.text = "<color=#cccccc>" + enteredSentence + "</color>" + notEnteredSentence;
    }
}
