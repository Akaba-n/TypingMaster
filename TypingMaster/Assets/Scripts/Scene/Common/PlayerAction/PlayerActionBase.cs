using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全シーン共通Player動作基底クラス
/// </summary>
public class PlayerActionBase : MonoBehaviour {

    // 入力可否判定
    public bool isInputValid;
    // 入力されたキーの情報格納キュー
    public Queue<KeyCode> keyQueue = new Queue<KeyCode>();   // キーコードの格納   
    public Queue<double> timeQueue = new Queue<double>();    // 入力タイミングの格納
    // 入力されたキーを格納するList
    public List<KeyCode> keyList = new List<KeyCode>();     // そのフレームの入力キーを入力順に格納
    // 入力された際に発生する情報
    public double lastJudgeTime;     // 最後に判定が起こった時刻

    /// <summary>
    /// キー入力判定をし、入力したキーをキューに格納(キー入力の回数に合わせて1f当たりに複数回実行)
    /// </summary>
    virtual protected void OnGUI() {

        Event e = Event.current;

        // キー入力可能タイミングのみ
        if (isInputValid) {

            // キー入力時のみ
            if (e.type == EventType.KeyDown 
                && e.type != EventType.KeyUp 
                && e.keyCode != KeyCode.None
                && !Input.GetMouseButton(0) 
                && !Input.GetMouseButton(1) 
                && !Input.GetMouseButton(2)) {

                var kc = e.keyCode; // 入力されたキーコード

                keyQueue.Enqueue(e.keyCode);
                timeQueue.Enqueue(Time.realtimeSinceStartup);
            }
        }
    }
}
