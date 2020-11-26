using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 文字入力判定メソッドクラス
/// </summary>
public class OnGUIMethod : TypingDirector {
    
    /// <summary>
    /// キー入力判定をし、入力したキーをキューに格納(キー入力時自動実行)
    /// </summary>
    private void OnGUI() {

        Event e = Event.current;
        if (isInputValid && e.type == EventType.KeyDown && e.type != EventType.KeyUp && e.keyCode != KeyCode.None
        && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2)) {

            var kc = e.keyCode; // 入力されたキーコード
            if (isFirstInput) {

                firstCharInputTime = Time.realtimeSinceStartup;
                isFirstInput = false;
            }
            keyQueue.Enqueue(e.keyCode);
            timeQueue.Enqueue(Time.realtimeSinceStartup);
        }
        // ポーズ画面を開いている時
        
    }
}
