using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SoloモードでのCountDown画面でのUI操作管理クラス
/// </summary>
public class SoloCountDownUIManager : MonoBehaviour {

    /*----- Scriptの取得(Inspectorで設定) -----*/
    [SerializeField] private SoloCountDownManager scd;

    /*----- Objectの取得(Inspectorで設定) -----*/
    [SerializeField] private Text countDownText; 

    /// <summary>
    /// SoloモードでのCountDown画面でのUI操作
    /// </summary>
    public void SoloCountDownUI() {

        // 表示する数字
        int countSecI = (int)(scd.countSec / 1.0f);
        string countSec = countSecI.ToString();

        if(countSec == "0") {

            countDownText.text = "Start!!";
        }
        else {

            countDownText.text = countSec;
        }
    }
}
