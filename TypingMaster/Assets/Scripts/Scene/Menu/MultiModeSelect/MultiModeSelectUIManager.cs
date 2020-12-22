using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MultiModeSelect画面でのUI管理クラス
/// </summary>
public class MultiModeSelectUIManager : MonoBehaviour {

    /*---------- オブジェクトの取得(Inspectorで設定) ----------*/
    [SerializeField] private GameObject selectFriendIcon;
    [SerializeField] private GameObject selectRandomIcon;
    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private MultiModeSelectManager mms;

    /// <summary>
    /// MultiModeSelect画面でのUI処理
    /// </summary>
    public void MultiModeSelectUI() {

        if (mms.mmSelect == MultiModeSelectManager.MULTI_MODE_SELECT.FRIEND) {

            selectFriendIcon.SetActive(true);
            selectRandomIcon.SetActive(false);
        }
        else if (mms.mmSelect == MultiModeSelectManager.MULTI_MODE_SELECT.RANDOM) {

            selectFriendIcon.SetActive(false);
            selectRandomIcon.SetActive(true);
        }
    }
}
