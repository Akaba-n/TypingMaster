using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerActionMethod : MonoBehaviour {

    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private GameConfigClass gc;
    
    /// <summary>
    /// PlayerAction関連の初期化
    /// </summary>
    public void InitPlayerAction() {

        // 記録関連(他でも行っているから必要ないと言えば必要ない)
        pa.CorrectTypeNum = 0;
        pa.CorrectTaskNum = 0;
        pa.MisTypeNum = 0;
        pa.MisTypeDictionary = new Dictionary<string, int>();
        pa.enteredSentence = "";
        pa.notEnteredSentence = "";
        pa.SectionCorrectNum = new int[gc.gc.Tasks];
        // タイピング関連
        pa.keyQueue.Clear();        // キー格納キュー初期化
        pa.timeQueue.Clear();       // 時間格納キュー初期化
        pa.isRecMistype = false;    // ミスタイプ判定
        pa.index = 0;
        pa.acceptSingleN = false;
    }
}
