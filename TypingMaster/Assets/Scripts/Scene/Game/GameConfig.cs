using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム設定管理クラス
/// </summary>
public class GameConfig : MonoBehaviour {
    
    // ゲームモード
    public enum GAME_MODE {

        SOLO,       // ソロモード
        MULTI,      // マルチモード
        CONTEST     // // 大会モード(実装出来たら)
    };
    public GAME_MODE gMode;
    // 問題数
    public int Tasks;
    // データセット名
    public string DatasetName;

    // 初期化処理
    private void Awake() {

        ///// デバッグ用 /////
        gMode = GAME_MODE.MULTI;
        Tasks = 2;
        DatasetName = "sample";
    }
}
