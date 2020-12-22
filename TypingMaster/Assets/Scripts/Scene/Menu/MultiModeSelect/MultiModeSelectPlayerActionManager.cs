using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MultiModeSelect画面でのプレイヤーの操作管理クラス
/// </summary>
public class MultiModeSelectPlayerActionManager : MonoBehaviour {

    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private MenuMain mm;
    [SerializeField] private MultiModeSelectManager mms;
    
    /// <summary>
    /// MultiModeSelect画面でのプレイヤー操作へのレスポンス
    /// </summary>
    public void MultiModeSelectPlayerAction() {

        DownArrowAction();
        UpArrowAction();
        EnterAction();
        EscAction();
    }

    /// <summary>
    /// ↓キーでの処理
    /// </summary>
    private void DownArrowAction() {

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            
            if(mms.mmSelect == MultiModeSelectManager.MULTI_MODE_SELECT.FRIEND) {

                mms.mmSelect = MultiModeSelectManager.MULTI_MODE_SELECT.RANDOM;
            }
            else if(mms.mmSelect == MultiModeSelectManager.MULTI_MODE_SELECT.RANDOM) {

                mms.mmSelect = MultiModeSelectManager.MULTI_MODE_SELECT.FRIEND;
            }
        }
    }
    /// <summary>
    /// ↑キーでの処理
    /// </summary>
    private void UpArrowAction() {

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            
            if(mms.mmSelect == MultiModeSelectManager.MULTI_MODE_SELECT.FRIEND) {

                mms.mmSelect = MultiModeSelectManager.MULTI_MODE_SELECT.RANDOM;
            }
            else if(mms.mmSelect == MultiModeSelectManager.MULTI_MODE_SELECT.RANDOM) {

                mms.mmSelect = MultiModeSelectManager.MULTI_MODE_SELECT.FRIEND;
            }
        }
    }
    /// <summary>
    /// Enterキーでの処理
    /// </summary>
    private void EnterAction() {

        if (Input.GetKeyDown(KeyCode.Return)) {

            if(mms.mmSelect == MultiModeSelectManager.MULTI_MODE_SELECT.FRIEND) {

                ///// 部屋建て処理 /////
            }
            else if(mms.mmSelect == MultiModeSelectManager.MULTI_MODE_SELECT.RANDOM){

                ///// ランダムマッチング処理 /////
            }
        }
    }
    /// <summary>
    /// Escキーでの処理
    /// </summary>
    private void EscAction() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            mm.mState = MenuMain.MENU_STATE.MODE_SELECT;
            mms.mmSelect = MultiModeSelectManager.MULTI_MODE_SELECT.FRIEND;
            mm.isChanged = false;
        }
    }
}
