using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Matching画面でのプレイヤーのアクションに対する処理のクラス
/// </summary>
public class MatchingPlayerActionManager : MonoBehaviour {

    // スクリプトの取得(Insprctorで設定)
    [SerializeField] private MultiMain mm;
    [SerializeField] private EnemyTypingDataManager etd;
    [SerializeField] private PlayerTypingDataManager ptd;

    /// <summary>
    /// Matching画面でのプレイヤーのアクションに対する処理
    /// </summary>
    public void MatchingPlayerAction() {

        EnterAction();
        EscAction();
    }

    /// <summary>
    /// Enterキーを押したときの処理
    /// </summary>
    private void EnterAction() {

        if (Input.GetKeyDown(KeyCode.Return)) {

            // マッチング完了時
            if(etd.td.UserId != "none") {

                ptd.td.isReady = true;  // 準備完了
            }
        }
    }
    /// <summary>
    /// Escキーを押したときの処理
    /// </summary>
    private void EscAction() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (ptd.td.isReady) {

                ptd.td.isReady = false;  // 準備完了解除
            }
            else {

                ///// マッチングやめるか確認画面表示 /////
                // ↓
                ///// マッチング解除処理 /////
                ///// MenuSceneに戻る処理 /////
            }
        }
    }
}
