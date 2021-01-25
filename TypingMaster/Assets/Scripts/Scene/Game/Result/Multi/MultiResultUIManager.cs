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
    [SerializeField] GameObject playerCorrectNum;
    [SerializeField] GameObject playerMisNum;
    [SerializeField] GameObject playerCorrectRate;
    [SerializeField] GameObject playerTotalTime;
    [SerializeField] GameObject playerKpm;
    [SerializeField] GameObject playerScore;
    [SerializeField] GameObject enemyCorrectNum;
    [SerializeField] GameObject enemyMisNum;
    [SerializeField] GameObject enemyCorrectRate;
    [SerializeField] GameObject enemyTotalTime;
    [SerializeField] GameObject enemyKpm;
    [SerializeField] GameObject enemyScore;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject drawText;
    [SerializeField] GameObject nextText;
    [SerializeField] GameObject retrySelect;
    // Playerの結果表示Text
    [SerializeField] Text playerCorrectNumText;
    [SerializeField] Text playerMissNumText;
    [SerializeField] Text playerCorrectRateText;
    [SerializeField] Text playerTotalTimeText;
    [SerializeField] Text playerKpmText;
    [SerializeField] Text playerScoreText;
    // Enemyの結果表示Text
    [SerializeField] Text enemyCorrectNumText;
    [SerializeField] Text enemyMissNumText;
    [SerializeField] Text enemyCorrectRateText;
    [SerializeField] Text enemyTotalTimeText;
    [SerializeField] Text enemyKpmText;
    [SerializeField] Text enemyScoreText;

    /// <summary>
    /// SoloResult画面UI一括管理処理
    /// </summary>
    public void SoloResultUI() {

        RetrySelect();
        if(mr.rState == MultiResultManager.RESUTL_STATE.NONE || mr.rState == MultiResultManager.RESUTL_STATE.STATE1 || mr.rState == MultiResultManager.RESUTL_STATE.STATE2 || mr.rState == MultiResultManager.RESUTL_STATE.STATE3 || mr.rState == MultiResultManager.RESUTL_STATE.STATE4 || mr.rState == MultiResultManager.RESUTL_STATE.STATE5 || mr.rState == MultiResultManager.RESUTL_STATE.WL_WAIT) {

            DisplayResult();
        }
    }

    /// <summary>
    /// Result画面での状態毎の表示変更
    /// </summary>
    public void DisplayChange() {

        switch (mr.rState) {

            case MultiResultManager.RESUTL_STATE.NONE:
                playerCorrectNum.SetActive(false);
                enemyCorrectNum.SetActive(false);
                playerMisNum.SetActive(false);
                enemyMisNum.SetActive(false);
                playerCorrectRate.SetActive(false);
                enemyCorrectRate.SetActive(false);
                playerTotalTime.SetActive(false);
                enemyTotalTime.SetActive(false);
                playerKpm.SetActive(false);
                enemyKpm.SetActive(false);
                playerScore.SetActive(false);
                enemyScore.SetActive(false);
                winText.SetActive(false);
                loseText.SetActive(false);
                drawText.SetActive(false);
                nextText.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE1:
                playerCorrectNum.SetActive(true);
                enemyCorrectNum.SetActive(true);
                playerMisNum.SetActive(false);
                enemyMisNum.SetActive(false);
                playerCorrectRate.SetActive(false);
                enemyCorrectRate.SetActive(false);
                playerTotalTime.SetActive(false);
                enemyTotalTime.SetActive(false);
                playerKpm.SetActive(false);
                enemyKpm.SetActive(false);
                playerScore.SetActive(false);
                enemyScore.SetActive(false);
                winText.SetActive(false);
                loseText.SetActive(false);
                drawText.SetActive(false);
                nextText.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE2:
                playerCorrectNum.SetActive(true);
                enemyCorrectNum.SetActive(true);
                playerMisNum.SetActive(true);
                enemyMisNum.SetActive(true);
                playerCorrectRate.SetActive(false);
                enemyCorrectRate.SetActive(false);
                playerTotalTime.SetActive(false);
                enemyTotalTime.SetActive(false);
                playerKpm.SetActive(false);
                enemyKpm.SetActive(false);
                playerScore.SetActive(false);
                enemyScore.SetActive(false);
                winText.SetActive(false);
                loseText.SetActive(false);
                drawText.SetActive(false);
                nextText.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE3:
                playerCorrectNum.SetActive(true);
                enemyCorrectNum.SetActive(true);
                playerMisNum.SetActive(true);
                enemyMisNum.SetActive(true);
                playerCorrectRate.SetActive(true);
                enemyCorrectRate.SetActive(true);
                playerTotalTime.SetActive(false);
                enemyTotalTime.SetActive(false);
                playerKpm.SetActive(false);
                enemyKpm.SetActive(false);
                playerScore.SetActive(false);
                enemyScore.SetActive(false);
                winText.SetActive(false);
                loseText.SetActive(false);
                drawText.SetActive(false);
                nextText.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE4:
                playerCorrectNum.SetActive(true);
                enemyCorrectNum.SetActive(true);
                playerMisNum.SetActive(true);
                enemyMisNum.SetActive(true);
                playerCorrectRate.SetActive(true);
                enemyCorrectRate.SetActive(true);
                playerTotalTime.SetActive(true);
                enemyTotalTime.SetActive(true);
                playerKpm.SetActive(false);
                enemyKpm.SetActive(false);
                playerScore.SetActive(false);
                enemyScore.SetActive(false);
                winText.SetActive(false);
                loseText.SetActive(false);
                drawText.SetActive(false);
                nextText.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case MultiResultManager.RESUTL_STATE.STATE5:
                playerCorrectNum.SetActive(true);
                enemyCorrectNum.SetActive(true);
                playerMisNum.SetActive(true);
                enemyMisNum.SetActive(true);
                playerCorrectRate.SetActive(true);
                enemyCorrectRate.SetActive(true);
                playerTotalTime.SetActive(true);
                enemyTotalTime.SetActive(true);
                playerKpm.SetActive(true);
                enemyKpm.SetActive(true);
                playerScore.SetActive(false);
                enemyScore.SetActive(false);
                winText.SetActive(false);
                loseText.SetActive(false);
                drawText.SetActive(false);
                nextText.SetActive(false);
                retrySelect.SetActive(false);
                break;
            case MultiResultManager.RESUTL_STATE.WL_WAIT:
                playerCorrectNum.SetActive(true);
                enemyCorrectNum.SetActive(true);
                playerMisNum.SetActive(true);
                enemyMisNum.SetActive(true);
                playerCorrectRate.SetActive(true);
                enemyCorrectRate.SetActive(true);
                playerTotalTime.SetActive(true);
                enemyTotalTime.SetActive(true);
                playerKpm.SetActive(true);
                enemyKpm.SetActive(true);
                playerScore.SetActive(true);
                enemyScore.SetActive(true);
                // 勝利時
                if(ptd.td.Score > etd.td.Score) {

                    winText.SetActive(true);
                    loseText.SetActive(false);
                    drawText.SetActive(false);
                }
                else if (ptd.td.Score < etd.td.Score) {

                    winText.SetActive(false);
                    loseText.SetActive(true);
                    drawText.SetActive(false);
                }
                else if (ptd.td.Score == etd.td.Score) {

                    winText.SetActive(false);
                    loseText.SetActive(false);
                    drawText.SetActive(true);
                }
                nextText.SetActive(false);
                retrySelect.SetActive(false);
                break;
            case MultiResultManager.RESUTL_STATE.WL_JUDGE:
                playerCorrectNum.SetActive(true);
                enemyCorrectNum.SetActive(true);
                playerMisNum.SetActive(true);
                enemyMisNum.SetActive(true);
                playerCorrectRate.SetActive(true);
                enemyCorrectRate.SetActive(true);
                playerTotalTime.SetActive(true);
                enemyTotalTime.SetActive(true);
                playerKpm.SetActive(true);
                enemyKpm.SetActive(true);
                playerScore.SetActive(true);
                enemyScore.SetActive(true);
                // 勝利時
                if(ptd.td.Score > etd.td.Score) {

                    winText.SetActive(true);
                    loseText.SetActive(false);
                    drawText.SetActive(false);
                }
                else if (ptd.td.Score < etd.td.Score) {

                    winText.SetActive(false);
                    loseText.SetActive(true);
                    drawText.SetActive(false);
                }
                else if (ptd.td.Score == etd.td.Score) {

                    winText.SetActive(false);
                    loseText.SetActive(false);
                    drawText.SetActive(true);
                }
                nextText.SetActive(true);
                retrySelect.SetActive(false);
                break;
            case MultiResultManager.RESUTL_STATE.RETRY_SELECT:
                playerCorrectNum.SetActive(true);
                enemyCorrectNum.SetActive(true);
                playerMisNum.SetActive(true);
                enemyMisNum.SetActive(true);
                playerCorrectRate.SetActive(true);
                enemyCorrectRate.SetActive(true);
                playerTotalTime.SetActive(true);
                enemyTotalTime.SetActive(true);
                playerKpm.SetActive(true);
                enemyKpm.SetActive(true);
                playerScore.SetActive(true);
                enemyScore.SetActive(true);
                winText.SetActive(false);
                loseText.SetActive(false);
                drawText.SetActive(false);
                nextText.SetActive(false);
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
        playerCorrectNumText.text  = ptd.td.CorrectTypeNum.ToString();
        playerMissNumText.text     = ptd.td.MisTypeNum.ToString();
        playerCorrectRateText.text = ptd.td.Accuracy.ToString("f2"); 
        var sec = ptd.td.TotalTypingTime % 60.0f;
        var min = (int)(ptd.td.TotalTypingTime / 60.0f);
        playerTotalTimeText.text   = min.ToString() + ":" + sec.ToString("f2");
        playerKpmText.text         = ptd.td.Kpm.ToString("f2");
        playerScoreText.text       = ptd.td.Score.ToString();

        // EnemyのResult表示
        enemyCorrectNumText.text  = etd.td.CorrectTypeNum.ToString();
        enemyMissNumText.text     = etd.td.MisTypeNum.ToString();
        enemyCorrectRateText.text = etd.td.Accuracy.ToString("f2");
        var esec = etd.td.TotalTypingTime % 60.0f;
        var emin = (int)(etd.td.TotalTypingTime / 60.0f);
        enemyTotalTimeText.text   = emin.ToString() + ":" + esec.ToString("f2");
        enemyKpmText.text         = etd.td.Kpm.ToString("f2");
        enemyScoreText.text       = etd.td.Score.ToString();
    }
}
