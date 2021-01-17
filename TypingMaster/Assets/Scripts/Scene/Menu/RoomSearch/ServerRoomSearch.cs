using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Data;

public class ServerRoomSearch : MonoBehaviour {

    [SerializeField] private MenuMain mm;

    /// <summary>
    /// サーバ接続してRoom検索する処理
    /// </summary>
    /// <param name="roomId">検索Boxに入力した部屋番号</param>
    /// <returns></returns>
    public IEnumerator RoomSearch(string roomId) {

        // キー入力を無効化する
        mm.isInputValid = false;

        // 送信する情報を作成
        var url = ServerUrl.ROOM_SEARCH_URL + "?roomId=" + roomId;
        // URLをPOSTで用意
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();

        // エラーチェック
        if (webRequest.isNetworkError || webRequest.isHttpError) {

            // 通信失敗時処理
            Debug.Log("接続失敗");
            Debug.Log(webRequest.error);
            // キー入力有効化
            mm.isInputValid = true;
        }
        else {

            // 部屋が存在しなかった時の処理
            if(webRequest.downloadHandler.text == "4") {

                ///// エラー文を表示する処理 /////
                Debug.Log("4:部屋が存在していません");
            }
            // 部屋が満員だった時の処理
            else if(webRequest.downloadHandler.text == "3") {

                ///// エラー文を表示する処理 /////
                Debug.Log("3:部屋が満員です");
            }
            else {

                ///// その部屋番号でPlayer2として参加する処理 /////
                Debug.Log(webRequest.downloadHandler.text + ":入室成功");
                int userNum = int.Parse(webRequest.downloadHandler.text);
                // roomIdとUserNumを確定させる
                PlayerPrefs.SetString(PlayerPrefsKey.ROOM_ID, roomId);
                PlayerPrefs.SetInt(PlayerPrefsKey.USER_NUM, userNum);
                // Scene切り替え待機状態に移行
                mm.status = AppDefine.SCENE_STATE.CHANGE_WAIT;
            }
        }
    }
}
