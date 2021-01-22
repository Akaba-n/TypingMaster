using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// MultiシーンでのResult画面UI一括管理クラス
/// </summary>
public class MultiResultUIManager : MonoBehaviour {
    
    /*----- Script(Inspectorで設定) -----*/
    [SerializeField] MultiResultManager mr;
    [SerializeField] MultiPlayerTypingDataManager ptd;
    [SerializeField] EnemyTypingDataManager etd;

    /*----- Object(Inspectorで設定) -----*/
    [SerializeField] GameObject yesIcon;
    [SerializeField] GameObject noIcon;

    // 順番に表示する用の括り
    [SerializeField] GameObject correctCnt;
    [SerializeField] GameObject missCnt;
    [SerializeField] GameObject totalTime;
    [SerializeField] GameObject kpm;
    [SerializeField] GameObject retrySelect;
    // Playerの結果表示Text
    [SerializeField] Text playerCorrectNumText;
    [SerializeField] Text playerMissNumText;
    [SerializeField] Text playerTotalTimeText;
    [SerializeField] Text playerKpmText;
    // Enemyの結果表示Text
    [SerializeField] Text enemyCorrectNumText;
    [SerializeField] Text enemyMissNumText;
    [SerializeField] Text enemyTotalTimeText;
    [SerializeField] Text enemyKpmText;

    /// <summary>
    /// SoloResult画面UI一括管理処理
    /// </summary>
    public void SoloResultUI() {

        RetrySelect();
        DisplayResult();
    }

    /// <summary>
    /// Result画面での状態毎の表示変更
    /// </summary>
    public void DisplayChange() {

        switch (mr.rState) {

            case MultiResultManager.RESUTL_STATE.NONE:
                correctCnt.SetActive(false);
                missCnt.SetActive(false);
                totalTime.SetActive(false);
                kpm.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE1:
                correctCnt.SetActive(true);
                missCnt.SetActive(false);
                totalTime.SetActive(false);
                kpm.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE2:
                correctCnt.SetActive(true);
                missCnt.SetActive(true);
                totalTime.SetActive(false);
                kpm.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE3:
                correctCnt.SetActive(true);
                missCnt.SetActive(true);
                totalTime.SetActive(true);
                kpm.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE4:
                correctCnt.SetActive(true);
                missCnt.SetActive(true);
                totalTime.SetActive(true);
                kpm.SetActive(true);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.SELECT_WAIT:
            case MultiResultManager.RESUTL_STATE.RETRY_SELECT:
                correctCnt.SetActive(true);
                missCnt.SetActive(true);
                totalTime.SetActive(true);
                kpm.SetActive(true);
                retrySelect.SetActive(true);
                break;
        }
        // 画面変更済み判定
        mr.isChange = true;
    }

    /// <summary>
    /// Retry選択のIcon表示管理処理
    /// </summary>
    private void RetrySelect() {

        if (mr.rSelect == MultiResultManager.RESULT_SELECT.YES) {

            yesIcon.SetActive(true);
            noIcon.SetActive(false);
        }
        else {

            yesIcon.SetActive(false);
            noIcon.SetActive(true);
        }
    }

    /// <summary>
    /// Result表示処理
    /// </summary>
    private void DisplayResult() {

        // PlayerのResult表示
        playerCorrectNumText.text = ptd.td.CorrectTypeNum.ToString();
        playerMissNumText.text    = ptd.td.MisTypeNum.ToString();
        var sec = ptd.td.TotalTypingTime % 60.0f;
        var min = (int)(ptd.td.TotalTypingTime / 60.0f);
        playerTotalTimeText.text = min.ToString() + " 分  " + sec.ToString("f2");
        playerKpmText.text = ptd.td.Kpm.ToString("f2");

        // EnemyのResult表示
        enemyCorrectNumText.text = ptd.td.CorrectTypeNum.ToString();
        enemyMissNumText.text = ptd.td.MisTypeNum.ToString();
        var esec = ptd.td.TotalTypingTime % 60.0f;
        var emin = (int)(ptd.td.TotalTypingTime / 60.0f);
        enemyTotalTimeText.text = emin.ToString() + " 分  " + esec.ToString("f2");
        enemyKpmText.text = ptd.td.Kpm.ToString("f2");
    }
}
