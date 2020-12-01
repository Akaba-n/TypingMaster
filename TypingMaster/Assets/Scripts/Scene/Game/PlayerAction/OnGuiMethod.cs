using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGuiMethod : MonoBehaviour {

    [SerializeField] private PlayerActionManager pa;

    /// <summary>
    /// キー入力判定をし、入力したキーをキューに格納(キー入力の回数に合わせて1f当たりに複数回実行)
    /// </summary>
    private void OnGUI() {

        Event e = Event.current;

        // キー入力可能タイミングのみ
        if (pa.isInputValid) {
            
            // キー入力時のみ
            if (e.type == EventType.KeyDown && e.type != EventType.KeyUp && e.keyCode != KeyCode.None
            && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2)) {
                
                var kc = e.keyCode; // 入力されたキーコード

                pa.keyQueue.Enqueue(e.keyCode);
                pa.timeQueue.Enqueue(Time.realtimeSinceStartup);
            }
        }

    }
}
