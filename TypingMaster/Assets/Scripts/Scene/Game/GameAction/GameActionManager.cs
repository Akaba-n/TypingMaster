using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class GameActionManager : GameActionDirector {

    [SerializeField] private GameTypingCheckMethod tc;

    /// <summary>
    /// プレイヤー動作時に作動
    /// </summary>
    protected override void OnGUI() {

        // キー入力時にそのキーをキューに保管する
        base.OnGUI();
    }

    /// <summary>
    /// ゲームシーンでのタイピングチェック
    /// </summary>
    public void GameSceneTypingCheck() {

        // そのフレーム(前のフレーム？)の入力キーを格納
        keyList = tc.GameTypingCheck();
        // キー入力があった時の処理
        for(var i = 0; keyList.Count < i; i++) {

            tc.MisTypeCheck(keyList[i]);
        }
    }


}
