using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUIMethod : MonoBehaviour {

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
