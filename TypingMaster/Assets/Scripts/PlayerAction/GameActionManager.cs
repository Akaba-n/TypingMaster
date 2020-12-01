using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class GameActionManager : GameActionDirector {
    
    /// <summary>
    /// スクリプト起動時最初に行われる(初期化)
    /// </summary>
    protected override void Awake() {

        // PlayerActionDirectorで設定している共通部分
        base.Awake();
    }

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
        keyList = tc.TypingCheck();
        // キー入力があった時の処理
        for(var i = 0; keyList.Count < i; i++) {


        }
    }
}
