using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SoloモードでのResult画面UI管理クラス
/// </summary>
public class SoloResultUIManager : MonoBehaviour {

    /*----- Script(Inspectorで設定) -----*/
    [SerializeField] SoloResultManager sr;
    [SerializeField] SoloPlayerTypingDataManager ptd; 
    /*----- Object(Inspectorで設定) -----*/
    [SerializeField] GameObject yesIcon;
    [SerializeField] GameObject noIcon;

    [SerializeField] GameObject correctCnt;
    [SerializeField] GameObject missCnt;
    [SerializeField] GameObject totalTime;
    [SerializeField] GameObject kpm;
    [SerializeField] GameObject retrySelect;

    [SerializeField] Text correctNumText;
    [SerializeField] Text missNumText;
    [SerializeField] Text totalTimeText;
    [SerializeField] Text kpmText;
    
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

        switch (sr.rState) {

            case SoloResultManager.RESUTL_STATE.NONE:
                correctCnt.SetActive(false);
                missCnt.SetActive(false);
                totalTime.SetActive(false);
                kpm.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case SoloResultManager.RESUTL_STATE.STATE1:
                correctCnt.SetActive(true);
                missCnt.SetActive(false);
                totalTime.SetActive(false);
                kpm.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case SoloResultManager.RESUTL_STATE.STATE2:
                correctCnt.SetActive(true);
                missCnt.SetActive(true);
                totalTime.SetActive(false);
                kpm.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case SoloResultManager.RESUTL_STATE.STATE3:
                correctCnt.SetActive(true);
                missCnt.SetActive(true);
                totalTime.SetActive(true);
                kpm.SetActive(false);
                retrySelect.SetActive(false);
                break;

            case SoloResultManager.RESUTL_STATE.STATE4:
                correctCnt.SetActive(true);
                missCnt.SetActive(true);
                totalTime.SetActive(true);
                kpm.SetActive(true);
                retrySelect.SetActive(false);
                break;

            case SoloResultManager.RESUTL_STATE.RETRY_WAIT:
            case SoloResultManager.RESUTL_STATE.RETRY_SELECT:
                correctCnt.SetActive(true);
                missCnt.SetActive(true);
                totalTime.SetActive(true);
                kpm.SetActive(true);
                retrySelect.SetActive(true);
                break;
        }
        // 画面変更済み判定
        sr.isChange = true;
    }

    /// <summary>
    /// Retry選択のIcon表示管理処理
    /// </summary>
    private void RetrySelect() {

        if (sr.rSelect == SoloResultManager.RESULT_SELECT.YES) {

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

        correctNumText.text = ptd.td.CorrectTypeNum.ToString();
        missNumText.text    = ptd.td.MisTypeNum.ToString();
        var sec = ptd.td.TotalTypingTime % 60.0f;
        var min = (int)(ptd.td.TotalTypingTime / 60.0f);
        totalTimeText.text = min.ToString() + " 分  " + sec.ToString("f2");
        kpmText.text = ptd.td.Kpm.ToString("f2");
    }
}
