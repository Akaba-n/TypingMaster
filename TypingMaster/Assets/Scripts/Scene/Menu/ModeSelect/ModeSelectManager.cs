using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelectManager : MonoBehaviour {
    
    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private ModeSelectUIManager msUI;
    [SerializeField] private ModeSelectPlayerActionManager msPA;

    /// <summary>
    /// モードセレクト画面での動作
    /// </summary>
    public void ModeSelectAction() {

        msUI.ModeSelectUI();
        msPA.ModeSelectPlayerAction();
    }
}
