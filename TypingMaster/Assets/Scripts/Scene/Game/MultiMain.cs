using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの切り替え等
using Data;

public class MultiMain : MainBase {

    /*---------- オブジェクトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GameConfigClass gc;
    [SerializeField] private CommonUIManager cUI;   // MultiGameScene内共通UI管理
    [SerializeField] private DisplayCanvasManager dc;       // MultiGame内一括Canvas管理
    [SerializeField] private InitMultiGameManager ig;     // PlayerInitGame(Player初期化処理)
    [SerializeField] private MatchingManager matchingManager;       // Maching画面での処理の一括管理
    [SerializeField] private GamePlayerActionManager pa;          // Playerの動作に対する挙動
    [SerializeField] private PlayerTypingDataManager ptd;          // データの操作
    [SerializeField] private PlayerTypingUiManager tUI;           // UIに対する挙動
    [SerializeField] private EnemyTypingDataManager etd;          // 敵データの操作
    [SerializeField] private EnemyTypingUIManager eUI;           // UIに対する挙動

    // ゲームシーンの状態
    public enum GAME_STATE {

        INIT,       // 初期化処理(オンライン時はここで相手の準備完了を待つ)
        MATCHING,   // マッチング待機画面
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

    //// Scene遷移時動作 ////
    protected override void Start(){

        // 全Scene共通部分
        base.Start();

        // タイピングシーンの状態初期化
        gState = GAME_STATE.INIT;
        tState = TYPING_STATE.START;

        // シーン開始時はキー入力禁止
        pa.isInputValid = false;    // 入力可否判定

        // ユーザー情報初期化
        ptd.td.UserId   = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000");
        ptd.td.UserName = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "");
        ptd.UserNum     = PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 1);
        ptd.roomId      = PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000");

        // サーバとのデータ同期
        ptd.UploadPlayerTypingData(ptd.UserNum, ptd.roomId);

        // エフェクトのロード
        //effectManager.Load("ef001");

        // サウンドのロード
        //soundManager.Load(SOUND_TYPE.BGM, "bgm002");
        //soundManager.Load(SOUND_TYPE.BGM, "bgm101");

        // サウンドの再生
        //soundManager.Play(SOUND_TYPE.BGM, "bgm002", true);
    }

    void Update() {
        
        // PlayerNameとRoomIdの表示
        cUI.CommonUIAll();
        

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
                        if (ig.isFirst) {

                            ig.InitGame();
                        }
                        if (ig.toMatching) {

                            gState = GAME_STATE.MATCHING;
                        }
                        
                        break;

                    // マッチング待機画面
                    case GAME_STATE.MATCHING:
                        matchingManager.Matching();
                        // 両者準備完了時
                        if (ptd.td.isReady && etd.td.isReady) {

                            // カウントダウン画面に遷移
                            gState = GAME_STATE.COUNTDOWN;
                        }
                        break;

                    case GAME_STATE.COUNTDOWN:
                        ///// カウントダウン処理 /////
                        
                        // 遷移処理
                        gState = GAME_STATE.TYPING;
                        break;

                    case GAME_STATE.TYPING:

                        switch (tState) {

                            case TYPING_STATE.START:
                                ///// 初期化処理 /////
                                ig.InitTypingStart();
                                
                                ///// データ正規化 /////
                                ptd.SyncAllGamePlayerActionManager();
                                ///// サーバにPlayerTypingDataの送信 /////
                                ptd.UploadPlayerTypingData(ptd.UserNum, ptd.roomId);

                                ///// UIへの表示 /////
                                tUI.DisplayPlayerText();

                                tState = TYPING_STATE.ING;
                                break;

                            case TYPING_STATE.ING:

                                // 記録計算
                                ptd.RecCalc();
                                ///// プレイヤーの動作に対する(プレイヤータイピング時の)挙動 /////
                                if (pa.GameSceneTypingCheck()) {

                                    // タイピング未終了時
                                    if (!pa.isFinishedGame) {

                                        ///// データの正規化 /////
                                        ptd.SyncAllGamePlayerActionManager();
                                        ///// UIへの表示 /////
                                        tUI.DisplayPlayerText();
                                    }
                                    // タイピング終了時
                                    else {

                                        // タイピング不可判定
                                        pa.isInputValid = false;
                                        ///// データの正規化 /////
                                        ptd.SyncRecGamePlayerActionManager();
                                        ///// UIへの表示 /////
                                        tUI.DisplayFinishText();
                                        // ゲーム状態の移行
                                        tState = TYPING_STATE.FINISH;
                                    }
                                    ///// サーバにPlayerTypingDataの送信 /////
                                    ptd.UploadPlayerTypingData(ptd.UserNum, ptd.roomId);
                                }
                                ///// サーバから敵データの取得 /////
                                etd.DownloadEnemyTypingData();
                                ///// 敵データの表示 /////
                                // 敵未終了時
                                if (!etd.td.isFinishedGame) {

                                    eUI.DisplayEnemyText();
                                }
                                // 敵終了時
                                else {

                                    eUI.DisplayFinishText();
                                }
                                break;

                            case TYPING_STATE.FINISH:
                                // 自分と相手の両方終了時
                                if(ptd.td.isFinishedGame && etd.td.isFinishedGame) {

                                    ///// ゲーム終了処理 /////
                                    eUI.DisplayFinishText();
                                    // リザルト画面に移動
                                    gState = GAME_STATE.RESULT;
                                }
                                // 敵の終了待ち
                                else {

                                    ///// サーバから敵データの取得 /////
                                    etd.DownloadEnemyTypingData();
                                    // 敵未終了時
                                    if (!etd.td.isFinishedGame) {

                                        eUI.DisplayEnemyText();
                                    }
                                    // 敵終了時
                                    else {

                                        eUI.DisplayFinishText();
                                    }
                                }
                                
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
