using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostSelectPlayerActionManager : MonoBehaviour {

    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private MenuMain mm;

    /// <summary>
    /// Host選択画面でのプレイヤー操作
    /// </summary>
    public void HostSelectPlayerAction() {

        DownArrowAction();
        UpArrowAction();
        EnterAction();
        EscAction();
    }
    /// <summary>
    /// ↓ボタン押下時の処理
    /// </summary>
    private void DownArrowAction() {

        if (Input.GetKeyDown(KeyCode.DownArrow)) {

            if(mm.hSelect == MenuMain.HOST_SELECT.HOST) {

                mm.hSelect = MenuMain.HOST_SELECT.JOIN;
            }
            else if(mm.hSelect == MenuMain.HOST_SELECT.JOIN) {

                mm.hSelect = MenuMain.HOST_SELECT.HOST;
            }
        }
    }
    /// <summary>
    /// ↑キー押下時の処理
    /// </summary>
    private void UpArrowAction() {

        if (Input.GetKeyDown(KeyCode.UpArrow)) {

            if(mm.hSelect == MenuMain.HOST_SELECT.HOST) {

                mm.hSelect = MenuMain.HOST_SELECT.JOIN;
            }
            else if(mm.hSelect == MenuMain.HOST_SELECT.JOIN) {

                mm.hSelect = MenuMain.HOST_SELECT.HOST;
            }
        }
    }
    /// <summary>
    /// Enterキー押下時の処理
    /// </summary>
    private void EnterAction() {

        if (Input.GetKeyDown(KeyCode.Return)) {

            if(mm.hSelect == MenuMain.HOST_SELECT.HOST) {

                mm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
                ///// 部屋建て処理 /////
                mm.isChanged = false;
            }
            else {
                
                // 部屋検索に移動
                mm.mState = MenuMain.MENU_STATE.ROOM_SEARCH;
                mm.isChanged = false;
            }
        }
    }
    /// <summary>
    /// Escキーでの処理
    /// </summary>
    private void EscAction() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            mm.mState = MenuMain.MENU_STATE.MULTI_MODE_SELECT;
            mm.hSelect = MenuMain.HOST_SELECT.HOST;
            mm.isChanged = false;
        }
    }
}
