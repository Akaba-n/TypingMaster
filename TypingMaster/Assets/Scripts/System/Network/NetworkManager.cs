using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// サーバ通信管理クラス
/// </summary>
public class NetworkManager : AppDefine {

    // 子クラスのインスタンス(Inspectorで設定)
    [SerializeField] private HttpGet httpGet;
    [SerializeField] private HttpPost httpPost;

    // 接続先のURL
    private const string URL = "http://ec2-18-181-251-215.ap-northeast-1.compute.amazonaws.com/test/test.php";
    //private const string URL = "http://zipcloud.ibsnet.co.jp/api/search?zipcode=7830060";
    // サーバへリクエストするデータ
    private string userId = "0";
    private string userName = "waka";
    private string userData = "abc";

    private void Start() {

        // サーバ送信データこねこね
        // POST
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("id", userId);
        dic.Add("name", userName);
        dic.Add("data", userData);
        // POST送信
        PostRequest(URL, dic);

        // GET
        GetRequest(URL, dic);
        GetRequest(URL);
    }
    
    /// <summary>
    /// HTTPにPOST接続を行うメソッド
    /// </summary>
    /// <param name="URL">接続先URL</param>
    /// <param name="dic">送信するデータ</param>
    public void PostRequest(string URL, Dictionary<string, string> dic) {

        StartCoroutine(httpPost.PostRequest(URL, dic));
    }

    /// <summary>
    /// HTTPにGET接続を行うメソッド(データあり)
    /// </summary>
    /// <param name="URL">接続先URL</param>
    /// <param name="dic">送信するデータ</param>
    public void GetRequest(string URL, Dictionary<string, string> dic) {

        StartCoroutine(httpGet.GetRequest(URL, dic));
    }

    /// <summary>
    /// HTTPにGET接続を行うメソッド(データなし)
    /// </summary>
    /// <param name="URL">接続先URL</param>
    public void GetRequest(string URL) {

        StartCoroutine(httpGet.GetRequest(URL));
    }
}
