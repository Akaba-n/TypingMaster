using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの切り替え等

public class MenuMain : MainBase {

    [SerializeField] private MenuDisplayChange mc;
    [SerializeField] private ModeSelectManager ms;
    [SerializeField] private MultiModeSelectManager mms;

    // MenuScene内で表示している画面
    public enum MENU_STATE {

        MODE_SELECT,
        MULTI_MODE_SELECT
    }
    public MENU_STATE mState;

    // モードセレクト画面で選択している項目
    public enum MODE_SELECT {

        SOLO,
        MULTI
    }
    public MODE_SELECT mSelect;

    public bool isChanged = false;  // MenuScene内画面遷移判定

    //// Scene遷移時動作 ////
    protected override void Start() {

        // 全Scene共通部分
        base.Start();

        // サウンドのロード
        soundManager.Load(SoundManager.SOUND_TYPE.BGM, "bgm003");
        soundManager.Load(SoundManager.SOUND_TYPE.VOICE, "vo002");

        // サウンドの再生
        soundManager.Play(SOUND_TYPE.BGM, "bgm003");
        soundManager.Play(SOUND_TYPE.VOICE, "vo002");
    }

    private void Update() {

        switch (status) {

            // 未フェードイン時
            case SCENE_STATE.START:
                // フェードインが完了したら
                if(fadeManager.CheckFadeEnd() == true) {

                    status = SCENE_STATE.PLAY;
                }
                break;

            // Scene中動作 
            case SCENE_STATE.PLAY:
                switch (mState) {

                    // モードセレクト画面
                    case MENU_STATE.MODE_SELECT:
                        // 画面遷移時の処理
                        mc.MenuMainChange();
                        
                        ms.ModeSelectAction();
                        break;

                    case MENU_STATE.MULTI_MODE_SELECT:
                        // 画面遷移時の処理
                        mc.MenuMainChange();

                        mms.MultiModeSelectAction();
                        break;

                    default:
                        break;
                }
                break;

            case SCENE_STATE.CHANGE_WAIT:

                if(fadeManager.CheckFadeEnd() == true) {

                    // Resourceの破棄
                    Release();
                    // Sceneの切り替え
                    if(mSelect == MODE_SELECT.SOLO) {

                        SceneManager.LoadScene("SoloScene");
                    }
                    else {

                        SceneManager.LoadScene("MultiScene");
                    }
                    
                }
                break;
        }
    }

    //// MenuSceneでのみ扱うResourceの破棄メソッド ////
    private void Release() {

        // サウンドの破棄
        soundManager.Release(SOUND_TYPE.BGM, "bgm003");
        soundManager.Release(SOUND_TYPE.VOICE, "vo002");
    }
}
