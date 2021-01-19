using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMultiGameManager : MonoBehaviour {
    
    /*---------- スクリプトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private NextSentenceMethod ns;

    [SerializeField] private InitConfigMethod ic;
    [SerializeField] private InitTypingDataMethod itd;
    [SerializeField] private InitPlayerActionMethod ipa;
    [SerializeField] private InitMultiQuestionMethod iq;

    // MATCHING画面遷移判定
    public bool toMatching;

    private void Awake() {

        toMatching = false;
    }

    /// <summary>
    /// GameSceneの初期化メソッド(SOLOモード用)
    /// </summary>
    public void InitGame() {

        ic.InitMultiConfig();
        itd.InitTypingData();
        ipa.InitPlayerAction();
        StartCoroutine(iq.InitMultiQuestion());
        ///// 最初の文章のenteredSentenceの格納 /////
        ns.NewSentence();
    }

    /// <summary>
    /// Typing開始時の初期化処理
    /// </summary>
    public void InitTypingStart() {

        pa.isInputValid = true;
    }
}
