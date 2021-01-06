using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マッチング待機画面時のUIの管理クラス
/// </summary>
public class MatchingUIManager : MonoBehaviour {

    /*----- スクリプトの取得(Inspectorで設定) -----*/
    [SerializeField] private PlayerTypingUiManager ptUI;
    [SerializeField] private EnemyTypingUIManager etUI;
    /*----- オブジェクトの取得(Inspectorで設定) -----*/
    [SerializeField] private Text _playerJpText;
    [SerializeField] private Text _playerHrText;
    [SerializeField] private Text _playerRmText;
    [SerializeField] private Text _playerAnText;
    [SerializeField] private Text _enemyJpText;
    [SerializeField] private Text _enemyHrText;
    [SerializeField] private Text _enemyRmText;
    [SerializeField] private Text _enemyAnText;

    /// <summary>
    /// マッチング中プレイヤー画面
    /// </summary>
    public void MatchingPlayerUI(string text) {

        _playerJpText.text = "";
        _playerHrText.text = "";
        _playerRmText.text = "";
        _playerAnText.text = text;
    }
    /// <summary>
    /// マッチング中対戦相手画面
    /// </summary>
    public void MatchingEnemyUI(string text) {

        _enemyJpText.text = "";
        _enemyHrText.text = "";
        _enemyRmText.text = "";
        _enemyAnText.text = text;
    }
}
