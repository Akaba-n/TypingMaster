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
    [SerializeField] private SoloPlayerTypingDataManager ptd;
    [SerializeField] private GameConfigClass gc;

    /// <summary>
    /// 記録関連UI表示処理
    /// </summary>
    public void DisplayConsoleText() {

        CorrectTypeNumText.text = "正解数 : " + ptd.td.CorrectTypeNum.ToString();
        MisTypeNumText.text     = "ミスタイプ数 : " + ptd.td.MisTypeNum.ToString();
        KpmText.text = "KPM : " + ptd.td.Kpm.ToString("f1");
        TaskText.text = "問題数 : " + ptd.td.CorrectTaskNum.ToString() + " / " + gc.gc.Tasks.ToString();
    }
    /// <summary>
    /// 時間UI表示処理
    /// </summary>
    public void DisplayTimeText() {
        
        TotalTimeText.text = "経過時間 : " + ptd.td.TotalTypingTime.ToString("f2");
    }
}
