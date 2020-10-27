using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ゲームの基底クラス */
public class AppDefine : MonoBehaviour
{
    // 最高FPSの定義(constが定義化)
    public const int MAX_FPS = 60;

    // シーンの状態
    public enum SCENE_STATE {
        START,
        PLAY,
        CLEAR,
        CHANGE_WAIT
    };

    // サウンドの種類
    public enum SOUND_TYPE {
        BGM,
        SE,
        VOICE
    };
}
