using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの基底クラス
/// </summary>
public class GameDefine : AppDefine {
    
    public enum GAME_STATE {   // ゲームシーンの状態(仮のSCENEのような物)
        CONFIG,
        MAIN,
        RESULT
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
