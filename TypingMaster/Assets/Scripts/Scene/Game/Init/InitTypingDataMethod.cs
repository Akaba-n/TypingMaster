using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TypingData関連初期化メソッド(Enemyも出来るように)
/// </summary>
public class InitTypingDataMethod : MonoBehaviour {

    /*----------  ----------*/
    [SerializeField] private TypingData td;

    /// <summary>
    /// TypingData関連初期化メソッド
    /// </summary>
    public void InitTypingData() {

        td.CorrectTypeNum = 0;
        td.CorrectTaskNum = 0;
        td.MisTypeNum = 0;
        td.TotalTypingTime = 0f;
        td.Kpm = 0f;
        td.Accuracy = 0f;
        td.MisTypeDictionary = new Dictionary<string, int>();
    }
}
