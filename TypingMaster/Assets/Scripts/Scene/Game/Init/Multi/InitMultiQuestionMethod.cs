using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

public class InitMultiQuestionMethod : MonoBehaviour {

    [SerializeField] private InitMultiGameManager ig;
    [SerializeField] private GameConfigClass gc;
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private CsvImport ci;
    [SerializeField] private HiraToRom hr;

    /// <summary>
    /// Multiモードでの問題文初期化処理
    /// </summary>
    /// <param name="roomId">roomId</param>
    /// <returns></returns>
    public IEnumerator InitMultiQuestion() {

        // 使用変数作成
        string roomId = PlayerPrefs.GetString(PlayerPrefsKey.ROOM_ID, "0000");

        // 接続先URL
        var url = ServerUrl.DOWNLOAD_SENTENCE_URL + "?roomId=" + roomId;
        // URLをPOSTで用意
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();

        // エラーチェック
        if(webRequest.isNetworkError || webRequest.isHttpError) {

            // 通信失敗時処理
            Debug.Log(webRequest.error);
        }
        else {

            // 通信成功時処理
            Debug.Log("問題文データ");
            // 問題文データセットがcsv形式で返ってくるので格納
            var qCsv = webRequest.downloadHandler.text;
            var tmpList = ci.CsvtextToList(qCsv);

            // 問題文格納
            for(var i = 0; i < tmpList.Count; i++) {

                pa.qSen.Add((tmpList[i].jp, tmpList[i].h, hr.HiraToRomSentence(tmpList[i].h)));
            }

            ig.toMatching = true;
        }
    }
}
