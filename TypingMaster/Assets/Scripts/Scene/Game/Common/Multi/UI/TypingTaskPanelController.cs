using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingTaskPanelController : MonoBehaviour {

    /*----- Scriptの取得(Inspectorで設定) -----*/
    [SerializeField] MultiMain mm;
    [SerializeField] MultiPlayerTypingDataManager ptd;
    [SerializeField] EnemyTypingDataManager etd;
    [SerializeField] GameConfigClass gc;
    /*----- Objectの取得(Inspectorで設定) -----*/
    [SerializeField] Text playerTaskText;
    [SerializeField] Text enemyTaskText;
    [SerializeField] Text totalTaskText;

    public void TypingTaskPanel() {

        if(mm.gState == MultiMain.GAME_STATE.TYPING) {

            playerTaskText.text = (ptd.td.CorrectTaskNum + 1).ToString();
            enemyTaskText.text  = (etd.td.CorrectTaskNum + 1).ToString();
        }
        else {

            playerTaskText.text = "--";
            enemyTaskText.text  = "--";
        }
        totalTaskText.text = "―――/" + gc.gc.Tasks.ToString();
    }
}
