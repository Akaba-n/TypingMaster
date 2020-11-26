using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイピングゲーム部分管理クラス
/// </summary>
public class TypingManager2 : TypingDirector {

    /*---------- スクリプトの読み込み(Inspectorで設定) ----------*/
    [SerializeField] private InitTypingMethod initTyping;   // 初期化関連メソッド

    new private void Start() {

        initTyping.InitConfig();
        initTyping.InitData();
        initTyping.InitQuestion();
    }
}
