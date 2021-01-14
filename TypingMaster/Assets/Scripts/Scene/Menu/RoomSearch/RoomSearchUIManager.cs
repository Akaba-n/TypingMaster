using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Room検索画面でのUIの処理
/// </summary>
public class RoomSearchUIManager : MonoBehaviour {
    /*----- スクリプトの取得(Inspectorで設定) -----*/
    [SerializeField] private MenuMain mm;
    /*----- オブジェクトの取得(Inspectorで設定) -----*/
    [SerializeField] private InputField roomSearchField;
    [SerializeField] private InputField dummyField;     // フォーカス回避用ダミー

    public void RoomSearchUI() {

        if(mm.rSelect == MenuMain.ROOM_SEARCH.INPUT) {
            
            // InputFieldのアクティブ化
            roomSearchField.ActivateInputField();
        }
        else {

            dummyField.ActivateInputField();
            ///// submitボタンをそれっぽい見た目にする /////
            
        }
    }
}
