using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの切り替え等

public class SoloMain : MainBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GameConfigClass gc;
    [SerializeField] private SoloDisplayChange sdc;
    [SerializeField] private InitGameMethod ig;     // PlayerInitGame(Player初期化処理)
    [SerializeField] private SoloCountDownManager scd;
    [SerializeField] private GamePlayerActionManager pa;          // Playerの動作に対する挙動
    [SerializeField] private PlayerTypingDataManager ptd;          // データの操作
    [SerializeField] private PlayerTypingUiManager tUI;           // UIに対する挙動
    [SerializeField] private ConsoleUIManager cUI;

    // ゲームシーンの状態
    public enum GAME_STATE {

        INIT,       // 初期化処理(オンライン時はここで相手の準備完了を待つ)
        COUNTDOWN,  // ゲームスタートカウントダウン
        TYPING,     // タイピングゲーム部分
        RESULT      // 結果画面
    };
    public GAME_STATE gState;
    // タイピング時の状態
    public enum TYPING_STATE {

        START,      // 開始時間記録の初期化を行う
        ING,        // 
        FINISH      // 終了処理(オンライン時は全員終了まで待機する)
    }
    public TYPING_STATE tState;

    public bool isChanged;  // 画面遷移済み判定

    //// Scene遷移時動作 ////
    protected override void Start(){

        // 全Scene共通部分
        base.Start();

        // タイピングシーンの状態初期化
        gState = GAME_STATE.INIT;
        tState = TYPING_STATE.START;

        // シーン開始時はキー入力禁止
        pa.isInputValid = false;    // 入力可否判定

        isChanged = false;

        // エフェクトのロード
        //effectManager.Load("ef001");

        // サウンドのロード
        //soundManager.Load(SOUND_TYPE.BGM, "bgm002");
        //soundManager.Load(SOUND_TYPE.BGM, "bgm101");

        // サウンドの再生
        //soundManager.Play(SOUND_TYPE.BGM, "bgm002", true);
    }

    void Update() {

        if (!isChanged) {

            sdc.SoloDisplayChangeMethod();
        }

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

                    // 初期化処理
                    case GAME_STATE.INIT:

                        ig.InitSoloGame();
                        gState = GAME_STATE.COUNTDOWN;
                        isChanged = false;
                        
                        break;
                    case GAME_STATE.COUNTDOWN:

                        ///// カウントダウン処理 /////
                        scd.CountDown();
                        
                        // 遷移処理
                        if(scd.countSec < 0f) {

                            gState = GAME_STATE.TYPING;
                            isChanged = false;
                        }
                        break;
                    case GAME_STATE.TYPING:

                        switch (tState) {

                            case TYPING_STATE.START:
                                ///// 初期化処理 /////
                                ig.InitTypingStart();

                                ///// データ正規化 /////
                                ptd.SyncAllGamePlayerActionManager();

                                ///// UIへの表示 /////
                                tUI.DisplayPlayerText();
                                cUI.DisplayConsoleText();

                                tState = TYPING_STATE.ING;
                                break;

                            case TYPING_STATE.ING:

                                // 記録計算
                                ptd.RecCalc();
                                cUI.DisplayTimeText();
                                ///// プレイヤーの動作に対する挙動 /////
                                if (pa.GameSceneTypingCheck()) {

                                    if (!pa.isFinishedGame) {

                                        ///// データの正規化 /////
                                        ptd.SyncAllGamePlayerActionManager();
                                        ///// UIへの表示 /////
                                        tUI.DisplayPlayerText();
                                        cUI.DisplayConsoleText();
                                    }
                                    else {

                                        ///// データの正規化 /////
                                        ptd.SyncRecGamePlayerActionManager();
                                        //// UIへの表示 ////
                                        tUI.DisplayRmText(ptd.td.enteredSentence, ptd.td.notEnteredSentence);
                                        cUI.DisplayConsoleText();
                                        // ゲーム状態の移行
                                        tState = TYPING_STATE.FINISH;
                                    }
                                }
                                break;

                            case TYPING_STATE.FINISH:
                                cUI.DisplayConsoleText();
                                Debug.Log("TYPING_STATE->FINISH");
                                gState = GAME_STATE.RESULT;
                                isChanged = false;
                                break;
                        }
                        break;
                    case GAME_STATE.RESULT:

                        status = SCENE_STATE.CLEAR;
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
                    //SceneManager.LoadScene("ResultScene");
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
