using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerDataの一時記憶用クラス(TitleSceneでのみ使用)
/// </summary>
public class PlayerData : MonoBehaviour{

    public class PlayerDataTemp{

        public string playerId;
        public string playerName;
        public string email;
        public string pass;
    }

    // インスタンスを作成
    public PlayerDataTemp pd = new PlayerDataTemp();
}
