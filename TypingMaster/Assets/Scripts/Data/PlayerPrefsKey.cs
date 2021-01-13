using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data {

    /// <summary>
    /// PlayerPrefsで扱うPlayerID,PlayerName,その他configのキー名の保管クラス
    /// </summary>
    public class PlayerPrefsKey {

        public const string PLAYER_ID = "my_player_id";
        public const string PLAYER_NAME = "my_player_name";
        public const string PLAYER_MAIL = "my_player_mail";
        public const string PLAYER_PASS = "my_player_pass";
        public const string ROOM_ID = "room_id";
        public const string USER_NUM = "user_num";
        public const string BGM_VOLUME = "bgm_vol";
        public const string SE_VOLUME = "se_vol";
        public const string ONLINE_JUDGE = "online_judge";  // 1:online, 0:offline
    }
}
