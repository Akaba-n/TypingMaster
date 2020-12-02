using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionManager : PlayerActionBase {

    public TypingCheckMethod tc;

    private void Awake() {

        tc = new TypingCheckMethod();
    }

    /// <summary>
    /// プレイヤー動作時に作動
    /// </summary>
    protected override void OnGUI() {

        // キー入力時にそのキーをキューに保管する
        base.OnGUI();
    }
}
