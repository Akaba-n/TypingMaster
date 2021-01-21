using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloResultPlayerActionManager : MonoBehaviour {

    [SerializeField] private SoloResultManager sr;
    [SerializeField] private SoloMain sm;

    /// <summary>
    /// SoloResult画面でのPlayerのアクションに対する処理
    /// </summary>
    public void ResultPlayerAction() {

        // キー入力可能時
        if (sr.isInputValid) {

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
            switch (sr.rState) {

                case SoloResultManager.RESUTL_STATE.STATE1:
                    sr.rState = SoloResultManager.RESUTL_STATE.STATE2;
                    sr.time = 0f;
                    sr.isChange = false;
                    break;

                case SoloResultManager.RESUTL_STATE.STATE2:
                    sr.rState = SoloResultManager.RESUTL_STATE.STATE2;
                    sr.time = 0f;
                    sr.isChange = false;
                    break;

                case SoloResultManager.RESUTL_STATE.STATE3:
                    sr.rState = SoloResultManager.RESUTL_STATE.STATE2;
                    sr.time = 0f;
                    sr.isChange = false;
                    break;

                case SoloResultManager.RESUTL_STATE.STATE4:
                    sr.rState = SoloResultManager.RESUTL_STATE.STATE2;
                    sr.time = 0f;
                    sr.isChange = false;
                    break;

                case SoloResultManager.RESUTL_STATE.RETRY_SELECT:
                    if(sr.rSelect == SoloResultManager.RESULT_SELECT.YES) {

                        // SoloSceneへ遷移
                        sm.nextScene = "SoloScene";
                        sm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
                    }
                    else if(sr.rSelect == SoloResultManager.RESULT_SELECT.NO) {

                        // ModeSceneへ遷移
                        sm.nextScene = "MenuScene";
                        sm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
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

            if(sr.rState == SoloResultManager.RESUTL_STATE.RETRY_SELECT) {

                sr.rSelect = SoloResultManager.RESULT_SELECT.NO;
            }
        }
    }

    /// <summary>
    /// 左矢印キー押下時の処理
    /// </summary>
    private void LeftArrowAction() {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            if(sr.rState == SoloResultManager.RESUTL_STATE.RETRY_SELECT) {

                sr.rSelect = SoloResultManager.RESULT_SELECT.YES;
            }
        }
    }
}
