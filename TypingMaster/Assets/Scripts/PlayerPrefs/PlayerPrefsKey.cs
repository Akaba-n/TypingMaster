using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    /// <summary>
    /// PlayerPrefsで扱うPlayerID,PlayerName,その他configのキー名の保管クラス
    /// </summary>
    public class PlayerPrefsKey {

        public const string PLAYER_ID = "my_player_id";
        public const string PLAYER_NAME = "my_player_name";
        public const string BGM_VOLUME = "bgm_vol";
        public const string SE_VOLUME = "se_vol";
    }
}
