using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class EnemyNameTextController : MonoBehaviour {

    /*----- スクリプトの取得(Inspectorで設定) -----*/
    [SerializeField] private EnemyTypingDataManager etd;
    /*----- オブジェクトの取得(Inspectorで設定) -----*/
    [SerializeField] private Text enemyNameText;

    /// <summary>
    /// プレイヤー名を表示する処理
    /// </summary>
    public void EnemyNameText() {

        // 未マッチング時
        if (etd.td.UserId == "none") {
            
            enemyNameText.text = "-----";
        }
        // マッチング時
        else {

            enemyNameText.text = etd.td.UserName;
        }
    }
}
