using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ModeSelect画面でのプレイヤー操作管理クラス
/// </summary>
public class ModeSelectPlayerActionManager : MonoBehaviour {

    [SerializeField] private MenuMain mm;
    
    /// <summary>
    /// ModeSelect画面でのプレイヤー操作
    /// </summary>
    public void ModeSelectPlayerAction() {

        DownArrowAction();
        UpArrowAction();
        EnterAction();
    }

    /// <summary>
    /// ↓ボタン押下時の処理
    /// </summary>
    private void DownArrowAction() {

        if (Input.GetKeyDown(KeyCode.DownArrow)) {

            if(mm.mSelect == MenuMain.MODE_SELECT.SOLO) {

                mm.mSelect = MenuMain.MODE_SELECT.MULTI;
            }
            else if(mm.mSelect == MenuMain.MODE_SELECT.MULTI) {

                mm.mSelect = MenuMain.MODE_SELECT.SOLO;
            }
        }
    }
    /// <summary>
    /// ↑キー押下時の処理
    /// </summary>
    private void UpArrowAction() {

        if (Input.GetKeyDown(KeyCode.UpArrow)) {

            if(mm.mSelect == MenuMain.MODE_SELECT.SOLO) {

                mm.mSelect = MenuMain.MODE_SELECT.MULTI;
            }
            else if(mm.mSelect == MenuMain.MODE_SELECT.MULTI) {

                mm.mSelect = MenuMain.MODE_SELECT.SOLO;
            }
        }
    }

    private void EnterAction() {

        if (Input.GetKeyDown(KeyCode.Return)) {

            if(mm.mSelect == MenuMain.MODE_SELECT.SOLO) {

                mm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
                mm.isChanged = false;
            }
            else {
                
                mm.mState = MenuMain.MENU_STATE.MULTI_MODE_SELECT;
                mm.isChanged = false;
            }
        }
    }
}
