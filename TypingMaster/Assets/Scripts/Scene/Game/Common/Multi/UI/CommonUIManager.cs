using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MultiScene内共通のUI管理クラス
/// </summary>
public class CommonUIManager : MonoBehaviour {

    /*----- スクリプトの取得(Inspectorで設定) -----*/
    [SerializeField] private PlayerNameTextController pn;
    [SerializeField] private EnemyNameTextController en;
    [SerializeField] private RoomIdTextController ri;
    [SerializeField] private TypingTaskPanelController ttp;

    /// <summary>
    /// 共通UI操作(全て)
    /// </summary>
    public void CommonUIAll() {

        pn.PlayerNameText();
        en.EnemyNameText();
        ri.RoomIdText();
    }
    /// <summary>
    /// Playerの名前を表示する処理
    /// </summary>
    public void PlayerNameText() {

        pn.PlayerNameText();
    }
    /// <summary>
    /// Enemyの名前を表示する処理
    /// </summary>
    public void EnemyNameText() {

        en.EnemyNameText();
    }
    /// <summary>
    /// RoomIdを表示する処理
    /// </summary>
    public void RoomIdText() {

        ri.RoomIdText();
    }
    public void TaskPanelText() {

        ttp.TypingTaskPanel();
    }
}
