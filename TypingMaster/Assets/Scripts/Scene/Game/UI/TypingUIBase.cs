using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingUIBase : MonoBehaviour {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    public Text _jpText;
    public Text _hrText;
    public Text _rmText;

    /// <summary>
    /// 日本語文表示
    /// </summary>
    /// <param name="str">日本語文</param>
    public void DisplayJpText(string str) {

        _jpText.text = str;
    }
    /// <summary>
    /// ひらがな文表示
    /// </summary>
    /// <param name="str">ひらがな文</param>
    public void DisplayHrText(string str) {

        _hrText.text = str;
    }

    /// <summary>
    /// ローマ字入力候補の表示
    /// </summary>
    /// <param name="entered">入力済み文字列</param>
    /// <param name="notEntered">未入力文字列</param>
    /// <param name="misType">ミスタイプ判定</param>
    public void DisplayRmText(string entered, string notEntered, bool misType=false) {

        if (!misType) {

            _rmText.text = "<color=#cccccc>" + entered + "</color>" + notEntered;
        }
        // ミスタイプ時は入力すべき文字を赤文字表示
        else {

            _rmText.text = "<color=#cccccc>" + entered + "</color><color=#ee2222>" + notEntered[0] + "</color>";
            for(var i = 1; i < notEntered.Length; i++) {

                _rmText.text += notEntered[i];
            }
        }
    }
}
