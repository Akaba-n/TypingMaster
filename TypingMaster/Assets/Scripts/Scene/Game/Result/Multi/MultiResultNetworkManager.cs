using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;


public class MultiResultNetworkManager : MonoBehaviour {

    [SerializeField] private MultiResultManager rm;
    [SerializeField] private DownloadEnemyTypingData dletd;

    /// <summary>
    /// MultiシーンでのResult画面でのネットワーク処理
    /// </summary>
    public void ResultNetwork() {

        if (rm.rState == MultiResultManager.RESUTL_STATE.SELECT_WAIT || rm.rState == MultiResultManager.RESUTL_STATE.RETRY_SELECT || rm.rState == MultiResultManager.RESUTL_STATE.ENEMY_WAIT) {

            // 対戦相手のデータ取得
            StartCoroutine(DownloadEnemyData());
        }
    }

    /// <summary>
    /// 対戦相手のデータ取得(リトライ判定用)
    /// </summary>
    public IEnumerator DownloadEnemyData() {

        // 対戦相手のデータ取得
        yield return StartCoroutine(dletd.DownloadETD(PlayerPrefs.GetInt(PlayerPrefsKey.USER_NUM, 1), PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000")));


    }
}
