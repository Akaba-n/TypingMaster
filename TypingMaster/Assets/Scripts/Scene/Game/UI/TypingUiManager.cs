using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingUiManager : MonoBehaviour {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private Text _jpText;
    [SerializeField] private Text _hrText;
    [SerializeField] private Text _rmText;

    /// <summary>
    /// プレイヤー側新規問題文表示用関数
    /// </summary>
    /// <param name="jp">日本語文</param>
    /// <param name="hr">ひらがな文</param>
    /// <param name="rm">ローマ字入力候補</param>
    public void DisplayPlayerNewText(string jp, string hr, string rm) {

        DisplayPlayerJpText(jp);
        DisplayPlayerHrText(hr);
        DisplayPlayerRmText("", rm);
    }

    /// <summary>
    /// プレイヤー側日本語文表示
    /// </summary>
    /// <param name="str">入力文字列</param>
    private void DisplayPlayerJpText(string str) {

        _jpText.text = str;
    }
    /// <summary>
    /// プレイヤー側ひらがな文表示
    /// </summary>
    /// <param name="str">入力文字列</param>
    private void DisplayPlayerHrText(string str) {

        _hrText.text = str;
    }
    /// <summary>
    /// プレイヤー側ローマ字入力候補の表示
    /// </summary>
    /// <param name="entered">入力済み文字列</param>
    /// <param name="notEntered">未入力文字列</param>
    /// <param name="misType">ミスタイプ判定</param>
    public void DisplayPlayerRmText(string entered, string notEntered, bool misType=false) {

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
