using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCountdownManager : MonoBehaviour {
    
    [SerializeField] private MultiCountdownUIManager mcdUI;

    // 秒数
    public double countSec;

    private void Start() {

        countSec = 3f;
    }

    /// <summary>
    /// CountDown画面での処理
    /// </summary>
    public void CountDown() {

        countSec -= Time.deltaTime;
        mcdUI.CountdownUI();
    }
}
