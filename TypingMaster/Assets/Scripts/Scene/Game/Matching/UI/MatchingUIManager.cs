using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マッチング待機画面時のUIの管理クラス
/// </summary>
public class MatchingUIManager : MonoBehaviour {

    /*----- スクリプトの取得(Inspectorで設定) -----*/
    [SerializeField] private MultiPlayerTypingDataManager ptd;
    [SerializeField] private EnemyTypingDataManager etd;
    /*----- オブジェクトの取得(Inspectorで設定) -----*/
    [SerializeField] private Text playerText;
    [SerializeField] private Text enemyText;

    /// <summary>
    /// マッチング中UI
    /// </summary>
    public void MatchingUI() {

        // 未マッチング時
        if (etd.td.UserId == "none") {

            playerText.text = "マッチング待機中";
            enemyText.text = "マッチング待機中";
        }
        // マッチング時
        else{

            // Playerのテキスト
            if (!ptd.td.isReady) {

                playerText.text = "準備完了してください\nEnterキーで準備完了";
            }
            else {

                playerText.text = "準備完了\nEscキーで準備解除";
            }

            // Enemyのテキスト
            if (!etd.td.isReady) {

                enemyText.text = "準備中....";
            }
            else {

                enemyText.text = "準備完了";
            }
        }
    }
}
