using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイピングゲーム管理クラス
/// </summary>
public class TypingSoft : GameDefine {

    // 入力された文字の queue
    private Queue<KeyCode> keyQueue = new Queue<KeyCode>();
    // 時刻の queue
    private Queue<double> timeQueue = new Queue<double>();


}
