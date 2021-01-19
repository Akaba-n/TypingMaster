using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMultiGameManager : MonoBehaviour {
    
    /*---------- スクリプトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GamePlayerActionManager pa;

    [SerializeField] private InitConfigMethod ic;
    [SerializeField] private InitTypingDataMethod itd;
    [SerializeField] private InitPlayerActionMethod ipa;
    [SerializeField] private InitMultiQuestionMethod iq;

    // 一回のみ実行判定
    public bool isFirst;
    // MATCHING画面遷移判定
    public bool toMatching;

    private void Awake() {

        isFirst = true;
        toMatching = false;
    }

    /// <summary>
    /// GameSceneの初期化メソッド(SOLOモード用)
    /// </summary>
    public void InitGame() {

        // 一回目実行判定
        isFirst = false;

        ic.InitMultiConfig();
        itd.InitTypingData();
        ipa.InitPlayerAction();
        StartCoroutine(iq.InitMultiQuestion());
        ///// 最初の文章のenteredSentenceの格納 /////
        
    }

    /// <summary>
    /// Typing開始時の初期化処理
    /// </summary>
    public void InitTypingStart() {

        pa.isInputValid = true;
    }
}
