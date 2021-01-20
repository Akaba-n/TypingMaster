using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// MultiモードでのCountDown画面でのUI操作管理クラス
/// </summary>
public class MultiCountdownUIManager : MonoBehaviour {

    /*----- Scriptの取得(Inspectorで設定) -----*/
    [SerializeField] private MultiCountdownManager mcd;

    /*----- Objectの取得(Inspectorで設定) -----*/
    [SerializeField] private Text playerText;
    [SerializeField] private Text enemyText;

    /// <summary>
    /// MultiモードでのCountdown画面UI処理
    /// </summary>
    public void CountdownUI() {

        // 表示する数字
        int countSecI = (int)(mcd.countSec / 1.0f) + 1;
        if (countSecI > 3) {

            countSecI = 3;
        }
        else if(countSecI < 0) {

            countSecI = 0;
        }
        string countSec = countSecI.ToString();
        
        playerText.text = countSec;
        enemyText.text = countSec;
    }
}
