using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの切り替え等
using Data;

/*
【TitleSceneの流れ】
 TitleScene表示
 ↓
 enter any key
 ↓
 (PlayerPrefs)ユーザー情報確認(userId,userName,password)(未登録の場合は登録画面,userIdは00000000にしておく)
 ↓
 (サーバ接続:https)ユーザー情報確認(未登録の場合はuserId割り当て)
 ↓
*/

/// <summary>
/// TitleSceneでの基本動作クラス
/// </summary>
public class TitleMain : MainBase {

    /*----- クラスのインスタンス化(Isnpectorで設定) -----*/
    [SerializeField] private TitleUIManager tUI;

    /*----- クラス内変数の定義 -----*/
    // TitleScene内での状態変化
    private enum TITLE_STATE {

        START,
        SIGNIN_UP,
        ONLINE_SECTION,
        OFFLINE_SECTION
    }
    private TITLE_STATE tState = TITLE_STATE.START;

    // Scene切り替え時実行
    protected override void Start() {

        // 全Scene共通部
        base.Start();

        // サウンドのロード
        soundManager.Load(SoundManager.SOUND_TYPE.BGM, "bgm001");
        soundManager.Load(SoundManager.SOUND_TYPE.VOICE, "vo001");

        // サウンドの再生
        soundManager.Play(SOUND_TYPE.BGM, "bgm001", true);  // 基本BGMなのでループ
        soundManager.Play(SOUND_TYPE.VOICE, "vo001");
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

                // push any key時点
                switch (tState) {

                    // push any key時の処理
                    case TITLE_STATE.START:
                        // キー入力が確認されたとき
                        if (Input.anyKeyDown) {

                            ///// ユーザー確認処理(PlayerPrefs) /////
                            // オンライン時処理
                            if (networkManager.judgeConnecting()) {

                                Debug.Log("ConnectionStatus：Online");
                                tState = TITLE_STATE.ONLINE_SECTION;
                            }
                            // オフライン時処理
                            else {

                                Debug.Log("ConnectionStatus：Offline");
                                tState = TITLE_STATE.OFFLINE_SECTION;
                            }
                        }
                        break;
                    
                    // SignIn/Up画面オープン時処理
                    case TITLE_STATE.SIGNIN_UP:
                        tUI.SignInUpFocus();
                        break;

                    // オンライン時の処理
                    case TITLE_STATE.ONLINE_SECTION:
                        // 未ログイン時
                        if (PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_MAIL, "") == "") {

                            ///// ログイン or 新規登録処理 /////
                            tState = TITLE_STATE.SIGNIN_UP;
                            tUI.OpenSignInUp();
                        }
                        else {

                            ///// オンライン整合性判定 /////
                            tState = TITLE_STATE.ONLINE_SECTION;
                        }
                        break;
                        
                    // オフライン時の処理
                    case TITLE_STATE.OFFLINE_SECTION:
                        // 未ログイン時
                        if (PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_MAIL, "") == "") {

                            ///// ゲスト扱い処理 /////
                            PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_ID, "00000000");
                            PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_NAME, "Guest");
                        }
                        else {

                            ///// ユーザーログイン処理(要らないかも) /////
                        }
                        break;

                    default:
                        break;
                }
                
                break;


            // シーン遷移待ち状態
            case SCENE_STATE.CHANGE_WAIT:

                // フェード終了時
                if(fadeManager.CheckFadeEnd() == true) {

                    // サウンドの破棄
                    Release();
                    // Sceneの遷移
                    SceneManager.LoadScene("GameScene");
                }
                break;

            default:
                break;
        }
    }

    //// TitleSceneでのみ扱うResourceの破棄メソッド ////
    void Release() {

        soundManager.Release(SoundManager.SOUND_TYPE.BGM, "bgm001");
        soundManager.Release(SoundManager.SOUND_TYPE.VOICE, "vo001");
    }
}
