using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

/// <summary>
/// GameScene中のPlayerのアクションに対するレスポンスの管理クラス
/// </summary>
public class GameActionManager : GameActionDirector {

    [SerializeField] private GameTypingCheckMethod tc;
    [SerializeField] private TypingUiManager tUI;
    [SerializeField] private TypingDataManager td;
    [SerializeField] private InitGameMethod ig;

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

            // タイピング成否判定
            tc.MisTypeCheck(keyList[i]);
            // ローマ字入力候補更新
            td.UpdateEnteredSentence();
            tUI.DisplayRmText(td.enteredSentence, td.notEnteredSentence, isRecMistype);
        }
    }
}
