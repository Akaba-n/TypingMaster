using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameSceneの初期化クラス
/// </summary>
public class InitSoloGameManager : MonoBehaviour {

    /*---------- スクリプトのインスタンス化(Inspectorで設定) ----------*/
    [SerializeField] private GamePlayerActionManager pa;
    [SerializeField] private NextSentenceMethod ns;

    [SerializeField] private InitConfigMethod ic;
    [SerializeField] private InitTypingDataMethod itd;
    [SerializeField] private InitPlayerActionMethod ipa;
    [SerializeField] private InitSoloQuestionMethod iq;

    /// <summary>
    /// GameSceneの初期化メソッド(SOLOモード用)
    /// </summary>
    public void InitGame() {

        ic.InitSoloConfig();
        itd.InitTypingData();
        ipa.InitPlayerAction();
        iq.InitSoloQuestion();
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
