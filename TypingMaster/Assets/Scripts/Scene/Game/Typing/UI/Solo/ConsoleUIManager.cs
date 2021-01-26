using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの記録UI表示クラス
/// </summary>
public class ConsoleUIManager : MonoBehaviour {

    /*----- オブジェクトのインスタンス化(Inspectorで設定) -----*/
    [SerializeField] private Text CorrectTypeNumText;
    [SerializeField] private Text MisTypeNumText;
    [SerializeField] private Text TotalTimeText;
    [SerializeField] private Text KpmText;
    [SerializeField] private Text TaskText;
    [SerializeField] private Text TotalTaskText;
    [SerializeField] private SoloPlayerTypingDataManager ptd;
    [SerializeField] private GameConfigClass gc;

    /// <summary>
    /// 記録関連UI表示処理
    /// </summary>
    public void DisplayConsoleText() {

        CorrectTypeNumText.text = ptd.td.CorrectTypeNum.ToString();
        MisTypeNumText.text     = ptd.td.MisTypeNum.ToString();
        KpmText.text            = ptd.td.Kpm.ToString("f1");
        if(ptd.td.CorrectTaskNum < gc.gc.Tasks) {

            TaskText.text = (ptd.td.CorrectTaskNum + 1).ToString();
        }
        else {

            TaskText.text = ptd.td.CorrectTaskNum.ToString();
        }
        TotalTaskText.text      = "/ " + gc.gc.Tasks.ToString();
    }
    /// <summary>
    /// 時間UI表示処理
    /// </summary>
    public void DisplayTimeText() {

        var sec = ptd.td.TotalTypingTime % 60.0f;
        var min = (int)(ptd.td.TotalTypingTime / 60f);
        TotalTimeText.text =  min + "分 " + sec.ToString("f2");
    }
}
