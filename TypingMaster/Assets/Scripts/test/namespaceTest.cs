using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;

public class namespaceTest : MonoBehaviour {

    [SerializeField] private Text playerRmText;
    [SerializeField] private Text enemyRmText;
    private TypingData pData = new TypingData();
    private TypingData eData = new TypingData();
    private string rtext;

    // Start is called before the first frame update
    private void Start() {

        PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_ID, "00000001");
        PlayerPrefs.SetString(PlayerPrefsKey.PLAYER_NAME, "Sample");

        pData.enteredSentence = PlayerPrefsKey.PLAYER_ID;
        eData.enteredSentence = PlayerPrefsKey.PLAYER_NAME;

        playerRmText.text = pData.enteredSentence;
        enemyRmText.text = eData.enteredSentence;
    }
}
