using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class PlayerNameTextController : MonoBehaviour {

    [SerializeField] private Text playerNameText;

    // プレイヤー名を表示する処理
    public void PlayerNameText() {

        playerNameText.text = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "none");
    }
}
