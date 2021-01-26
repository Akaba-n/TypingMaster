using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiResultManager : MonoBehaviour {

    /*----- Script取得(Inspectorで設定) -----*/
    [SerializeField] private MultiResultUIManager rUI;
    [SerializeField] private MultiResultPlayerActionManager rpa;
    [SerializeField] private MultiResultNetworkManager rnw;
    [SerializeField] private MultiMain mm;
    [SerializeField] private EnemyTypingDataManager etd;

    // リザルト画面の状態遷移
    public enum RESUTL_STATE {

        NONE,           // 最初
        STATE1,         // 結果表示1
        STATE2,         // 結果表示1
        STATE3,         // 結果表示1
        STATE4,         // 結果表示1
        STATE5,         // 結果表示1
        WL_WAIT,        // 画面遷移待機
        WL_JUDGE,       // 勝敗表示
        SELECT_WAIT,    // リトライ選択待機(入力ミス回避用)
        RETRY_SELECT,   // リトライ選択
        ENEMY_WAIT,     // 対戦相手リトライ選択待機 
        RETRY_FAILED,   // 対戦相手リトライ破棄時
        CONNECTING      // 通信中処理
    }
    public RESUTL_STATE rState;

    // リザルト画面でのリトライ選択
    public enum RESULT_SELECT {

        YES,
        NO
    }
    public RESULT_SELECT rSelect;

    // 状態遷移用時間計測変数
    public float time;
    private float distanceTime;
    // 状態遷移判定
    public bool isChange;
    // 入力可否判定
    public bool isInputValid;

    private void Start() {

        time = 0f;
        distanceTime = 0.5f;
        isChange = false;
        isInputValid = true;
        rState = RESUTL_STATE.STATE1;
        rSelect = RESULT_SELECT.YES;
    }
    
    /// <summary>
    /// MultiモードでのResult画面処理
    /// </summary>
    public void MultiResult() {

        // 状態遷移
        ResultStateChange();

        ///// PlayerAction処理 /////
        rpa.ResultPlayerAction();

        // 状態遷移時処理
        if (!isChange) {

            rUI.DisplayChange();
            time = 0f;
            isChange = true;
        }

        ///// Network処理 /////
        rnw.ResultNetwork();

        ///// UI管理 /////
        rUI.MultiResultUI();
    }

    /// <summary>
    /// Result画面での自動状態遷移処理
    /// </summary>
    private void ResultStateChange() {
        // 一定時間経過時
        if(time > distanceTime) {

            switch (rState) {

                case RESUTL_STATE.NONE:
                    rState = RESUTL_STATE.STATE1;
                    isChange = false;
                    break;

                case RESUTL_STATE.STATE1:       
                    rState = RESUTL_STATE.STATE2;
                    isChange = false;
                    break;

                case RESUTL_STATE.STATE2:
                    rState = RESUTL_STATE.STATE3;
                    isChange = false;
                    break;

                case RESUTL_STATE.STATE3:
                    rState = RESUTL_STATE.STATE4;
                    isChange = false;
                    break;

                case RESUTL_STATE.STATE4:
                    rState = RESUTL_STATE.STATE5;
                    isChange = false;
                    break;

                case RESUTL_STATE.WL_WAIT:
                    rState = RESUTL_STATE.WL_JUDGE;
                    isChange = false;
                    isInputValid = true;
                    break;

                case RESUTL_STATE.SELECT_WAIT:
                    rState = RESUTL_STATE.RETRY_SELECT;
                    isChange = false;
                    isInputValid = true;
                    break;

                default:
                    break;
            }
        }
        // 勝敗判定の所からの遷移は溜めを少し長いやつ
        if (time > 0.6f) {

            if(rState == RESUTL_STATE.STATE5) {
                
                rState = RESUTL_STATE.WL_WAIT;
                isChange = false;
                isInputValid = false;
            } 
        }
        // 対戦相手が連戦を希望した時再度Multi
        if(rState == RESUTL_STATE.ENEMY_WAIT && etd.td.retrySelect == 1) {

            StartCoroutine(rnw.UploadInitData());
            mm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
        }
        // 対戦相手が破棄した時Menuに戻る
        if (rState == RESUTL_STATE.ENEMY_WAIT && etd.td.retrySelect == 2) {

            rState = RESUTL_STATE.RETRY_FAILED;
            isChange = false;
        }
        // 対戦相手が破棄した時Menuに戻る
        if(time > 2f) {

            if(rState == RESUTL_STATE.RETRY_FAILED) {

                mm.nextScene = "MenuScene";
                mm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
            }
        }
        // 時間計測
        time += Time.deltaTime;
    }
}
