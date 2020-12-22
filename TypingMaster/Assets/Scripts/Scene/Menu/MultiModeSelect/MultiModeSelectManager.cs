using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiModeSelectManager : MonoBehaviour {

    /*---------- スクリプトの取得(Inspectorで取得) ----------*/
    [SerializeField] private MultiModeSelectUIManager mmsUI;
    [SerializeField] private MultiModeSelectPlayerActionManager mmsPA;

    // MultiModeSelect画面で選択している項目
    public enum MULTI_MODE_SELECT {

        FRIEND,
        RANDOM
    };
    public MULTI_MODE_SELECT mmSelect;
    
    public void MultiModeSelectAction() {

        // プレイヤー操作に対するレスポンス
        mmsPA.MultiModeSelectPlayerAction();
        // UIへの反映
        mmsUI.MultiModeSelectUI();
    }
}
