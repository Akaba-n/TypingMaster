using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// モードセレクト画面のUI管理クラス
/// </summary>
public class ModeSelectUIManager : MonoBehaviour {

    /*---------- オブジェクトの取得(Inspectorで設定) ----------*/
    [SerializeField] private GameObject selectSoloIcon;
    [SerializeField] private GameObject selectMultiIcon;
    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private MenuMain mm;

    /// <summary>
    /// モードセレクトシーンでのUIの動作
    /// </summary>
    public void ModeSelectUI() {

        if (mm.mSelect == MenuMain.MODE_SELECT.SOLO) {

            selectSoloIcon.SetActive(true);
            selectMultiIcon.SetActive(false);
        }
        else if (mm.mSelect == MenuMain.MODE_SELECT.MULTI) {

            selectSoloIcon.SetActive(false);
            selectMultiIcon.SetActive(true);
        }
    }
}
