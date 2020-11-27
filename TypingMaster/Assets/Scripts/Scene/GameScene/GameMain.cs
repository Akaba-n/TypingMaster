﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの切り替え等

public class GameMain : GameDefine {

    [SerializeField] Camera mainCamera = null;

    // タイピング部分の状態遷移管理
    public static GAME_STATE gState;

    //// Scene遷移時動作 ////
    protected override void Start(){

        // 全Scene共通部分
        base.Start();

        // エフェクトのロード
        effectManager.Load("ef001");

        // サウンドのロード
        soundManager.Load(SOUND_TYPE.BGM, "bgm002");
        soundManager.Load(SOUND_TYPE.BGM, "bgm101");

        // サウンドの再生
        soundManager.Play(SOUND_TYPE.BGM, "bgm002", true);
    }

    void Update() {

        switch (status) {

            // 未フェードイン時(シーン遷移時)
            case SCENE_STATE.START:
                
                if(fadeManager.CheckFadeEnd() == true) {

                    status = SCENE_STATE.PLAY;
                }
                break;

            // シーン中動作
            case SCENE_STATE.PLAY:

                switch (gState) {
                    case GAME_STATE.COUNTDOWN:
                        break;
                    case GAME_STATE.TYPING:
                        break;
                    case GAME_STATE.RESULT:
                        break;
                }
                break;

            // ゲームクリア時
            case SCENE_STATE.CLEAR:

                // ファンファーレが鳴り終わった時
                if(soundManager.IsPlayBGM() == false) {

                    fadeManager.FadeOutPlay();
                    status = SCENE_STATE.CHANGE_WAIT;
                }
                break;

            // Scene遷移待機時
            case SCENE_STATE.CHANGE_WAIT:

                if(fadeManager.CheckFadeEnd() == true) {

                    // GameScene用サウンドの破棄
                    Release();
                    // Scene遷移
                    SceneManager.LoadScene("ResultScene");
                }
                break;
        }

        //// GameSceneでのみ扱うResourceの破棄メソッド ////
        void Release() {

            soundManager.Release(SoundManager.SOUND_TYPE.BGM, "bgm002");
            soundManager.Release(SoundManager.SOUND_TYPE.BGM, "bgm101");

            // CreateEffectで生成したEffectの全消去
            effectManager.AllDestroyEffect();
            effectManager.Release("ef001");
        }
    }
}