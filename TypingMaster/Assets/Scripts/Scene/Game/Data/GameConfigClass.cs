using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム設定管理クラス
/// </summary>
public class GameConfigClass : MonoBehaviour {
    
    // ゲームモード
    public enum GAME_MODE {

        SOLO,       // ソロモード
        MULTI,      // マルチモード
        CONTEST     // // 大会モード(実装出来たら)
    };
    public GAME_MODE gMode;
    [System.Serializable]
    public class GameConfig {

        // 問題数
        public int Tasks;
        // データセット名
        public string DatasetName;
    }

    public GameConfig gc = new GameConfig();

    // 初期化処理
    private void Awake() {

        ///// デバッグ用 /////
        gMode = GAME_MODE.MULTI;
        gc.Tasks = 2;
        gc.DatasetName = "sample";
    }
}
