using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloResultManager : MonoBehaviour {

    /*----- Script取得(Inspectorで設定) -----*/
    [SerializeField] private SoloResultUIManager rUI;
    [SerializeField] private SoloResultPlayerActionManager rpa;

    // リザルト画面の状態遷移
    public enum RESUTL_STATE {

        NONE,           // 最初
        STATE1,         // 結果表示1
        STATE2,         // 結果表示1
        STATE3,         // 結果表示1
        STATE4,         // 結果表示1
        RETRY_WAIT,     // リトライ選択待機(入力ミス回避用)
        RETRY_SELECT    // リトライ選択
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
    /// SoloモードでのResult画面処理
    /// </summary>
    public void SoloResult() {

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

        ///// UI管理 /////
        rUI.SoloResultUI();
    }

    /// <summary>
    /// Result画面での状態遷移処理
    /// </summary>
    private void ResultStateChange() {
        // 一定時間経過時
        if(time > distanceTime) {

            switch (rState) {

                case RESUTL_STATE.STATE1:       
                    rState = RESUTL_STATE.STATE2;
                    break;

                case RESUTL_STATE.STATE2:
                    rState = RESUTL_STATE.STATE3;                
                    break;

                case RESUTL_STATE.STATE3:
                    rState = RESUTL_STATE.STATE4;
                    break;

                case RESUTL_STATE.STATE4:
                    rState = RESUTL_STATE.RETRY_WAIT;
                    isInputValid = false;
                    break;

                case RESUTL_STATE.RETRY_WAIT:
                    rState = RESUTL_STATE.RETRY_SELECT;
                    isInputValid = true;
                    break;

                default:
                    break;
            }

            isChange = false;
        }
        // 時間計測
        time += Time.deltaTime;
    }
}
