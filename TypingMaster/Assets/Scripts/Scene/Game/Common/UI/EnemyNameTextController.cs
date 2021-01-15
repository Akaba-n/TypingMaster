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

    // プレイヤー名を表示する処理
    public void EnemyNameText() {

        enemyNameText.text = etd.td.UserName;
    }
}
