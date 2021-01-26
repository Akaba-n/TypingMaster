using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class MultiResultPlayerActionManager : MonoBehaviour {

    [SerializeField] private MultiResultManager mr;
    [SerializeField] private MultiMain mm;
    [SerializeField] private MultiPlayerTypingDataManager ptd;
    [SerializeField] private UploadPlayerTypingData uploadPtd;
    [SerializeField] private MultiResultNetworkManager rnm;

    /// <summary>
    /// SoloResult画面でのPlayerのアクションに対する処理
    /// </summary>
    public void ResultPlayerAction() {

        // キー入力可能時
        if (mr.isInputValid) {

            RightArrowAction();
            LeftArrowAction();
            EnterAction();
        }
    }

    /// <summary>
    /// Enterキーを押したときの処理
    /// </summary>
    private void EnterAction() {

        if (Input.GetKeyDown(KeyCode.Return)) {

            // Result表記途中では次へ
            // RetrySelectではそれぞれのシーンのへ
            switch (mr.rState) {

                case MultiResultManager.RESUTL_STATE.STATE1:
                    mr.rState = MultiResultManager.RESUTL_STATE.STATE2;
                    mr.time = 0f;
                    mr.isChange = false;
                    break;

                case MultiResultManager.RESUTL_STATE.STATE2:
                    mr.rState = MultiResultManager.RESUTL_STATE.STATE2;
                    mr.time = 0f;
                    mr.isChange = false;
                    break;

                case MultiResultManager.RESUTL_STATE.STATE3:
                    mr.rState = MultiResultManager.RESUTL_STATE.STATE2;
                    mr.time = 0f;
                    mr.isChange = false;
                    break;

                case MultiResultManager.RESUTL_STATE.WL_JUDGE:
                    mr.rState = MultiResultManager.RESUTL_STATE.SELECT_WAIT;
                    mr.time = 0f;
                    mr.isChange = false;
                    break;

                case MultiResultManager.RESUTL_STATE.RETRY_SELECT:
                    if(mr.rSelect == MultiResultManager.RESULT_SELECT.YES) {
                        ///// サーバ：Player情報初期化処理 /////
                        ptd.td.retrySelect = 1;
                        ptd.td.isReady = false;
                        StartCoroutine(uploadPtd.UploadPTD(PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 1), PlayerPrefs.GetString(PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000"))));

                        // MultiSceneへ遷移
                        mm.nextScene = "MultiScene";
                        // 対戦相手の選択を待機
                        mr.rState = MultiResultManager.RESUTL_STATE.ENEMY_WAIT;
                    }
                    else if(mr.rSelect == MultiResultManager.RESULT_SELECT.NO) {
                        ///// サーバ：Player情報初期化処理 /////
                        ptd.td.retrySelect = 2;
                        StartCoroutine(rnm.UploadRetryData());

                        mr.rState = MultiResultManager.RESUTL_STATE.CONNECTING;
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// 右矢印キー押下時の処理
    /// </summary>
    private void RightArrowAction() {

        if (Input.GetKeyDown(KeyCode.RightArrow)) {

            if(mr.rState == MultiResultManager.RESUTL_STATE.RETRY_SELECT) {

                mr.rSelect = MultiResultManager.RESULT_SELECT.NO;
            }
        }
    }

    /// <summary>
    /// 左矢印キー押下時の処理
    /// </summary>
    private void LeftArrowAction() {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            if(mr.rState == MultiResultManager.RESUTL_STATE.RETRY_SELECT) {

                mr.rSelect = MultiResultManager.RESULT_SELECT.YES;
            }
        }
    }

    private void EscAction() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if(mr.rState == MultiResultManager.RESUTL_STATE.ENEMY_WAIT) {

                mr.rState = MultiResultManager.RESUTL_STATE.RETRY_SELECT;
                ptd.td.retrySelect = 0;
            }
        }
    }
}
