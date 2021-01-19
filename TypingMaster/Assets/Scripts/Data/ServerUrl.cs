using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// URL保管用クラス
/// </summary>
public static class ServerUrl {

    //*----- 基本URL -----*//
    public const string BASE_URL = "http://ec2-18-181-251-215.ap-northeast-1.compute.amazonaws.com/";
    //*----- サーバ接続判定用 -----*//
    public const string JUDGE_CONECTION_URL   = BASE_URL + "API/judgeConnection.php";               // サーバ接続確認処理
    //*----- タイトルシーン内 -----*//
    public const string SIGNIN_URL = BASE_URL + "API/signIn.php";                                   // サインインを行う
    public const string SIGNUP_URL = BASE_URL + "API/signUp.php";                                   // サインアップを行う
    //*----- メニューシーン用 -----*//
    public const string MAKE_FRIENDROOM_URL = BASE_URL + "MATCHING/mkFriendRoom.php";               // Room作成を行う
    public const string ROOM_SEARCH_URL = BASE_URL + "MATCHING/searchFriendRoom.php";               // Room検索を行う
    //*----- ゲームシーン用 -----*//
    // マッチング部分用
    public const string DOWNLOAD_SENTENCE_URL = BASE_URL + "MATCHING/downloadSentenceData.php";         // 問題文ダウンロード
    public const string ENEMY_CONNECT_JUDGE_URL = BASE_URL + "MATCHING/enemyConnectJudge.php";      // 対戦相手接続確認
    public const string PLAYER_CONNECT_JUDGE_URL = BASE_URL + "MATCHING/playerConnectJudge.php";    // 自分の接続時間更新
    public const string ENEMY_DISCONNECT_URL = BASE_URL + "MATCHING/enemyDisconnect.php";           // 対戦相手を切断扱いにする処理
    // タイピング部分用
    public const string ENEMY_SYNC_URL        = BASE_URL + "REALTIME/sendTypingData.php";           // 対戦相手のタイピングデータ取得
    public const string PLAYER_TYPINGDATA_URL = BASE_URL + "REALTIME/uploadPlayerData.php";         // 自身のタイピングデータの送信
    public const string PLAYER_RESULT_URL     = BASE_URL + "";
    //*----- ランキング用 -----*//
}
