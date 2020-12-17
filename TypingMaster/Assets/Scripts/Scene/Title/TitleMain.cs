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
    [SerializeField] private TitleNetworkManager tnm;
    [SerializeField] private PlayerData pd;

    /*----- クラス内変数の定義 -----*/
    // TitleScene内での状態変化
    public enum TITLE_STATE {

        WAIT,               // push any key(待機画面処理)
        SIGNIN_UP,          // SignIn/Up処理
        ONLINE_SECTION,     // オンライン時の処理
        OFFLINE_SECTION,    // オフライン時の処理
        CONNECTING          // 通信中(操作させない用)
    }
    public TITLE_STATE tState = TITLE_STATE.WAIT;

    // Scene切り替え時実行
    protected override void Start() {

        // 全Scene共通部
        base.Start();

        // サウンドのロード
        soundManager.Load(SoundManager.SOUND_TYPE.BGM, "bgm001");

        // サウンドの再生
        soundManager.Play(SOUND_TYPE.BGM, "bgm001", true);  // 基本BGMなのでループ

        // ゲーム開始時プレイヤーデータ格納(オンラインで整合性確認)
        pd.pd.playerId = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000");
        pd.pd.playerName = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_NAME, "GUEST");
        pd.pd.email = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_MAIL, "");
        pd.pd.pass = PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_PASS, "");
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
                    case TITLE_STATE.WAIT:
                        // キー入力が確認されたとき
                        if (Input.anyKeyDown) {

                            ///// サーバ接続確認処理 /////
                            // サーバ接続確認中はtState.CONNECTINGへ
                            // 完了したらONLINE_SESSIONとOFFLINE_SESSIONへ振り分け
                            StartCoroutine(tnm.OnlineJudge());
                        }
                        break;
                    
                    // SignIn/Up画面オープン時処理
                    case TITLE_STATE.SIGNIN_UP:
                        tUI.SignInUpFocus();
                        break;

                    // オンライン時の処理
                    case TITLE_STATE.ONLINE_SECTION:
                        // ユーザー情報未登録時
                        if (PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000") == "00000000") {

                            tUI.OpenSignInUp();
                            tState = TITLE_STATE.SIGNIN_UP;
                        }
                        // 既ログイン時
                        else {

                            StartCoroutine(tnm.SignIn(pd.pd.playerId, pd.pd.playerName, pd.pd.email, pd.pd.pass));
                        }
                        break;
                        
                    // オフライン時の処理
                    case TITLE_STATE.OFFLINE_SECTION:

                        // ユーザー情報未登録時、初期化
                        if(PlayerPrefs.GetString(PlayerPrefsKey.PLAYER_ID, "00000000") == "00000000") {

                            PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_ID, "00000000");
                            PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_NAME, "GUEST");
                            PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_MAIL, "");
                            PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_PASS, "");
                        }
                        break;

                    case TITLE_STATE.CONNECTING:

                        Debug.Log("通信中...");
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
    private void Release() {

        soundManager.Release(SoundManager.SOUND_TYPE.BGM, "bgm001");
        soundManager.Release(SoundManager.SOUND_TYPE.VOICE, "vo001");
    }
}
