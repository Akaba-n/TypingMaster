using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingManager : MonoBehaviour {

    /*---------- Scriptの取得(Inspectorで設定) ----------*/
    [SerializeField] private PlayerTypingDataManager ptd;
    [SerializeField] private EnemyTypingDataManager etd;
    [SerializeField] private MatchingNetworkManager mnw;
    [SerializeField] private MatchingPlayerActionManager mpa;
    [SerializeField] private MatchingUIManager mUI;
    
    public void Matching() {
        
        ///// ネットワーク関連処理 /////
        mnw.MatchingNetwork();
        ///// Player操作関連 /////
        mpa.MatchingPlayerAction();
        ///// UI関連処理 /////
        mUI.MatchingUI();

        // マッチング待機時
        if (etd.td.UserId == "none") {

            ptd.td.isReady = false;
        }
    }
}
