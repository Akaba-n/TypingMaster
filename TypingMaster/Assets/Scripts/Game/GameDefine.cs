using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの基底クラス
/// </summary>
public class GameDefine : MonoBehaviour {
    
    public enum GAME_STATE {   // ゲームシーンの状態(仮のSCENEのような物)

        CONFIG,
        MAIN,
        RESULT
    };
    public enum CONNECT {       // オンライン判定(別の所で定義するかも)

        OFFLINE,
        ONLINE
    };
    public enum GAME_MODE {     // ゲームモード

        SOLO,
        MULTI
    };
    public enum GAME_LEVEL {    // ゲーム難易度

        EASY,
        NOMAL,
        LUNATIC
    };
}
