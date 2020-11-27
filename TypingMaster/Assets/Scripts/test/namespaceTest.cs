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

        pData.enteredSentence = "aaa";
        eData.enteredSentence = "bbb";

        playerRmText.text = pData.enteredSentence;
        enemyRmText.text = eData.enteredSentence;
    }
}
