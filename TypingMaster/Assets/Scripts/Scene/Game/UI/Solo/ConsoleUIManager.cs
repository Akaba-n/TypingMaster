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
    [SerializeField] private PlayerTypingDataManager td;
    [SerializeField] private GameConfig gc;

    /// <summary>
    /// 記録関連UI表示処理
    /// </summary>
    public void DisplayConsoleText() {

        CorrectTypeNumText.text = "正解数 : " + td.CorrectTypeNum.ToString();
        MisTypeNumText.text     = "ミスタイプ数 : " + td.MisTypeNum.ToString();
        KpmText.text = "KPM : " + td.Kpm.ToString("f1");
        TaskText.text = "問題数 : " + td.CorrectTaskNum.ToString() + " / " + gc.Tasks.ToString();
    }
    /// <summary>
    /// 時間UI表示処理
    /// </summary>
    public void DisplayTimeText() {
        
        TotalTimeText.text = "経過時間 : " + td.TotalTypingTime.ToString("f2");
    }
}
