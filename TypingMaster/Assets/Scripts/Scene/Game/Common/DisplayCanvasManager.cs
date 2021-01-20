using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 各画面で表示するCanvasのアクティブ/非アクティブを切り替える為のクラス
/// </summary>
public class DisplayCanvasManager : MonoBehaviour {

    /*---------- Scriptの取得(Inspectorで設定) ----------*/
    [SerializeField] private MultiMain mm;
    /*---------- Objectの取得(Inspectorで設定) ----------*/
    // 各画面で表示するCanvas
    [SerializeField] private GameObject MatchingCanvas;
    [SerializeField] private GameObject CountdownCanvas;
    [SerializeField] private GameObject TypingCanvas;
    [SerializeField] private GameObject ResultCanvas;

    /// <summary>
    /// 各画面で表示するCanvasのアクティブ/非アクティブを切り替える処理
    /// </summary>
    public void DisplayCanvasChange() {

        switch (mm.gState) {

            case MultiMain.GAME_STATE.INIT:
                Debug.Log("GAME_STATE:INIT Start");

                MatchingCanvas.SetActive(true);
                CountdownCanvas.SetActive(false);
                TypingCanvas.SetActive(false);
                ResultCanvas.SetActive(false);
                break;

            case MultiMain.GAME_STATE.MATCHING:
                Debug.Log("GAME_STATE:MATCHING Start");

                MatchingCanvas.SetActive(true);
                CountdownCanvas.SetActive(false);
                TypingCanvas.SetActive(false);
                ResultCanvas.SetActive(false);
                break;

            case MultiMain.GAME_STATE.COUNTDOWN:
                Debug.Log("GAME_STATE:COUNTDOWN Start");

                MatchingCanvas.SetActive(false);
                CountdownCanvas.SetActive(true);
                TypingCanvas.SetActive(false);
                ResultCanvas.SetActive(false);
                break;

            case MultiMain.GAME_STATE.TYPING:
                Debug.Log("GAME_STATE:TYPING Start");
                MatchingCanvas.SetActive(false);
                CountdownCanvas.SetActive(false);
                TypingCanvas.SetActive(true);
                ResultCanvas.SetActive(false);
                break;

            case MultiMain.GAME_STATE.RESULT:
                Debug.Log("GAME_STATE:RESULT Start");

                MatchingCanvas.SetActive(false);
                CountdownCanvas.SetActive(false);
                TypingCanvas.SetActive(false);
                ResultCanvas.SetActive(true);
                break;
        }
    }
}
