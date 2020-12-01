using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class PlayerActionManager : PlayerActionDirector {

    [SerializeField] private TypingCheckMethod tc;
    
    private void Awake() {

        ///// デバッグ用 /////
        PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_ID, "000000");
        PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_NAME, "waka");
        ///// ********** /////

        playerId = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "");
        playerName = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "");
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
