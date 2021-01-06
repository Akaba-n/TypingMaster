using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostSelectManager : MonoBehaviour {

    /*---------- スクリプトの取得(Inspectorで設定) ----------*/
    [SerializeField] private HostSelectUIManager hsUI;
    [SerializeField] private HostSelectPlayerActionManager hsPA;

    /// <summary>
    /// モードセレクト画面での動作
    /// </summary>
    public void HostSelectAction() {

        hsUI.HostSelectUI();
        hsPA.HostSelectPlayerAction();
    }
}
