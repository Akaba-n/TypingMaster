using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// モードセレクト画面のUI管理クラス
/// </summary>
public class ModeSelectUIManager : MonoBehaviour {

    /*---------- オブジェクトの取得(Inspectorで設定) ----------*/
    [SerializeField] private Text soloText;
    [SerializeField] private Text multiText;
    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private MenuMain mm;

    // モードセレクトシーンでのUIの動作
    private void ModeSelectUI() {

        if (mm.mSelect == MenuMain.MODE_SELECT.SOLO) {


        }
        else {


        }
    }
}
