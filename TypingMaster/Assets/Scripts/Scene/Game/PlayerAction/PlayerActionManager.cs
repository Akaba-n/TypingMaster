using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class PlayerActionManager : PlayerActionDirector {
    
    private void Start() {

        ///// デバッグ用 /////
        PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_ID, "000000");
        PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_NAME, "waka");
        ///// ********** /////

        playerId = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "");
        playerName = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "");
    }
}
