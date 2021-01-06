using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostSelectUIManager : MonoBehaviour {

    /*---------- オブジェクトの取得(Inspectorで設定) ----------*/
    [SerializeField] private GameObject selectHostIcon;
    [SerializeField] private GameObject selectJoinIcon;
    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private MenuMain mm;

    /// <summary>
    /// ホスト選択シーンでのUIの動作
    /// </summary>
    public void HostSelectUI() {

        if (mm.hSelect == MenuMain.HOST_SELECT.HOST) {

            selectHostIcon.SetActive(true);
            selectJoinIcon.SetActive(false);
        }
        else if (mm.hSelect == MenuMain.HOST_SELECT.JOIN) {

            selectHostIcon.SetActive(false);
            selectJoinIcon.SetActive(true);
        }
    }
}
