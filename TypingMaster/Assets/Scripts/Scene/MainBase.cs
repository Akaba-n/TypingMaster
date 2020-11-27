using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* シーン操作の基底クラス */
public class MainBase : AppDefine {

    // システムマネージャーのインスタンスの格納
    //public SystemManager    systemManager   = null;
    public static SoundManager     soundManager    = null;
    public static FadeManager      fadeManager     = null;
    public static EffectManager    effectManager   = null;
    public static DebugManager     debugManager    = null;

    public SCENE_STATE status = SCENE_STATE.START;

    //// Scene遷移時に実行される想定の仮想関数 ////
    // 基底クラスで予め宣言するというもの
    // 派生クラスでオーバーライド(サブクラスでスーパークラスのメソッドを上書き)する事が可能
    // ここでは各SceneのメインクラスのStart()の初めにこのクラスで宣言したStart()を実行してからオーバーライド分を実行しているのでこれで宣言している
    // protected(メンバーアクセス修飾子)：protectedメンバは、そのクラス内部と派生クラスのインスタンスからアクセス出来る
    virtual protected void Start() {

        // 各システムマネージャーのインスタンスを格納
        //systemManager   = GameObject.Find("SystemManager").GetComponent<SystemManager>();
        soundManager    = SystemManager.instance.soundManager;
        fadeManager     = SystemManager.instance.fadeManager;
        effectManager   = SystemManager.instance.effectManager;
        debugManager    = SystemManager.instance.debugManager;

        // 待機状態から始める
        status = SCENE_STATE.START;

        fadeManager.FadeInPlay();
    }
}
