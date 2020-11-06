using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームプレイ用設定変数管理クラス
/// </summary>
public class GameConfig : GameDefine {

    // 使用問題文データセット名(ローカル)
    public static string dataSetName;

    // ゲームモード
    public static GAME_MODE gameMode;

    // ゲーム難易度
    public static GAME_LEVEL gameLevel;

    // 問題数
    public static int tasks;
}
