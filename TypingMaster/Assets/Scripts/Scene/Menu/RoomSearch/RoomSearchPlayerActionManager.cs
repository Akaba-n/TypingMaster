using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Room検索画面でのプレイヤーの動作に対するレスポンス管理のクラス
/// </summary>
public class RoomSearchPlayerActionManager : MonoBehaviour {

    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private MenuMain mm;
    [SerializeField] private RoomSearchManager rs;
    
    /// <summary>
    /// MultiModeSelect画面でのプレイヤー操作へのレスポンス
    /// </summary>
    public void RoomSearchPlayerAction() {

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
            
            if(mm.rSelect == MenuMain.ROOM_SEARCH.INPUT) {

                mm.rSelect = MenuMain.ROOM_SEARCH.SUBMIT;
            }
            else if(mm.rSelect == MenuMain.ROOM_SEARCH.SUBMIT) {

                mm.rSelect = MenuMain.ROOM_SEARCH.INPUT;
            }
        }
    }
    /// <summary>
    /// ↑キーでの処理
    /// </summary>
    private void UpArrowAction() {

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            
            if(mm.rSelect == MenuMain.ROOM_SEARCH.INPUT) {

                mm.rSelect = MenuMain.ROOM_SEARCH.SUBMIT;
            }
            else if(mm.rSelect == MenuMain.ROOM_SEARCH.SUBMIT) {

                mm.rSelect = MenuMain.ROOM_SEARCH.INPUT;
            }
        }
    }
    /// <summary>
    /// Enterキーでの処理
    /// </summary>
    private void EnterAction() {

        if (Input.GetKeyDown(KeyCode.Return)) {

            ///// Room検索処理を行う /////
        }
    }
    /// <summary>
    /// Escキーでの処理
    /// </summary>
    private void EscAction() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            mm.hSelect = MenuMain.HOST_SELECT.HOST;
            mm.mState = MenuMain.MENU_STATE.MULTI_HOST_SELECT;
            mm.rSelect = MenuMain.ROOM_SEARCH.INPUT;
            mm.isChanged = false;
        }
    }
}
