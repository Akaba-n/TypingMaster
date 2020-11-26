using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの基底クラス
/// </summary>
public class GameDefine : MainBase {
    
    public enum GAME_STATE {   // ゲームシーンの状態(仮のSCENEのような物)
        //CONFIG,   // 設定はモード選択画面で行う
        COUNTDOWN,      // カウントダウン
        TYPING,     // タイピング部分
        RESULT      // リザルト部分
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
